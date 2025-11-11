using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using EasyEv3.Models;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class ShowEventLogPanel : UserControl
    {
        public ShowEventLogPanel()
        {
            InitializeComponent();
            LoadArchivedEvents();
        }
        private void ShowEventLogPanel_Load(object sender, EventArgs e)
        {
            // auto-loads past events when the panel loads
        }

        // 🕒 Load all archived (past) events from event_log
        private void LoadArchivedEvents(string searchKeyword = "")
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();

                    string query = @"SELECT 
                                        id, 
                                        original_event_id, 
                                        title, 
                                        description, 
                                        start_utc, 
                                        end_utc, 
                                        location, 
                                        owner_user_id, 
                                        status, 
                                        created_at, 
                                        archived_at
                                     FROM event_log
                                     WHERE title LIKE @search OR location LIKE @search
                                     ORDER BY archived_at DESC";

                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchKeyword}%");

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvEventLog.DataSource = dt;
                        }
                    }
                }

                // 🎨 Beautify DataGridView
                dgvEventLog.ReadOnly = true;
                dgvEventLog.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvEventLog.DefaultCellStyle.SelectionBackColor = Color.LightGray;
                dgvEventLog.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvEventLog.AllowUserToAddRows = false;
                dgvEventLog.AllowUserToDeleteRows = false;
                dgvEventLog.AllowUserToResizeRows = false;
                dgvEventLog.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Adjust column headers
                if (dgvEventLog.Columns.Count > 0)
                {
                    dgvEventLog.Columns["id"].HeaderText = "Log ID";
                    dgvEventLog.Columns["original_event_id"].HeaderText = "Event ID";
                    dgvEventLog.Columns["title"].HeaderText = "Title";
                    dgvEventLog.Columns["description"].HeaderText = "Description";
                    dgvEventLog.Columns["start_utc"].HeaderText = "Start Date";
                    dgvEventLog.Columns["end_utc"].HeaderText = "End Date";
                    dgvEventLog.Columns["location"].HeaderText = "Location";
                    dgvEventLog.Columns["owner_user_id"].HeaderText = "Owner ID";
                    dgvEventLog.Columns["status"].HeaderText = "Status";
                    dgvEventLog.Columns["created_at"].HeaderText = "Created At";
                    dgvEventLog.Columns["archived_at"].HeaderText = "Archived At";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading archived events: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔍 Triggered when search text changes
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadArchivedEvents(txtSearch.Text.Trim());
        }

        // 🔍 Triggered when search button is clicked
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadArchivedEvents(txtSearch.Text.Trim());
        }

        // 📋 Optional: Handle clicking an archived event (e.g. view details)
        private void dgvEventLog_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dgvEventLog.Rows.Count == 0)
                return;

            DataGridViewRow row = dgvEventLog.Rows[e.RowIndex];

            string details =
                $"Log ID: {row.Cells["id"].Value}\n" +
                $"Event ID: {row.Cells["original_event_id"].Value}\n" +
                $"Title: {row.Cells["title"].Value}\n" +
                $"Description: {row.Cells["description"].Value}\n" +
                $"Start: {row.Cells["start_utc"].Value}\n" +
                $"End: {row.Cells["end_utc"].Value}\n" +
                $"Location: {row.Cells["location"].Value}\n" +
                $"Owner ID: {row.Cells["owner_user_id"].Value}\n" +
                $"Status: {row.Cells["status"].Value}\n" +
                $"Created At: {row.Cells["created_at"].Value}\n" +
                $"Archived At: {row.Cells["archived_at"].Value}";

            MessageBox.Show(details, "Event Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
