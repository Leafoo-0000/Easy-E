namespace EasyEv3
{
    partial class Dashboard_User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Logo = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.AnnoucementsTab = new System.Windows.Forms.Button();
            this.EventsTab = new System.Windows.Forms.Button();
            this.DashboardBtn = new System.Windows.Forms.Button();
            this.SIgnOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.SIgnOut);
            this.panel1.Controls.Add(this.AnnoucementsTab);
            this.panel1.Controls.Add(this.EventsTab);
            this.panel1.Controls.Add(this.DashboardBtn);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Logo);
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, -5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(271, 600);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(114, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "User";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(19, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Welcome,";
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Unispace", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Logo.Location = new System.Drawing.Point(15, 22);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(140, 48);
            this.Logo.TabIndex = 2;
            this.Logo.Text = "EasyE";
            // 
            // MainPanel
            // 
            this.MainPanel.Location = new System.Drawing.Point(271, -1);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1039, 583);
            this.MainPanel.TabIndex = 2;
            // 
            // AnnoucementsTab
            // 
            this.AnnoucementsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.AnnoucementsTab.FlatAppearance.BorderSize = 0;
            this.AnnoucementsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AnnoucementsTab.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AnnoucementsTab.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AnnoucementsTab.Image = global::EasyEv3.Properties.Resources.AnnoucnemntIcn2;
            this.AnnoucementsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AnnoucementsTab.Location = new System.Drawing.Point(3, 293);
            this.AnnoucementsTab.Name = "AnnoucementsTab";
            this.AnnoucementsTab.Size = new System.Drawing.Size(262, 69);
            this.AnnoucementsTab.TabIndex = 8;
            this.AnnoucementsTab.Text = "     Announcements";
            this.AnnoucementsTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AnnoucementsTab.UseVisualStyleBackColor = false;
            this.AnnoucementsTab.Click += new System.EventHandler(this.AnnoucementsTab_Click);
            // 
            // EventsTab
            // 
            this.EventsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.EventsTab.FlatAppearance.BorderSize = 0;
            this.EventsTab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EventsTab.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventsTab.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.EventsTab.Image = global::EasyEv3.Properties.Resources.EventsIcn;
            this.EventsTab.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EventsTab.Location = new System.Drawing.Point(6, 218);
            this.EventsTab.Name = "EventsTab";
            this.EventsTab.Size = new System.Drawing.Size(262, 69);
            this.EventsTab.TabIndex = 6;
            this.EventsTab.Text = "     Events";
            this.EventsTab.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EventsTab.UseVisualStyleBackColor = false;
            this.EventsTab.Click += new System.EventHandler(this.EventsTab_Click);
            // 
            // DashboardBtn
            // 
            this.DashboardBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.DashboardBtn.FlatAppearance.BorderSize = 0;
            this.DashboardBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DashboardBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.DashboardBtn.Image = global::EasyEv3.Properties.Resources.DashbordIcn__2_;
            this.DashboardBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashboardBtn.Location = new System.Drawing.Point(6, 143);
            this.DashboardBtn.Name = "DashboardBtn";
            this.DashboardBtn.Size = new System.Drawing.Size(262, 69);
            this.DashboardBtn.TabIndex = 5;
            this.DashboardBtn.Text = "     Dashboard";
            this.DashboardBtn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashboardBtn.UseVisualStyleBackColor = false;
            this.DashboardBtn.Click += new System.EventHandler(this.DashboardBtn_Click);
            // 
            // SIgnOut
            // 
            this.SIgnOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.SIgnOut.FlatAppearance.BorderSize = 0;
            this.SIgnOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SIgnOut.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SIgnOut.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SIgnOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SIgnOut.Location = new System.Drawing.Point(6, 504);
            this.SIgnOut.Name = "SIgnOut";
            this.SIgnOut.Size = new System.Drawing.Size(262, 69);
            this.SIgnOut.TabIndex = 9;
            this.SIgnOut.Text = "Sign Out";
            this.SIgnOut.UseVisualStyleBackColor = false;
            this.SIgnOut.Click += new System.EventHandler(this.button1_Click);
            // 
            // Dashboard_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1306, 580);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard_User";
            this.Text = "Dashboard_User";
            this.Load += new System.EventHandler(this.Dashboard_User_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AnnoucementsTab;
        private System.Windows.Forms.Button EventsTab;
        private System.Windows.Forms.Button DashboardBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button SIgnOut;
    }
}