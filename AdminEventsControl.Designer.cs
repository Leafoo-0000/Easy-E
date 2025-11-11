namespace EasyEv3
{
    partial class AdminEventsControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ViewEventBtn = new System.Windows.Forms.Button();
            this.AddEventBtn = new System.Windows.Forms.Button();
            this.EventLogbtn = new System.Windows.Forms.Button();
            this.ManageParticipantsBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ViewEventBtn
            // 
            this.ViewEventBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.ViewEventBtn.FlatAppearance.BorderSize = 0;
            this.ViewEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ViewEventBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ViewEventBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ViewEventBtn.Location = new System.Drawing.Point(104, 73);
            this.ViewEventBtn.Name = "ViewEventBtn";
            this.ViewEventBtn.Size = new System.Drawing.Size(376, 101);
            this.ViewEventBtn.TabIndex = 6;
            this.ViewEventBtn.Text = "Ongoing Events";
            this.ViewEventBtn.UseVisualStyleBackColor = false;
            this.ViewEventBtn.Click += new System.EventHandler(this.ViewEventBtn_Click);
            // 
            // AddEventBtn
            // 
            this.AddEventBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.AddEventBtn.FlatAppearance.BorderSize = 0;
            this.AddEventBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AddEventBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddEventBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.AddEventBtn.Location = new System.Drawing.Point(104, 264);
            this.AddEventBtn.Name = "AddEventBtn";
            this.AddEventBtn.Size = new System.Drawing.Size(376, 101);
            this.AddEventBtn.TabIndex = 7;
            this.AddEventBtn.Text = "Add Event";
            this.AddEventBtn.UseVisualStyleBackColor = false;
            this.AddEventBtn.Click += new System.EventHandler(this.AddEventBtn_Click);
            // 
            // EventLogbtn
            // 
            this.EventLogbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.EventLogbtn.FlatAppearance.BorderSize = 0;
            this.EventLogbtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EventLogbtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EventLogbtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.EventLogbtn.Location = new System.Drawing.Point(570, 73);
            this.EventLogbtn.Name = "EventLogbtn";
            this.EventLogbtn.Size = new System.Drawing.Size(376, 101);
            this.EventLogbtn.TabIndex = 8;
            this.EventLogbtn.Text = "Event Log";
            this.EventLogbtn.UseVisualStyleBackColor = false;
            this.EventLogbtn.Click += new System.EventHandler(this.EventLogbtn_Click);
            // 
            // ManageParticipantsBtn
            // 
            this.ManageParticipantsBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(105)))), ((int)(((byte)(115)))));
            this.ManageParticipantsBtn.FlatAppearance.BorderSize = 0;
            this.ManageParticipantsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ManageParticipantsBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ManageParticipantsBtn.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.ManageParticipantsBtn.Location = new System.Drawing.Point(570, 264);
            this.ManageParticipantsBtn.Name = "ManageParticipantsBtn";
            this.ManageParticipantsBtn.Size = new System.Drawing.Size(376, 101);
            this.ManageParticipantsBtn.TabIndex = 9;
            this.ManageParticipantsBtn.Text = "Manage Participants";
            this.ManageParticipantsBtn.UseVisualStyleBackColor = false;
            this.ManageParticipantsBtn.Click += new System.EventHandler(this.ManageParticipantsBtn_Click);
            // 
            // AdminEventsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.ManageParticipantsBtn);
            this.Controls.Add(this.EventLogbtn);
            this.Controls.Add(this.AddEventBtn);
            this.Controls.Add(this.ViewEventBtn);
            this.Name = "AdminEventsControl";
            this.Size = new System.Drawing.Size(1053, 627);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ViewEventBtn;
        private System.Windows.Forms.Button AddEventBtn;
        private System.Windows.Forms.Button EventLogbtn;
        private System.Windows.Forms.Button ManageParticipantsBtn;
    }
}
