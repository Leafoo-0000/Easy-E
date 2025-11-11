using System;
using System.Data;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    // Simple DB helper for WinForms sample app. Parameterized queries, DataTable helpers,
    // CRUD for events, archive routine.
    public class EventManager
    {
        private string connString = "";

        public void DbConnection()
        {
            var env = Environment.GetEnvironmentVariable("EASYEV3_CONN");
            if (!string.IsNullOrWhiteSpace(env))
            {
                connString = env;
            }
            else
            {
                // DEV fallback - replace before shipping.
                connString = "Server=127.0.0.1;Port=3306;Database=easy_ev3;Uid=dbuser;Pwd=dbpassword;CharSet=utf8mb4;SslMode=None;";
            }
        }

        // Generic: get DataTable with optional parameters
        public DataTable GetDataTable(string sql, params MySqlParameter[] parameters)
        {
            var dt = new DataTable();
            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            using (var da = new MySqlDataAdapter(cmd))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    cmd.Parameters.AddRange(parameters);
                }
                da.Fill(dt);
            }
            return dt;
        }

        // Simple execute non-query with optional parameters
        public int ExecuteNonQuery(string sql, params MySqlParameter[] parameters)
        {
            using (var conn = new MySqlConnection(connString))
            using (var cmd = new MySqlCommand(sql, conn))
            {
                if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Create event (returns inserted id)
        public int CreateEvent(string title, string description, DateTime startUtc, DateTime endUtc, string location, int ownerUserId, int status)
        {
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();
                using (var cmd = new MySqlCommand(@"
                    INSERT INTO events (title, description, start_utc, end_utc, location, owner_user_id, status)
                    VALUES (@title, @description, @start_utc, @end_utc, @location, @owner_user_id, @status);", conn))
                {
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", string.IsNullOrEmpty(description) ? (object)DBNull.Value : description);
                    cmd.Parameters.AddWithValue("@start_utc", startUtc);
                    cmd.Parameters.AddWithValue("@end_utc", endUtc);
                    cmd.Parameters.AddWithValue("@location", string.IsNullOrEmpty(location) ? (object)DBNull.Value : location);
                    cmd.Parameters.AddWithValue("@owner_user_id", ownerUserId);
                    cmd.Parameters.AddWithValue("@status", status);
                    cmd.ExecuteNonQuery();
                }

                using (var idCmd = new MySqlCommand("SELECT LAST_INSERT_ID();", conn))
                {
                    var idObj = idCmd.ExecuteScalar();
                    return Convert.ToInt32(idObj);
                }
            }
        }

        // Update event (returns rows affected)
        public int UpdateEvent(int id, string title, string description, DateTime startUtc, DateTime endUtc, string location, int ownerUserId, int status)
        {
            string sql = @"
                UPDATE events
                SET title = @title,
                    description = @description,
                    start_utc = @start_utc,
                    end_utc = @end_utc,
                    location = @location,
                    owner_user_id = @owner_user_id,
                    status = @status
                WHERE id = @id";
            var p = new MySqlParameter[]
            {
                new MySqlParameter("@title", MySqlDbType.VarChar) { Value = title },
                new MySqlParameter("@description", MySqlDbType.Text) { Value = string.IsNullOrEmpty(description) ? (object)DBNull.Value : description },
                new MySqlParameter("@start_utc", MySqlDbType.DateTime) { Value = startUtc },
                new MySqlParameter("@end_utc", MySqlDbType.DateTime) { Value = endUtc },
                new MySqlParameter("@location", MySqlDbType.VarChar) { Value = string.IsNullOrEmpty(location) ? (object)DBNull.Value : location },
                new MySqlParameter("@owner_user_id", MySqlDbType.Int32) { Value = ownerUserId },
                new MySqlParameter("@status", MySqlDbType.Int16) { Value = status },
                new MySqlParameter("@id", MySqlDbType.Int32) { Value = id }
            };
            return ExecuteNonQuery(sql, p);
        }

        // Delete event (returns rows affected)
        public int DeleteEvent(int id)
        {
            string sql = "DELETE FROM events WHERE id = @id";
            var p = new MySqlParameter[] { new MySqlParameter("@id", MySqlDbType.Int32) { Value = id } };
            return ExecuteNonQuery(sql, p);
        }

        // Get events (optionally search by title/description)
        public DataTable GetEvents(string search = null)
        {
            if (string.IsNullOrWhiteSpace(search))
            {
                return GetDataTable("SELECT id, title, description, start_utc, end_utc, location, owner_user_id, status, created_at FROM events ORDER BY start_utc DESC");
            }
            else
            {
                string sql = @"
                    SELECT id, title, description, start_utc, end_utc, location, owner_user_id, status, created_at
                    FROM events
                    WHERE title LIKE @q OR description LIKE @q
                    ORDER BY start_utc DESC";
                var p = new MySqlParameter[] { new MySqlParameter("@q", MySqlDbType.VarChar) { Value = "%" + search + "%" } };
                return GetDataTable(sql, p);
            }
        }

        // Archive completed events (end_utc < beforeUtc). Returns count moved.
        public int ArchiveCompletedEvents(DateTime beforeUtc)
        {
            int moved = 0;
            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                // collect ids to archive
                var toArchive = new List<int>();
                using (var sel = new MySqlCommand("SELECT id FROM events WHERE end_utc < @before", conn))
                {
                    sel.Parameters.AddWithValue("@before", beforeUtc);
                    using (var r = sel.ExecuteReader())
                    {
                        while (r.Read()) toArchive.Add(Convert.ToInt32(r["id"]));
                    }
                }

                foreach (var evId in toArchive)
                {
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            int eventLogId = 0;
                            // copy event into event_log
                            using (var ins = new MySqlCommand(@"
                                INSERT INTO event_log (original_event_id, title, description, start_utc, end_utc, location, owner_user_id, status, created_at, archived_at)
                                SELECT id, title, description, start_utc, end_utc, location, owner_user_id, status, created_at, NOW()
                                  FROM events WHERE id = @id;", conn, tx))
                            {
                                ins.Parameters.AddWithValue("@id", evId);
                                ins.ExecuteNonQuery();
                            }
                            using (var last = new MySqlCommand("SELECT LAST_INSERT_ID()", conn, tx))
                            {
                                eventLogId = Convert.ToInt32(last.ExecuteScalar());
                            }

                            // move participants -> participants_log
                            var parts = new List<Tuple<int, object, string, string, DateTime>>();
                            using (var selp = new MySqlCommand("SELECT id, user_id, name, email, created_at FROM participants WHERE event_id = @eventId", conn, tx))
                            {
                                selp.Parameters.AddWithValue("@eventId", evId);
                                using (var r = selp.ExecuteReader())
                                {
                                    while (r.Read())
                                    {
                                        int pid = Convert.ToInt32(r["id"]);
                                        object uid = r["user_id"] == DBNull.Value ? (object)DBNull.Value : r["user_id"];
                                        string name = r["name"] == DBNull.Value ? "" : r["name"].ToString();
                                        string email = r["email"] == DBNull.Value ? "" : r["email"].ToString();
                                        DateTime createdAt = r["created_at"] == DBNull.Value ? DateTime.UtcNow : Convert.ToDateTime(r["created_at"]);
                                        parts.Add(Tuple.Create(pid, uid, name, email, createdAt));
                                    }
                                }
                            }

                            foreach (var p in parts)
                            {
                                using (var insp = new MySqlCommand(@"
                                    INSERT INTO participants_log (event_log_id, original_participant_id, user_id, name, email, created_at)
                                    VALUES (@elog, @origpid, @uid, @name, @email, @created_at)", conn, tx))
                                {
                                    insp.Parameters.AddWithValue("@elog", eventLogId);
                                    insp.Parameters.AddWithValue("@origpid", p.Item1);
                                    insp.Parameters.AddWithValue("@uid", p.Item2);
                                    insp.Parameters.AddWithValue("@name", p.Item3);
                                    insp.Parameters.AddWithValue("@email", p.Item4);
                                    insp.Parameters.AddWithValue("@created_at", p.Item5);
                                    insp.ExecuteNonQuery();
                                }
                            }

                            // delete participants and event
                            using (var delp = new MySqlCommand("DELETE FROM participants WHERE event_id = @id", conn, tx))
                            {
                                delp.Parameters.AddWithValue("@id", evId);
                                delp.ExecuteNonQuery();
                            }
                            using (var dele = new MySqlCommand("DELETE FROM events WHERE id = @id", conn, tx))
                            {
                                dele.Parameters.AddWithValue("@id", evId);
                                dele.ExecuteNonQuery();
                            }

                            tx.Commit();
                            moved++;
                        }
                        catch
                        {
                            try { tx.Rollback(); } catch { }
                            throw;
                        }
                    }
                }
            }
            return moved;
        }
    }
}