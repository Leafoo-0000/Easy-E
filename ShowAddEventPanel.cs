using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EasyEv3.Models;

namespace EasyEv3
{
    public partial class ShowAddEventPanel : UserControl
    {
        private Event editingEvent = null;          // null = Add Mode
        private int currentUserId;                  // currently logged-in user
        private int? currentEventId => editingEvent?.Id;

        public event Action OnEventSaved;

        // Parameterless constructor for designer
        public ShowAddEventPanel()
        {
            InitializeComponent();
            LoadExistingLocations();
        }

        // Constructor with userId for runtime usage
        public ShowAddEventPanel(int userId)
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
                MessageBox.Show($"Error loading locations: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void LoadEventForEditing(Event ev)
        {
            editingEvent = ev;
            txtAddTitle.Text = ev.Title;
            rtbAddDescription.Text = ev.Description;
            dtpAddStart.Value = ev.StartUtc;
            dtpAddEnd.Value = ev.EndUtc;
            comboAddLocation.Text = ev.Location;
            txtNewLocation.Text = "";
            btnSaveEvent.Text = "Update Event";

            LoadEventParticipants(ev.Id);
        }

        public void SetToAddMode()
        {
            editingEvent = null;
            ClearFields();
            btnSaveEvent.Text = "Add Event";
            dgvEventParticipants.DataSource = null;
        }

        private void btnSaveEvent_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtAddTitle.Text) ||
                    string.IsNullOrWhiteSpace(rtbAddDescription.Text) ||
                    (string.IsNullOrWhiteSpace(txtNewLocation.Text) && comboAddLocation.SelectedItem == null))
                {
                    MessageBox.Show("Please fill in all required fields.", "Missing Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string location = string.IsNullOrWhiteSpace(txtNewLocation.Text)
                    ? comboAddLocation.SelectedItem?.ToString() ?? ""
                    : txtNewLocation.Text;

                using (var db = new DatabaseManager())
                {
                    db.Open();

                    if (editingEvent == null)
                    {
                        // INSERT new event
                        string insertQuery = @"INSERT INTO events 
                                               (title, description, start_utc, end_utc, location, owner_user_id, status, created_at)
                                               VALUES (@title, @description, @start, @end, @location, @owner, @status, @created)";
                        using (var cmd = new MySqlCommand(insertQuery, db.Connection))
                        {
                            cmd.Parameters.AddWithValue("@title", txtAddTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@description", rtbAddDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@start", dtpAddStart.Value);
                            cmd.Parameters.AddWithValue("@end", dtpAddEnd.Value);
                            cmd.Parameters.AddWithValue("@location", location);
                            cmd.Parameters.AddWithValue("@owner", currentUserId); // logged-in user
                            cmd.Parameters.AddWithValue("@status", (int)EventStatus.Approved);
                            cmd.Parameters.AddWithValue("@created", DateTime.UtcNow);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Event added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // UPDATE existing event
                        string updateQuery = @"UPDATE events 
                                               SET title=@title, description=@description, start_utc=@start, end_utc=@end, location=@location
                                               WHERE id=@id";
                        using (var cmd = new MySqlCommand(updateQuery, db.Connection))
                        {
                            cmd.Parameters.AddWithValue("@title", txtAddTitle.Text.Trim());
                            cmd.Parameters.AddWithValue("@description", rtbAddDescription.Text.Trim());
                            cmd.Parameters.AddWithValue("@start", dtpAddStart.Value);
                            cmd.Parameters.AddWithValue("@end", dtpAddEnd.Value);
                            cmd.Parameters.AddWithValue("@location", location);
                            cmd.Parameters.AddWithValue("@id", editingEvent.Id);
                            cmd.ExecuteNonQuery();
                        }
                        MessageBox.Show("Event updated successfully!", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                ClearFields();
                OnEventSaved?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving event: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFields()
        {
            txtAddTitle.Clear();
            rtbAddDescription.Clear();
            comboAddLocation.SelectedIndex = -1;
            txtNewLocation.Clear();
            dtpAddStart.Value = DateTime.Now;
            dtpAddEnd.Value = DateTime.Now;
            dgvEventParticipants.DataSource = null;
            txtQRInput.Clear();
            lblScanStatus.Text = "";
        }

        // ================= PARTICIPANTS =================
        private void LoadEventParticipants(int eventId, string searchKeyword = "")
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = @"
                        SELECT p.id, p.name, p.email
                        FROM participants p
                        INNER JOIN participant_event ep ON p.id = ep.participant_id
                        WHERE ep.event_id=@eventId
                        AND (p.name LIKE @search OR p.email LIKE @search)
                        ORDER BY p.name ASC";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@eventId", eventId);
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

        private void btnAddParticipantToEvent_Click(object sender, EventArgs e)
        {
            if (!currentEventId.HasValue)
            {
                MessageBox.Show("Save or select an event first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var addPanel = new ManageParticipantsPanel(currentEventId.Value) { Dock = DockStyle.Fill };
            this.Parent.Controls.Add(addPanel);
            addPanel.BringToFront();
        }

        private void btnRemoveParticipantFromEvent_Click(object sender, EventArgs e)
        {
            if (!currentEventId.HasValue || dgvEventParticipants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select an event and a participant first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int participantId = Convert.ToInt32(dgvEventParticipants.SelectedRows[0].Cells["id"].Value);
            if (MessageBox.Show("Are you sure you want to remove this participant from the event?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    using (var db = new DatabaseManager())
                    {
                        db.Open();
                        string query = "DELETE FROM participant_event WHERE event_id=@eventId AND participant_id=@participantId";
                        using (var cmd = new MySqlCommand(query, db.Connection))
                        {
                            cmd.Parameters.AddWithValue("@eventId", currentEventId.Value);
                            cmd.Parameters.AddWithValue("@participantId", participantId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    LoadEventParticipants(currentEventId.Value, txtSearchParticipants.Text.Trim());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error removing participant: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtSearchParticipants_TextChanged(object sender, EventArgs e)
        {
            if (currentEventId.HasValue)
                LoadEventParticipants(currentEventId.Value, txtSearchParticipants.Text.Trim());
        }

        private void btnSearchParticipants_Click(object sender, EventArgs e)
        {
            if (currentEventId.HasValue)
                LoadEventParticipants(currentEventId.Value, txtSearchParticipants.Text.Trim());
        }

        // ================= QR SCANNING =================
        private void btnScanQR_Click(object sender, EventArgs e)
        {
            if (!currentEventId.HasValue)
            {
                MessageBox.Show("Save or select an event first.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string qrData = txtQRInput.Text.Trim();
            if (string.IsNullOrEmpty(qrData))
            {
                lblScanStatus.Text = "Please scan a QR code.";
                return;
            }

            string[] parts = qrData.Split('|');
            if (parts.Length != 3)
            {
                lblScanStatus.Text = "Invalid QR code format!";
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

                    // Check if participant exists
                    string participantQuery = "SELECT id FROM participants WHERE email=@Email";
                    int participantId;
                    using (var cmd = new MySqlCommand(participantQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        var result = cmd.ExecuteScalar();
                        if (result == null)
                        {
                            lblScanStatus.Text = "Participant not registered!";
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
                            lblScanStatus.Text = "Participant already checked in!";
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

                    lblScanStatus.Text = $"Success! {name} checked in.";
                    LoadEventParticipants(currentEventId.Value);
                    txtQRInput.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during check-in: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQRInput_TextChanged(object sender, EventArgs e)
        {
            lblScanStatus.Text = "";
        }

        private void comboAddLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Optional: handle selection changes
        }
    }
}
