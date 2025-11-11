using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class userDashboardPanel : UserControl
    {
        public int CurrentUserId { get; set; }
        private string connectionString = "server=localhost;database=easy_ev3;uid=root;pwd=;";

        public userDashboardPanel()
        {
            InitializeComponent();
        }

        public userDashboardPanel(int userId) : this()
        {
            CurrentUserId = userId;
            LoadApprovedEvents();
            LoadPendingEvents();
        }

        // Display approved/ongoing events
        private void LoadApprovedEvents()
        {
            try
            {
                using (var db = new MySqlConnection(connectionString))
                {
                    db.Open();
                    string query = @"
                        SELECT title AS 'Event Name',
                               start_utc AS 'Start Date',
                               end_utc AS 'End Date',
                               location AS 'Location'
                        FROM events
                        WHERE owner_user_id=@userId AND status=2
                        ORDER BY start_utc ASC";

                    using (var cmd = new MySqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@userId", CurrentUserId);
                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            dgvEvents.DataSource = dt;
                        }
                    }
                }
                FormatDataGridView(dgvEvents);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading approved events: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Display pending events
        private void LoadPendingEvents()
        {
            try
            {
                using (var db = new MySqlConnection(connectionString))
                {
                    db.Open();
                    string query = @"
                        SELECT title AS 'Event Name',
                               start_utc AS 'Start Date',
                               end_utc AS 'End Date',
                               location AS 'Location'
                        FROM events
                        WHERE owner_user_id=@userId AND status=1
                        ORDER BY start_utc ASC";

                    using (var cmd = new MySqlCommand(query, db))
                    {
                        cmd.Parameters.AddWithValue("@userId", CurrentUserId);
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
                MessageBox.Show($"Error loading pending events: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatDataGridView(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void PendingEvReq_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
