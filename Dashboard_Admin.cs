using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EasyEv3
{
    public partial class Dashboard_Admin : Form
    {
        private EventManager eventManager;
       

      
        public Dashboard_Admin()
        {
            InitializeComponent();
            InitializeEventManager();
            
        }

      
        private void InitializeEventManager()
        {
            try
            {
                eventManager = new EventManager();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error initializing event manager: {ex.Message}", "Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Admin_Load(object sender, EventArgs e)
        {
            
            AdminDashboardControl dashboardControl = new AdminDashboardControl();
            LoadUserControl(dashboardControl);
            label3.Text = $"{UserSession.Username}!";
        }

        private void eventLog1_EntryWritten(object sender, System.Diagnostics.EntryWrittenEventArgs e)
        {
        
        }

        private void DashboardBtn_Click(object sender, EventArgs e)
        {
            try
            {
                AdminDashboardControl dashboardControl = new AdminDashboardControl();
                LoadUserControl(dashboardControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Dashboard: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void EventsTab_Click(object sender, EventArgs e)
        {
            try
            {
                // load usercontrol
                AdminEventsControl eventsControl = new AdminEventsControl();
                LoadUserControl(eventsControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Events: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UsersTab_Click(object sender, EventArgs e)
        {
            try
            {
                MinimalUsersControl usersControl = new MinimalUsersControl();
                LoadUserControl(usersControl);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Users: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AnnoucementsTab_Click(object sender, EventArgs e)
        {
            try
            {
                AnnouncementPanel announcementPanel = new AnnouncementPanel();
                LoadUserControl(announcementPanel);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Announcements: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        public void LoadUserControl(UserControl userControl)
        {
            try
            {
                // Debug information
                System.Diagnostics.Debug.WriteLine($"Loading UserControl: {userControl.GetType().Name}");
                System.Diagnostics.Debug.WriteLine($"MainPanel size: {MainPanel.Size}");
                System.Diagnostics.Debug.WriteLine($"UserControl size before: {userControl.Size}");
                
                MainPanel.Controls.Clear();               // remove any current control
                userControl.Dock = DockStyle.Fill;         // make it fill the panel
                MainPanel.Controls.Add(userControl);       // add it to the panel
                userControl.BringToFront();                // bring it to the front
                
                System.Diagnostics.Debug.WriteLine($"UserControl size after: {userControl.Size}");
                System.Diagnostics.Debug.WriteLine($"MainPanel controls count: {MainPanel.Controls.Count}");
                
                // Force refresh
                MainPanel.Refresh();
                userControl.Refresh();
                
                // Control loaded successfully
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error in LoadUserControl: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SIgnOut_Click(object sender, EventArgs e)
        {
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
