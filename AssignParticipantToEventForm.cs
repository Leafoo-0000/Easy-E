using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EasyEv3.Models;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class AssignParticipantToEventForm : Form
    {
        private readonly int participantId;

        public AssignParticipantToEventForm(int participantId)
        {
            InitializeComponent();
            this.participantId = participantId;
            LoadEvents();
        }

        // Load all approved events into the DataGridView
        private void LoadEvents()
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    string query = @"
                        SELECT id, title, start_utc, end_utc, location
                        FROM events
                        WHERE status = 2  -- Approved
                        ORDER BY start_utc ASC";

                    using (var cmd = new MySqlCommand(query, db.Connection))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dgvEvents.DataSource = dt;
                    }
                }

                // Add a checkbox column for selection
                if (!dgvEvents.Columns.Contains("Select"))
                {
                    DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn
                    {
                        Name = "Select",
                        HeaderText = "",
                        Width = 30
                    };
                    dgvEvents.Columns.Insert(0, chk);
                }

                // Beautify DataGridView
                dgvEvents.ReadOnly = false;
                dgvEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Assign selected events to the participant
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    foreach (DataGridViewRow row in dgvEvents.Rows)
                    {
                        bool isSelected = Convert.ToBoolean(row.Cells["Select"].Value);
                        if (!isSelected) continue;

                        int eventId = Convert.ToInt32(row.Cells["id"].Value);

                        // Skip if already assigned
                        string checkQuery = @"SELECT COUNT(*) FROM participant_event
                                              WHERE participant_id = @pid AND event_id = @eid";
                        using (var checkCmd = new MySqlCommand(checkQuery, db.Connection))
                        {
                            checkCmd.Parameters.AddWithValue("@pid", participantId);
                            checkCmd.Parameters.AddWithValue("@eid", eventId);
                            long count = (long)checkCmd.ExecuteScalar();
                            if (count > 0) continue;
                        }

                        // Insert into participant_event
                        string insertQuery = @"INSERT INTO participant_event 
                                               (participant_id, event_id, assigned_at)
                                               VALUES (@pid, @eid, NOW())";
                        using (var insertCmd = new MySqlCommand(insertQuery, db.Connection))
                        {
                            insertCmd.Parameters.AddWithValue("@pid", participantId);
                            insertCmd.Parameters.AddWithValue("@eid", eventId);
                            insertCmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Participant assigned successfully!", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Close(); // close popup after assigning
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning participant: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: handle row selection toggle for checkbox
        }

        private void AssignParticipantToEventForm_Load(object sender, EventArgs e)
        {

        }
    }
}
