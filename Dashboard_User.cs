using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace EasyEv3
{
    public partial class Dashboard_User : Form
    {
        public Dashboard_User()
        {
            InitializeComponent();
        }

        private void Dashboard_User_Load(object sender, EventArgs e)
        {
            // Show greeting
            label3.Text = $"{UserSession.Username}!";

            try
            {
                int currentUserId = UserSession.UserId; // get logged-in user's ID

                // Load the userDashboardPanel by default
                userDashboardPanel dashboardPanel = new userDashboardPanel(currentUserId);
                LoadUserControl(dashboardPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int currentUserId = UserSession.UserId; // get logged-in user's ID

                // Load the userDashboardPanel and pass user ID
                userDashboardPanel dashboardPanel = new userDashboardPanel(currentUserId);
                LoadUserControl(dashboardPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading dashboard: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EventsTab_Click(object sender, EventArgs e)
        {
            try
            {
                int currentUserId = UserSession.UserId; // get logged-in user's ID

                // Load the UserEventsPanel and pass user ID
                UserEventsPanel userEventsPanel = new UserEventsPanel(currentUserId);
                LoadUserControl(userEventsPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading events: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void LoadUserControl(UserControl userControl)
        {
            try
            {
                MainPanel.Controls.Clear();         // remove any current control
                userControl.Dock = DockStyle.Fill;  // make it fill the panel
                MainPanel.Controls.Add(userControl);
                userControl.BringToFront();
                MainPanel.Refresh();
                userControl.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in LoadUserControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private void AnnoucementsTab_Click(object sender, EventArgs e)
        {
            // Clear previous controls
            MainPanel.Controls.Clear();

            // Create a new UserAnnouncements instance
            var userAnnouncements = new UserAnnouncements
            {
                Dock = DockStyle.Fill
            };

            // Add it to the panel
            MainPanel.Controls.Add(userAnnouncements);
            userAnnouncements.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Optional: clear the session info
            UserSession.UserId = 0;
            UserSession.Username = null;
            UserSession.Role = 0;

            // Show the login screen
            LoginScreen login = new LoginScreen();
            login.Show();

            // Close or hide the current dashboard
            this.Hide(); // or this.Close() if you want to fully close
        }
    }
}
