using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EasyEv3.Models;

namespace EasyEv3
{
    public partial class UserAddEventPanel : UserControl
    {
        private int currentUserId;
        private Event editingEvent = null; // null = Add Mode
        private int? currentEventId => editingEvent?.Id;

        public UserAddEventPanel(int userId)
        {
            InitializeComponent();
            currentUserId = userId;
            LoadExistingLocations();
        }

        private void LoadExistingLocations()
        {
            comboAddLocation.Items.Clear();
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = "SELECT DISTINCT location FROM events WHERE location IS NOT NULL AND location <> ''";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            comboAddLocation.Items.Add(reader.GetString("location"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading locations: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ------------------- ADD/EDIT EVENT -------------------
        public void SetToAddMode()
        {
            editingEvent = null;
            ClearFields();
            btnSaveEvent.Text = "Add Event";
            dgvEventParticipants.DataSource = null;
        }

        public void LoadEventForEditing(Event ev)
        {
            editingEvent = ev;
            txtAddTitle.Text = ev.Title;
            rtbAddDescription.Text = ev.Description;
            dtpAddStart.Value = ev.StartUtc;
            dtpAddEnd.Value = ev.EndUtc;
            comboAddLocation.Text = ev.Location;
            txtNewLocation.Clear();

            btnSaveEvent.Text = "Update Event";

            LoadEventParticipants(ev.Id);
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            string title = txtAddTitle.Text.Trim();
            string description = rtbAddDescription.Text.Trim();
            DateTime start = dtpAddStart.Value;
            DateTime end = dtpAddEnd.Value;

            string location = !string.IsNullOrWhiteSpace(txtNewLocation.Text)
                ? txtNewLocation.Text.Trim()
                : comboAddLocation.SelectedItem?.ToString() ?? "";

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || string.IsNullOrWhiteSpace(location))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    if (editingEvent == null) // Add mode
                    {
                        string query = @"INSERT INTO events 
                                         (title, description, start_utc, end_utc, location, owner_user_id, status, created_at)
                                         VALUES (@title, @description, @start, @end, @location, @owner, @status, @created)";
                        using (var cmd = new MySqlCommand(query, db.Connection))
                        {
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@start", start);
                            cmd.Parameters.AddWithValue("@end", end);
                            cmd.Parameters.AddWithValue("@location", location);
                            cmd.Parameters.AddWithValue("@owner", currentUserId);
                            cmd.Parameters.AddWithValue("@status", 1); // Pending Approval
                            cmd.Parameters.AddWithValue("@created", DateTime.UtcNow);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else // Edit mode
                    {
                        string query = @"UPDATE events SET 
                                         title=@title, description=@description, start_utc=@start, end_utc=@end, location=@location
                                         WHERE id=@id AND owner_user_id=@owner";
                        using (var cmd = new MySqlCommand(query, db.Connection))
                        {
                            cmd.Parameters.AddWithValue("@title", title);
                            cmd.Parameters.AddWithValue("@description", description);
                            cmd.Parameters.AddWithValue("@start", start);
                            cmd.Parameters.AddWithValue("@end", end);
                            cmd.Parameters.AddWithValue("@location", location);
                            cmd.Parameters.AddWithValue("@id", editingEvent.Id);
                            cmd.Parameters.AddWithValue("@owner", currentUserId);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Event updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                SetToAddMode();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving event: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtAddTitle.Clear();
            rtbAddDescription.Clear();
            txtNewLocation.Clear();
            comboAddLocation.SelectedIndex = -1;
            dtpAddStart.Value = DateTime.Now;
            dtpAddEnd.Value = DateTime.Now;
            Qrtxt.Clear();
            QrStatusTxt.Text = "";
            dgvEventParticipants.DataSource = null;
        }

        private void comboAddLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtNewLocation.Clear();
        }

        // ------------------- QR SCANNING -------------------
        private void QrADDbtn_Click(object sender, EventArgs e)
        {
            if (!currentEventId.HasValue)
            {
                MessageBox.Show("Save or select an event first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string qrData = Qrtxt.Text.Trim();
            if (string.IsNullOrEmpty(qrData))
            {
                QrStatusTxt.Text = "Please scan a QR code.";
                return;
            }

            string[] parts = qrData.Split('|');
            if (parts.Length != 3)
            {
                QrStatusTxt.Text = "Invalid QR code format!";
                return;
            }

            string name = parts[0];
            string email = parts[1];
            string qrId = parts[2];

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    // Check participant exists
                    string participantQuery = "SELECT id FROM participants WHERE email=@Email";
                    int participantId;
                    using (var cmd = new MySqlCommand(participantQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            QrStatusTxt.Text = "Participant not registered!";
                            return;
                        }
                        participantId = Convert.ToInt32(result);
                    }

                    // Check if already assigned to this event
                    string checkQuery = "SELECT COUNT(*) FROM participant_event WHERE event_id=@EventId AND participant_id=@ParticipantId";
                    using (var cmd = new MySqlCommand(checkQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@EventId", currentEventId.Value);
                        cmd.Parameters.AddWithValue("@ParticipantId", participantId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            QrStatusTxt.Text = "Participant already checked in!";
                            return;
                        }
                    }

                    // Insert participant into event
                    string insertQuery = @"INSERT INTO participant_event (event_id, participant_id) VALUES (@EventId, @ParticipantId)";
                    using (var cmd = new MySqlCommand(insertQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@EventId", currentEventId.Value);
                        cmd.Parameters.AddWithValue("@ParticipantId", participantId);
                        cmd.ExecuteNonQuery();
                    }

                    QrStatusTxt.Text = $"Success! {name} checked in.";
                    Qrtxt.Clear();

                    // Reload participant list after check-in
                    LoadEventParticipants(currentEventId.Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during check-in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Qrtxt_TextChanged(object sender, EventArgs e)
        {
            QrStatusTxt.Text = "";
        }

        // ------------------- LOAD PARTICIPANTS -------------------
        private void LoadEventParticipants(int eventId, string searchKeyword = "")
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = @"SELECT p.id, p.name, p.email
                                     FROM participants p
                                     INNER JOIN participant_event ep ON p.id = ep.participant_id
                                     WHERE ep.event_id=@EventId
                                     AND (p.name LIKE @search OR p.email LIKE @search)
                                     ORDER BY p.name ASC";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@EventId", eventId);
                        cmd.Parameters.AddWithValue("@search", $"%{searchKeyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvEventParticipants.DataSource = dt;
                        }
                    }
                }

                dgvEventParticipants.ReadOnly = true;
                dgvEventParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEventParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading participants: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvEventParticipants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: You can add code here for clicking participants (e.g., remove participant or show details)
        }
    }
}
