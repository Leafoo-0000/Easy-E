using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class SignUpScreen : Form
    {
        public SignUpScreen()
        {
            InitializeComponent();
        }

        // Connection string to your database
        string connectionString = "server=localhost;database=easy_ev3;uid=root;pwd=;";

        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            string username = UsernameTxtBx.Text.Trim();
            string email = EmailTxtBx.Text.Trim();
            string password = PasswordTxtBx.Text.Trim();

            // Basic validation
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.", "Missing Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Check if username or email already exists
                    string checkQuery = "SELECT COUNT(*) FROM users WHERE username=@u OR email=@e";
                    MySqlCommand checkCmd = new MySqlCommand(checkQuery, conn);
                    checkCmd.Parameters.AddWithValue("@u", username);
                    checkCmd.Parameters.AddWithValue("@e", email);

                    int exists = Convert.ToInt32(checkCmd.ExecuteScalar());
                    if (exists > 0)
                    {
                        MessageBox.Show("Username or email already exists!", "Duplicate Account",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Insert new user (role = 2 → regular user)
                    string insertQuery = "INSERT INTO users (username, email, password, role, created_at) " +
                                         "VALUES (@u, @e, @p, 2, NOW())";
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@u", username);
                    cmd.Parameters.AddWithValue("@e", email);
                    cmd.Parameters.AddWithValue("@p", password);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Account created successfully! You can now log in.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Database Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UsernameTxtBx_TextChanged(object sender, EventArgs e)
        {
            // optional: add live validation later
        }

        private void EmailTxtBx_TextChanged(object sender, EventArgs e)
        {
            // optional: add live validation later
        }

        private void PasswordTxtBx_TextChanged(object sender, EventArgs e)
        {
            // optional: hide/show password feature can go here
        }
    }
}
