using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace EasyEv3
{
    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }

        string connectionString = "server=localhost;database=easy_ev3;uid=root;pwd=;";

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string usernameOrEmail = UsernameTxtBx.Text.Trim();
            string password = PasswordTxtBx.Text.Trim();

            if (string.IsNullOrEmpty(usernameOrEmail) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username/email and password.",
                    "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // ✅ Fetch user ID, username, and role properly
                    string query = "SELECT id, username, role FROM users WHERE (username=@u OR email=@u) AND password=@p";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", usernameOrEmail);
                    cmd.Parameters.AddWithValue("@p", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // ✅ Safely read and assign correct data types
                            UserSession.UserId = Convert.ToInt32(reader["id"]);
                            UserSession.Username = reader["username"].ToString();
                            UserSession.Role = Convert.ToInt32(reader["role"]);

                            // ✅ Navigate based on role
                            if (UserSession.Role == 1)
                            {
                                Dashboard_Admin adminDashboard = new Dashboard_Admin();
                                adminDashboard.Show();
                                this.Hide();
                            }
                            else if (UserSession.Role == 2)
                            {
                                Dashboard_User userDashboard = new Dashboard_User();
                                userDashboard.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Invalid username/email or password.",
                                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message,
                        "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void SignUp_Click(object sender, EventArgs e)
        {
            SignUpScreen signup = new SignUpScreen();
            signup.ShowDialog();
        }

        private void UsernameTxtBx_TextChanged_1(object sender, EventArgs e) { }

        private void PasswordTxtBx_TextChanged(object sender, EventArgs e) { }

        private void label3_Click(object sender, EventArgs e) { }

        private void label1_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }

        private void Form1_Load(object sender, EventArgs e) { }
    }
}
