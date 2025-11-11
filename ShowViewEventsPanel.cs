using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EasyEv3.Models;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class ShowViewEventsPanel : UserControl
    {
        private ShowAddEventPanel addEventPanel;
        private int currentAdminId = UserSession.UserId; // adjust as needed for admin context

        public ShowViewEventsPanel()
        {
            InitializeComponent();
            LoadAllEvents();
        }

        private void LoadAllEvents(string searchKeyword = "")
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    string query = @"SELECT id, title, description, start_utc, end_utc, location, owner_user_id, status
                                     FROM events
                                     WHERE title LIKE @search OR location LIKE @search
                                     ORDER BY start_utc ASC";

                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchKeyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvOngoingEvents.DataSource = dt;
                        }
                    }
                }

                dgvOngoingEvents.ReadOnly = true;
                dgvOngoingEvents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvOngoingEvents.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dgvOngoingEvents.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvOngoingEvents.AllowUserToAddRows = false;
                dgvOngoingEvents.AllowUserToDeleteRows = false;
                dgvOngoingEvents.AllowUserToResizeRows = false;
                dgvOngoingEvents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                dgvOngoingEvents.Columns["id"].HeaderText = "Event ID";
                dgvOngoingEvents.Columns["owner_user_id"].HeaderText = "Owner ID";
                dgvOngoingEvents.Columns["status"].HeaderText = "Status";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAllEvents(txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAllEvents(txtSearch.Text.Trim());
        }

        private void dgvOngoingEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvOngoingEvents.Rows.Count == 0) return;

            int eventId = Convert.ToInt32(dgvOngoingEvents.Rows[e.RowIndex].Cells["id"].Value);
            string title = dgvOngoingEvents.Rows[e.RowIndex].Cells["title"].Value.ToString();
            int currentStatus = Convert.ToInt32(dgvOngoingEvents.Rows[e.RowIndex].Cells["status"].Value);

            using (Form dialog = new Form())
            {
                dialog.Text = "Change Event Status";
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.ClientSize = new Size(300, 150);
                dialog.MinimizeBox = false;
                dialog.MaximizeBox = false;

                Label lbl = new Label()
                {
                    Text = $"Event: {title}\nCurrent: {StatusToText(currentStatus)}",
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
                dialog.Controls.Add(lbl);

                ComboBox cmb = new ComboBox()
                {
                    Location = new Point(10, 60),
                    Width = 260,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
                cmb.Items.Add("0 - Draft");
                cmb.Items.Add("1 - Pending Approval");
                cmb.Items.Add("2 - Approved");
                cmb.Items.Add("3 - Rejected");
                cmb.SelectedIndex = currentStatus;
                dialog.Controls.Add(cmb);

                Button btnOk = new Button()
                {
                    Text = "Save",
                    DialogResult = DialogResult.OK,
                    Location = new Point(200, 100)
                };
                dialog.Controls.Add(btnOk);

                dialog.AcceptButton = btnOk;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int newStatus = cmb.SelectedIndex;
                    if (newStatus != currentStatus)
                    {
                        UpdateEventStatus(eventId, newStatus);
                        LoadAllEvents(txtSearch.Text.Trim());
                    }
                }
            }
        }

        private void UpdateEventStatus(int eventId, int newStatus)
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    string query = "UPDATE events SET status = @status WHERE id = @id";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@status", newStatus);
                        cmd.Parameters.AddWithValue("@id", eventId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Event status updated successfully.",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating event status: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string StatusToText(int status)
        {
            switch (status)
            {
                case 0: return "Draft";
                case 1: return "Pending Approval";
                case 2: return "Approved";
                case 3: return "Rejected";
                default: return "Unknown";
            }
        }

        private void ShowViewEventsPanel_Load(object sender, EventArgs e)
        {
            LoadAllEvents();
        }

        // ---------------- EDIT BUTTON ----------------
        private void EditEventBtn_Click(object sender, EventArgs e)
        {
            if (dgvOngoingEvents.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an event to edit.", "No Event Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int eventId = Convert.ToInt32(dgvOngoingEvents.SelectedRows[0].Cells["id"].Value);

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = "SELECT * FROM events WHERE id=@id";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@id", eventId);

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
                                    OwnerUserId = reader.GetInt32("owner_user_id"),
                                    Status = (EventStatus)reader.GetInt32("status") // <-- CAST TO ENUM
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
                addEventPanel = new ShowAddEventPanel(currentAdminId)
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(addEventPanel);
            }

            addEventPanel.BringToFront();
            addEventPanel.LoadEventForEditing(ev);

            // Refresh the list after saving
            addEventPanel.OnEventSaved += () => LoadAllEvents(txtSearch.Text.Trim());
        }
    }
}
