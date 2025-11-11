using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class AdminDashboardControl : UserControl
    {
        string connectionString = "server=localhost;database=easy_ev3;uid=root;pwd=;";

        public AdminDashboardControl()
        {
            InitializeComponent();
            LoadUsers();
            LoadOngoingEvents();
        }

        private void LoadUsers()
        {
            dgvUsers.ReadOnly = true;
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvUsers.MultiSelect = false;
            dgvUsers.Enabled = false; // 🔹 Disable all interaction

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Keep limit 2 for recent users
                    string query = "SELECT username AS 'Recent Users' FROM users ORDER BY created_at DESC LIMIT 2";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvUsers.DataSource = dt;
                    StyleDataGridView(dgvUsers);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading users: " + ex.Message);
                }
            }
        }

        public void LoadOngoingEvents()
        {
            dgvEvents.ReadOnly = true;
            dgvEvents.AllowUserToAddRows = false;
            dgvEvents.AllowUserToDeleteRows = false;
            dgvEvents.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvEvents.MultiSelect = false;
            dgvEvents.Enabled = false; // 🔹 Disable all interaction

            using (var conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Removed LIMIT — show all approved ongoing events
                    string query = @"
                        SELECT 
                            title AS 'Event Title',
                            DATE_FORMAT(start_utc, '%Y-%m-%d %H:%i') AS 'Starts'
                        FROM events
                        WHERE status = 2 AND end_utc >= NOW()
                        ORDER BY created_at DESC;
                    ";

                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    dgvEvents.DataSource = dt;
                    StyleDataGridView(dgvEvents);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading events: " + ex.Message);
                }
            }
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.BackgroundColor = Color.FromArgb(245, 247, 250);
            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = Color.FromArgb(45, 45, 48);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(230, 235, 240);

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(60, 90, 130);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;

            dgv.DefaultCellStyle.SelectionBackColor = dgv.DefaultCellStyle.BackColor;
            dgv.DefaultCellStyle.SelectionForeColor = dgv.DefaultCellStyle.ForeColor;

            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(220, 225, 230);
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void AdminDashboardControl_Load(object sender, EventArgs e)
        {

        }
    }
}
