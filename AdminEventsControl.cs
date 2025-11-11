using System;
using System.Windows.Forms;

namespace EasyEv3
{
    public partial class AdminEventsControl : UserControl
    {
        private ShowAddEventPanel addEventPanel;
        private ShowViewEventsPanel viewEventPanel;
        private ShowEventLogPanel eventLogPanel;
        private ManageParticipantsPanel manageParticipantsPanel;

        public AdminEventsControl()
        {
            InitializeComponent();
       
        }

        private void LoadDefaultPanel()
        {
            // Show the event list first by default
            viewEventPanel = new ShowViewEventsPanel
            {
                Dock = DockStyle.Fill
            };
            this.Controls.Add(viewEventPanel);
            viewEventPanel.BringToFront();
        }

        private void ViewEventBtn_Click(object sender, EventArgs e)
        {
            if (viewEventPanel == null)
            {
                viewEventPanel = new ShowViewEventsPanel
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(viewEventPanel);
            }

            viewEventPanel.BringToFront();
        }

        private void AddEventBtn_Click(object sender, EventArgs e)
        {
            if (addEventPanel == null)
            {
                addEventPanel = new ShowAddEventPanel(UserSession.UserId)  // pass current user ID here
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(addEventPanel);
            }

            addEventPanel.BringToFront();
        }


        private void EventLogbtn_Click(object sender, EventArgs e)
        {
            if (eventLogPanel == null)
            {
                eventLogPanel = new ShowEventLogPanel
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(eventLogPanel);
            }

            eventLogPanel.BringToFront();
        }

        private void ManageParticipantsBtn_Click(object sender, EventArgs e)
        {
            if (manageParticipantsPanel == null)
            {
                manageParticipantsPanel = new ManageParticipantsPanel
                {
                    Dock = DockStyle.Fill
                };
                this.Controls.Add(manageParticipantsPanel);
            }

            manageParticipantsPanel.BringToFront();
        }
    }
}
