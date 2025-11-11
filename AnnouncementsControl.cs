using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyEv3
{
    /// <summary>
    /// Announcements UserControl that displays announcements in a ListBox with Add and Remove functionality.
    /// </summary>
    public partial class AnnouncementsControl : UserControl
    {
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ListBox lstAnnouncements;
        private System.Windows.Forms.Button btnAddAnnouncement;
        private System.Windows.Forms.Button btnRemoveAnnouncement;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtNewAnnouncement;
        private System.Windows.Forms.Label lblNewAnnouncement;

        /// <summary>
        /// Initializes a new instance of the AnnouncementsControl class
        /// </summary>
        public AnnouncementsControl()
        {
            InitializeComponent();
            SetupAnnouncementsControl();
        }

        /// <summary>
        /// Sets up the announcements control with sample data
        /// </summary>
        private void SetupAnnouncementsControl()
        {
            // Configure ListBox
            lstAnnouncements.BackColor = Color.FromArgb(45, 45, 50);
            lstAnnouncements.ForeColor = Color.White;
            lstAnnouncements.BorderStyle = BorderStyle.FixedSingle;
            lstAnnouncements.Font = new Font("Segoe UI", 10F);

            // Add sample announcements
            lstAnnouncements.Items.Clear();
            lstAnnouncements.Items.Add("Welcome to EasyE Event Management System!");
            lstAnnouncements.Items.Add("New feature: Event notifications are now available");
            lstAnnouncements.Items.Add("System maintenance scheduled for next Sunday");
            lstAnnouncements.Items.Add("Please update your profile information");
            lstAnnouncements.Items.Add("New user training session next Friday at 2 PM");
        }

        /// <summary>
        /// Handles the Add Announcement button click
        /// </summary>
        private void BtnAddAnnouncement_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNewAnnouncement.Text))
            {
                MessageBox.Show("Please enter an announcement text.", "Empty Field", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            lstAnnouncements.Items.Add(txtNewAnnouncement.Text);
            txtNewAnnouncement.Clear();
            MessageBox.Show("Announcement added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Handles the Remove Announcement button click
        /// </summary>
        private void BtnRemoveAnnouncement_Click(object sender, EventArgs e)
        {
            if (lstAnnouncements.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an announcement to remove.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to remove this announcement?", "Confirm Remove", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                lstAnnouncements.Items.RemoveAt(lstAnnouncements.SelectedIndex);
                MessageBox.Show("Announcement removed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Handles the Refresh button click
        /// </summary>
        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Refresh functionality would reload announcements from data source.", "Refresh", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.lstAnnouncements = new System.Windows.Forms.ListBox();
            this.btnAddAnnouncement = new System.Windows.Forms.Button();
            this.btnRemoveAnnouncement = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtNewAnnouncement = new System.Windows.Forms.TextBox();
            this.lblNewAnnouncement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(281, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Announcements";
            // 
            // lstAnnouncements
            // 
            this.lstAnnouncements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.lstAnnouncements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstAnnouncements.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstAnnouncements.ForeColor = System.Drawing.Color.White;
            this.lstAnnouncements.FormattingEnabled = true;
            this.lstAnnouncements.ItemHeight = 23;
            this.lstAnnouncements.Location = new System.Drawing.Point(30, 100);
            this.lstAnnouncements.Name = "lstAnnouncements";
            this.lstAnnouncements.Size = new System.Drawing.Size(600, 278);
            this.lstAnnouncements.TabIndex = 1;
            // 
            // btnAddAnnouncement
            // 
            this.btnAddAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.btnAddAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAnnouncement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddAnnouncement.ForeColor = System.Drawing.Color.White;
            this.btnAddAnnouncement.Location = new System.Drawing.Point(30, 420);
            this.btnAddAnnouncement.Name = "btnAddAnnouncement";
            this.btnAddAnnouncement.Size = new System.Drawing.Size(150, 40);
            this.btnAddAnnouncement.TabIndex = 2;
            this.btnAddAnnouncement.Text = "Add Announcement";
            this.btnAddAnnouncement.UseVisualStyleBackColor = false;
            this.btnAddAnnouncement.Click += new System.EventHandler(this.BtnAddAnnouncement_Click);
            // 
            // btnRemoveAnnouncement
            // 
            this.btnRemoveAnnouncement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.btnRemoveAnnouncement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAnnouncement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveAnnouncement.ForeColor = System.Drawing.Color.White;
            this.btnRemoveAnnouncement.Location = new System.Drawing.Point(200, 420);
            this.btnRemoveAnnouncement.Name = "btnRemoveAnnouncement";
            this.btnRemoveAnnouncement.Size = new System.Drawing.Size(150, 40);
            this.btnRemoveAnnouncement.TabIndex = 3;
            this.btnRemoveAnnouncement.Text = "Remove Announcement";
            this.btnRemoveAnnouncement.UseVisualStyleBackColor = false;
            this.btnRemoveAnnouncement.Click += new System.EventHandler(this.BtnRemoveAnnouncement_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(370, 420);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // txtNewAnnouncement
            // 
            this.txtNewAnnouncement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewAnnouncement.Location = new System.Drawing.Point(30, 480);
            this.txtNewAnnouncement.Multiline = true;
            this.txtNewAnnouncement.Name = "txtNewAnnouncement";
            this.txtNewAnnouncement.Size = new System.Drawing.Size(600, 60);
            this.txtNewAnnouncement.TabIndex = 5;
            // 
            // lblNewAnnouncement
            // 
            this.lblNewAnnouncement.AutoSize = true;
            this.lblNewAnnouncement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAnnouncement.ForeColor = System.Drawing.Color.White;
            this.lblNewAnnouncement.Location = new System.Drawing.Point(30, 460);
            this.lblNewAnnouncement.Name = "lblNewAnnouncement";
            this.lblNewAnnouncement.Size = new System.Drawing.Size(177, 23);
            this.lblNewAnnouncement.TabIndex = 6;
            this.lblNewAnnouncement.Text = "New Announcement:";
            // 
            // AnnouncementsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblNewAnnouncement);
            this.Controls.Add(this.txtNewAnnouncement);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnRemoveAnnouncement);
            this.Controls.Add(this.btnAddAnnouncement);
            this.Controls.Add(this.lstAnnouncements);
            this.Controls.Add(this.lblTitle);
            this.Name = "AnnouncementsControl";
            this.Size = new System.Drawing.Size(1428, 599);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
