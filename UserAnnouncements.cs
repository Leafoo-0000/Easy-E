using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class UserAnnouncements : UserControl
    {
        public UserAnnouncements()
        {
            InitializeComponent();
            CustomizeDGV();
            LoadAnnouncements();
        }

        private void CustomizeDGV()
        {
            AnnouncemnentDGV.ReadOnly = true;
            AnnouncemnentDGV.AllowUserToAddRows = false;
            AnnouncemnentDGV.AllowUserToDeleteRows = false;
            AnnouncemnentDGV.AllowUserToResizeRows = false;
            AnnouncemnentDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            AnnouncemnentDGV.MultiSelect = false;
            AnnouncemnentDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AnnouncemnentDGV.RowHeadersVisible = false;
            AnnouncemnentDGV.DefaultCellStyle.BackColor = Color.FromArgb(50, 50, 55);
            AnnouncemnentDGV.DefaultCellStyle.ForeColor = Color.White;
            AnnouncemnentDGV.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            AnnouncemnentDGV.DefaultCellStyle.SelectionForeColor = Color.Black;
            AnnouncemnentDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 50);
            AnnouncemnentDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            AnnouncemnentDGV.EnableHeadersVisualStyles = false;

            AnnouncemnentDGV.CellDoubleClick += AnnouncemnentDGV_CellDoubleClick;
        }

        private void LoadAnnouncements(string searchKeyword = "")
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = @"SELECT id, title, body, created_at 
                                     FROM announcements 
                                     WHERE title LIKE @search OR body LIKE @search
                                     ORDER BY created_at DESC";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{searchKeyword}%");
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Add a preview column (first 50 chars)
                            dt.Columns.Add("Preview", typeof(string));
                            foreach (DataRow row in dt.Rows)
                            {
                                string body = row["body"].ToString();
                                row["Preview"] = body.Length > 50 ? body.Substring(0, 50) + "..." : body;
                            }

                            AnnouncemnentDGV.DataSource = dt;

                            // Hide full body column, show preview
                            AnnouncemnentDGV.Columns["id"].Visible = false;
                            AnnouncemnentDGV.Columns["body"].Visible = false;
                            AnnouncemnentDGV.Columns["Preview"].HeaderText = "Announcement Preview";
                            AnnouncemnentDGV.Columns["title"].HeaderText = "Title";
                            AnnouncemnentDGV.Columns["created_at"].HeaderText = "Sent At";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading announcements: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadAnnouncements(txtSearch.Text.Trim());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadAnnouncements(txtSearch.Text.Trim());
        }

        private void AnnouncemnentDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = AnnouncemnentDGV.Rows[e.RowIndex];
            string title = row.Cells["title"].Value?.ToString() ?? "";
            string body = row.Cells["body"].Value?.ToString() ?? "";
            string createdAt = row.Cells["created_at"].Value?.ToString() ?? "";

            MessageBox.Show($"{body}\n\nSent: {createdAt}", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AnnouncemnentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Optional: click actions can go here
        }
    }
}
