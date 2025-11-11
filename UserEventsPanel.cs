using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EasyEv3.Models;

namespace EasyEv3
{
    public partial class UserEventsPanel : UserControl
    {
        private int currentUserId;
        private UserAddEventPanel addEventPanel;

        public UserEventsPanel(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadUserEvents();
        }

        private void LoadUserEvents()
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = @"
                        SELECT id AS 'Event ID',
                               title AS 'Event Name',
                               start_utc AS 'Start Date',
                               end_utc AS 'End Date',
                               location AS 'Location'
                        FROM events
                        WHERE owner_user_id = @userId
                        ORDER BY start_utc DESC";

                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@userId", currentUserId);

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            PendingEvReq.DataSource = dt;
                        }
                    }
                }

                FormatDataGridView(PendingEvReq);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
        }

        // ----------------- DOUBLE CLICK TO EDIT -----------------
        private void PendingEvReq_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= PendingEvReq.Rows.Count) return;

            int eventId = Convert.ToInt32(PendingEvReq.Rows[e.RowIndex].Cells["Event ID"].Value);

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = "SELECT * FROM events WHERE id=@id AND owner_user_id=@owner";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", eventId);
                        cmd.Parameters.AddWithValue("@owner", currentUserId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Event ev = new Event
                                {
                                    Id = reader.GetInt32("id"),
                                    Title = reader.GetString("title"),
                                    Description = reader.GetString("description"),
                                    StartUtc = reader.GetDateTime("start_utc"),
                                    EndUtc = reader.GetDateTime("end_utc"),
                                    Location = reader.GetString("location"),
                                    OwnerUserId = reader.GetInt32("owner_user_id")
                                };

                                OpenAddEventPanel(ev);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading event for editing: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenAddEventPanel(Event ev)
        {
            if (addEventPanel == null)
            {
                addEventPanel = new UserAddEventPanel(currentUserId)
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(addEventPanel);
            }

            addEventPanel.BringToFront();
            addEventPanel.LoadEventForEditing(ev); // load selected event for editing
        }

        // ----------------- CREATE NEW EVENT -----------------
        private void btnCreateEvent_Click(object sender, EventArgs e)
        {
            if (addEventPanel == null)
            {
                addEventPanel = new UserAddEventPanel(currentUserId)
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(addEventPanel);
            }

            addEventPanel.BringToFront();
            addEventPanel.SetToAddMode(); // set panel to Add mode
        }

        // ----------------- REFRESH / SEARCH BUTTONS -----------------
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUserEvents();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUserEvents();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadUserEvents();
        }

        private void PendingEvReq_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditEventBtn_Click(object sender, EventArgs e)
        {
            if (PendingEvReq.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event to edit.", "No Event Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = Convert.ToInt32(PendingEvReq.SelectedRows[0].Cells["Event ID"].Value);

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = "SELECT * FROM events WHERE id=@id AND owner_user_id=@owner";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", eventId);
                        cmd.Parameters.AddWithValue("@owner", currentUserId);

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                Event ev = new Event
                                {
                                    Id = reader.GetInt32("id"),
                                    Title = reader.GetString("title"),
                                    Description = reader.GetString("description"),
                                    StartUtc = reader.GetDateTime("start_utc"),
                                    EndUtc = reader.GetDateTime("end_utc"),
                                    Location = reader.GetString("location"),
                                    OwnerUserId = reader.GetInt32("owner_user_id")
                                };

                                OpenAddEventPanel(ev); // reuse the same method as double-click
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading event for editing: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
