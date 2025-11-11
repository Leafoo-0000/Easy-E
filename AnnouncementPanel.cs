using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class AnnouncementPanel : UserControl
    {
        public AnnouncementPanel()
        {
            InitializeComponent();
            CustomizeDGV();
            LoadAnnouncements();
            AnnoucnementTxtBox.TextChanged += AnnoucnementTxtBox_TextChanged;
            btnSend.Click += btnSend_Click;
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

        private void LoadAnnouncements()
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = "SELECT id, body, created_at FROM announcements ORDER BY created_at DESC";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    using (var adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Optional: truncate body for preview
                        dt.Columns.Add("Preview", typeof(string));
                        foreach (DataRow row in dt.Rows)
                        {
                            string body = row["body"].ToString();
                            row["Preview"] = body.Length > 50 ? body.Substring(0, 50) + "..." : body;
                        }

                        AnnouncemnentDGV.DataSource = dt;
                        AnnouncemnentDGV.Columns["id"].Visible = false;
                        AnnouncemnentDGV.Columns["body"].Visible = false;
                        AnnouncemnentDGV.Columns["Preview"].HeaderText = "Announcement Preview";
                        AnnouncemnentDGV.Columns["created_at"].HeaderText = "Sent At";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading announcements: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string body = AnnoucnementTxtBox.Text.Trim();
            if (string.IsNullOrEmpty(body))
            {
                MessageBox.Show("Please type a message before sending.", "Empty Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = "INSERT INTO announcements (title, body) VALUES (@title, @body)";
                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@title", "Announcement");
                        cmd.Parameters.AddWithValue("@body", body);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Announcement sent successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnnoucnementTxtBox.Clear();
                LoadAnnouncements();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending announcement: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnnoucnementTxtBox_TextChanged(object sender, EventArgs e)
        {
            btnSend.Enabled = !string.IsNullOrWhiteSpace(AnnoucnementTxtBox.Text);
        }

        private void AnnouncemnentDGV_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = AnnouncemnentDGV.Rows[e.RowIndex];
            string body = row.Cells["body"].Value?.ToString() ?? "";
            string createdAt = row.Cells["created_at"].Value?.ToString() ?? "";

            MessageBox.Show($"{body}\n\nSent: {createdAt}", "Announcement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void AnnouncemnentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
