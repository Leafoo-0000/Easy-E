using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EasyEv3.Models;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class ManageParticipantsPanel : UserControl
    {
        
        public int? CurrentEventId { get; set; }

     
        public ManageParticipantsPanel()
        {
            InitializeComponent();
            LoadParticipants();
        }

      
        public ManageParticipantsPanel(int eventId) : this()
        {
            CurrentEventId = eventId;
        }

        private void LoadParticipants(string searchKeyword = "")
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    string query = @"
                        SELECT 
                            id,
                            name,
                            email,
                            created_at
                        FROM participants
                        WHERE name LIKE @search
                           OR email LIKE @search
                        ORDER BY created_at DESC";

                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchKeyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvParticipants.DataSource = dt;
                        }
                    }
                }

                dgvParticipants.ReadOnly = true;
                dgvParticipants.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvParticipants.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dgvParticipants.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvParticipants.AllowUserToAddRows = false;
                dgvParticipants.AllowUserToDeleteRows = false;
                dgvParticipants.AllowUserToResizeRows = false;
                dgvParticipants.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                if (dgvParticipants.Columns.Contains("id"))
                    dgvParticipants.Columns["id"].HeaderText = "ID";
                if (dgvParticipants.Columns.Contains("name"))
                    dgvParticipants.Columns["name"].HeaderText = "Name";
                if (dgvParticipants.Columns.Contains("email"))
                    dgvParticipants.Columns["email"].HeaderText = "Email";
                if (dgvParticipants.Columns.Contains("created_at"))
                    dgvParticipants.Columns["created_at"].HeaderText = "Created At";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading participants: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadParticipants(txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadParticipants(txtSearch.Text.Trim());
        }

        private void btnAddParticipant_Click(object sender, EventArgs e)
        {
            OpenParticipantPanel(); // Open panel in Add mode :D
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            LoadParticipants();
        }

        private void dgvParticipants_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvParticipants.Rows.Count == 0)
                return;

            int participantId = Convert.ToInt32(dgvParticipants.Rows[e.RowIndex].Cells["id"].Value);

            // Open the Add/Edit panel in Edit mode
            OpenParticipantPanel(participantId);
        }

        private void OpenParticipantPanel(int? participantId = null)
        {
            var addEditPanel = new ShowAddParticipantPanel
            {
                Dock = DockStyle.Fill
            };

            if (participantId.HasValue)
            {
                try
                {
                    using (var db = new DatabaseManager())
                    {
                        db.Open();
                        string query = "SELECT * FROM participants WHERE id = @id";
                        using (var cmd = new MySqlCommand(query, db.Connection))
                        {
                            cmd.Parameters.AddWithValue("@id", participantId.Value);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    addEditPanel.LoadParticipantForEditing(new Participant
                                    {
                                        Id = reader.GetInt32("id"),
                                        Name = reader["name"].ToString(),
                                        Email = reader["email"].ToString(),
                                        QRCode = reader["qr_code"].ToString()
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading participant: {ex.Message}", "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            addEditPanel.OnParticipantSaved += () =>
            {
                LoadParticipants();
                this.BringToFront();
            };

            this.Parent.Controls.Add(addEditPanel);
            addEditPanel.BringToFront();
        }

        private void AssignToEventBtn_Click(object sender, EventArgs e)
        {
            if (dgvParticipants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a participant first.", "No Participant Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int participantId = Convert.ToInt32(dgvParticipants.SelectedRows[0].Cells["id"].Value);

            if (!CurrentEventId.HasValue)
            {
                // Fallback: show popup to select event
                var popup = new AssignParticipantToEventForm(participantId)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                popup.ShowDialog();
                return;
            }

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    // see if participant is in event already
                    string checkQuery = @"SELECT COUNT(*) FROM participant_event 
                                  WHERE event_id=@eventId AND participant_id=@participantId";
                    using (var cmd = new MySqlCommand(checkQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@eventId", CurrentEventId.Value);
                        cmd.Parameters.AddWithValue("@participantId", participantId);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());

                        if (count >= 1) // cap = 1
                        {
                            MessageBox.Show("This participant is already assigned to this event!",
                                "Duplicate Participant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    //  inser participant into event
                    string insertQuery = @"INSERT INTO participant_event (event_id, participant_id) 
                                   VALUES (@eventId, @participantId)";
                    using (var cmd = new MySqlCommand(insertQuery, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@eventId", CurrentEventId.Value);
                        cmd.Parameters.AddWithValue("@participantId", participantId);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Participant assigned to event successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error assigning participant: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditParticipantbtn_Click(object sender, EventArgs e)
        {
            if (dgvParticipants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a participant first.", "No Participant Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int participantId = Convert.ToInt32(dgvParticipants.SelectedRows[0].Cells["id"].Value);

            OpenParticipantPanel(participantId);
        }

        private void ManageParticipantsPanel_Load(object sender, EventArgs e)
        {

        }

        private void dgvParticipants_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
