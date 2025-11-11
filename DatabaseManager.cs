using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public class DatabaseManager : IDisposable
    {
        private readonly string _connectionString =
            "server=localhost;user=root;password=;database=easy_ev3;";

        private MySqlConnection _connection;

        // Public connection property
        public MySqlConnection Connection => _connection;

        public void Open()
        {
            if (_connection == null)
                _connection = new MySqlConnection(_connectionString);

            if (_connection.State != System.Data.ConnectionState.Open)
                _connection.Open();
        }

        public void Close()
        {
            if (_connection != null && _connection.State != System.Data.ConnectionState.Closed)
                _connection.Close();
        }

        public void Dispose()
        {
            Close();
            _connection?.Dispose();
        }

        public void ArchiveFinishedEvents()
        {
            try
            {
                Open();

                // Step 1: Select events that already ended
                string selectQuery = @"
            SELECT id, title, description, start_utc, end_utc, location, owner_user_id, status, created_at
            FROM events
            WHERE end_utc < NOW();";

                using (var selectCmd = new MySqlCommand(selectQuery, Connection))
                using (var reader = selectCmd.ExecuteReader())
                {
                    var finishedEvents = new List<Dictionary<string, object>>();

                    while (reader.Read())
                    {
                        finishedEvents.Add(new Dictionary<string, object>
                {
                    { "id", reader["id"] },
                    { "title", reader["title"] },
                    { "description", reader["description"] },
                    { "start_utc", reader["start_utc"] },
                    { "end_utc", reader["end_utc"] },
                    { "location", reader["location"] },
                    { "owner_user_id", reader["owner_user_id"] },
                    { "status", reader["status"] },
                    { "created_at", reader["created_at"] }
                });
                    }

                    reader.Close();

                    // Step 2: Move each finished event into event_log
                    foreach (var ev in finishedEvents)
                    {
                        string insertQuery = @"
                    INSERT INTO event_log 
                    (original_event_id, title, description, start_utc, end_utc, location, owner_user_id, status, created_at, archived_at)
                    VALUES (@id, @title, @desc, @start, @end, @loc, @owner, @status, @created, NOW());";

                        using (var insertCmd = new MySqlCommand(insertQuery, Connection))
                        {
                            insertCmd.Parameters.AddWithValue("@id", ev["id"]);
                            insertCmd.Parameters.AddWithValue("@title", ev["title"]);
                            insertCmd.Parameters.AddWithValue("@desc", ev["description"]);
                            insertCmd.Parameters.AddWithValue("@start", ev["start_utc"]);
                            insertCmd.Parameters.AddWithValue("@end", ev["end_utc"]);
                            insertCmd.Parameters.AddWithValue("@loc", ev["location"]);
                            insertCmd.Parameters.AddWithValue("@owner", ev["owner_user_id"]);
                            insertCmd.Parameters.AddWithValue("@status", ev["status"]);
                            insertCmd.Parameters.AddWithValue("@created", ev["created_at"]);
                            insertCmd.ExecuteNonQuery();
                        }

                        // Step 3: Delete it from the events table
                        string deleteQuery = "DELETE FROM events WHERE id = @id;";
                        using (var deleteCmd = new MySqlCommand(deleteQuery, Connection))
                        {
                            deleteCmd.Parameters.AddWithValue("@id", ev["id"]);
                            deleteCmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error archiving finished events: " + ex.Message);
            }
            finally
            {
                Close();
            }
        }

    }
}
