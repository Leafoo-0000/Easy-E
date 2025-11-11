using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using EasyEv3.Models;

namespace EasyEv3
{
    public partial class MinimalUsersControl : UserControl
    {
        private DataGridView dgvUsers;
        private TextBox txtSearch;
        private Button btnRefresh;
        private ComboBox comboRoleFilter;
        private Label label1;
        private Label label2;
        private Button btnSearch;

        public MinimalUsersControl()
        {
            InitializeComponent();
            LoadRoleFilter();
            LoadUsers();
        }

        private void InitializeComponent()
        {
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.comboRoleFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();

            this.dgvUsers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new Point(86, 106);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 24;
            this.dgvUsers.Size = new Size(878, 436);
            this.dgvUsers.TabIndex = 1;
            this.dgvUsers.CellContentClick += new DataGridViewCellEventHandler(this.dgvUsers_CellContentClick);

            this.txtSearch.Location = new Point(86, 77);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new Size(156, 22);
            this.txtSearch.TabIndex = 8;
            this.txtSearch.TextChanged += new EventHandler(this.txtSearch_TextChanged);

            this.btnSearch.Location = new Point(258, 77);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new Size(75, 23);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            this.btnRefresh.Location = new Point(352, 76);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new Size(75, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            this.comboRoleFilter.FormattingEnabled = true;
            this.comboRoleFilter.Location = new Point(843, 75);
            this.comboRoleFilter.Name = "comboRoleFilter";
            this.comboRoleFilter.Size = new Size(121, 24);
            this.comboRoleFilter.TabIndex = 11;
            this.comboRoleFilter.SelectedIndexChanged += new EventHandler(this.comboRoleFilter_SelectedIndexChanged);

            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = SystemColors.ButtonFace;
            this.label1.Location = new Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new Size(63, 28);
            this.label1.TabIndex = 12;
            this.label1.Text = "Users";

            this.label2.AutoSize = true;
            this.label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = SystemColors.ButtonFace;
            this.label2.Location = new Point(704, 70);
            this.label2.Name = "label2";
            this.label2.Size = new Size(133, 28);
            this.label2.TabIndex = 13;
            this.label2.Text = "Filter by role";

            this.AutoScaleDimensions = new SizeF(8F, 16F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(45, 45, 50);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboRoleFilter);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvUsers);
            this.Name = "MinimalUsersControl";
            this.Size = new Size(1053, 627);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void LoadRoleFilter()
        {
            comboRoleFilter.Items.Clear();
            comboRoleFilter.Items.Add("All");
            comboRoleFilter.Items.Add("User");
            comboRoleFilter.Items.Add("Admin");
            comboRoleFilter.SelectedIndex = 0;
        }

        private void LoadUsers()
        {
            try
            {
                using (var db = new DatabaseManager())
                {
                    db.Open();
                    string query = @"
                        SELECT id, username, email, role, created_at
                        FROM users
                        WHERE (@search = '' OR username LIKE @search OR email LIKE @search)
                        AND (@roleId IS NULL OR role = @roleId)
                        ORDER BY created_at DESC";

                    using (var cmd = new MySqlCommand(query, db.Connection))
                    {
                        cmd.Parameters.AddWithValue("@search", $"%{txtSearch.Text.Trim()}%");

                        int? roleId = null;
                        if (comboRoleFilter.SelectedItem != null)
                        {
                            if (comboRoleFilter.SelectedItem.ToString() == "Admin")
                                roleId = 1;
                            else if (comboRoleFilter.SelectedItem.ToString() == "User")
                                roleId = 2;
                        }

                        if (roleId.HasValue)
                            cmd.Parameters.AddWithValue("@roleId", roleId.Value);
                        else
                            cmd.Parameters.AddWithValue("@roleId", DBNull.Value);

                        using (var adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            if (!dt.Columns.Contains("RoleName"))
                                dt.Columns.Add("RoleName", typeof(string));

                            foreach (DataRow row in dt.Rows)
                            {
                                byte roleValue = Convert.ToByte(row["role"]);
                                row["RoleName"] = roleValue == 1 ? "Admin" : "User";
                            }

                            dgvUsers.DataSource = dt;
                        }
                    }
                }

                dgvUsers.ReadOnly = true;
                dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            comboRoleFilter.SelectedIndex = 0;
            LoadUsers();
        }

        private void comboRoleFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadUsers();
        }

        private void dgvUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {
        }
    }
}
