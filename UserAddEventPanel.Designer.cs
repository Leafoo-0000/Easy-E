namespace EasyEv3
{
    partial class UserAddEventPanel
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbAddDescription = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpAddStart = new System.Windows.Forms.DateTimePicker();
            this.dtpAddEnd = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewLocation = new System.Windows.Forms.TextBox();
            this.comboAddLocation = new System.Windows.Forms.ComboBox();
            this.btnSaveEvent = new System.Windows.Forms.Button();
            this.QrADDbtn = new System.Windows.Forms.Button();
            this.Qrtxt = new System.Windows.Forms.TextBox();
            this.QrStatusTxt = new System.Windows.Forms.Label();
            this.dgvEventParticipants = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(67, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Event Title";
            // 
            // txtAddTitle
            // 
            this.txtAddTitle.Location = new System.Drawing.Point(72, 76);
            this.txtAddTitle.Name = "txtAddTitle";
            this.txtAddTitle.Size = new System.Drawing.Size(358, 22);
            this.txtAddTitle.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(67, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 28);
            this.label2.TabIndex = 10;
            this.label2.Text = "Description";
            // 
            // rtbAddDescription
            // 
            this.rtbAddDescription.Location = new System.Drawing.Point(72, 145);
            this.rtbAddDescription.Name = "rtbAddDescription";
            this.rtbAddDescription.Size = new System.Drawing.Size(358, 93);
            this.rtbAddDescription.TabIndex = 11;
            this.rtbAddDescription.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(67, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 28);
            this.label3.TabIndex = 12;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(67, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "End Date";
            // 
            // dtpAddStart
            // 
            this.dtpAddStart.Location = new System.Drawing.Point(230, 260);
            this.dtpAddStart.Name = "dtpAddStart";
            this.dtpAddStart.Size = new System.Drawing.Size(200, 22);
            this.dtpAddStart.TabIndex = 14;
            // 
            // dtpAddEnd
            // 
            this.dtpAddEnd.Location = new System.Drawing.Point(230, 305);
            this.dtpAddEnd.Name = "dtpAddEnd";
            this.dtpAddEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpAddEnd.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(67, 349);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 28);
            this.label5.TabIndex = 16;
            this.label5.Text = "Enter or Select Location";
            // 
            // txtNewLocation
            // 
            this.txtNewLocation.Location = new System.Drawing.Point(72, 380);
            this.txtNewLocation.Name = "txtNewLocation";
            this.txtNewLocation.Size = new System.Drawing.Size(100, 22);
            this.txtNewLocation.TabIndex = 17;
            // 
            // comboAddLocation
            // 
            this.comboAddLocation.FormattingEnabled = true;
            this.comboAddLocation.Location = new System.Drawing.Point(72, 408);
            this.comboAddLocation.Name = "comboAddLocation";
            this.comboAddLocation.Size = new System.Drawing.Size(121, 24);
            this.comboAddLocation.TabIndex = 18;
            this.comboAddLocation.SelectedIndexChanged += new System.EventHandler(this.comboAddLocation_SelectedIndexChanged);
            // 
            // btnSaveEvent
            // 
            this.btnSaveEvent.Location = new System.Drawing.Point(72, 438);
            this.btnSaveEvent.Name = "btnSaveEvent";
            this.btnSaveEvent.Size = new System.Drawing.Size(199, 77);
            this.btnSaveEvent.TabIndex = 19;
            this.btnSaveEvent.Text = "SAVE";
            this.btnSaveEvent.UseVisualStyleBackColor = true;
            this.btnSaveEvent.Click += new System.EventHandler(this.btnSaveEvent_Click);
            // 
            // QrADDbtn
            // 
            this.QrADDbtn.Location = new System.Drawing.Point(577, 76);
            this.QrADDbtn.Name = "QrADDbtn";
            this.QrADDbtn.Size = new System.Drawing.Size(199, 77);
            this.QrADDbtn.TabIndex = 20;
            this.QrADDbtn.Text = "Attendance with QR";
            this.QrADDbtn.UseVisualStyleBackColor = true;
            this.QrADDbtn.Click += new System.EventHandler(this.QrADDbtn_Click);
            // 
            // Qrtxt
            // 
            this.Qrtxt.Location = new System.Drawing.Point(577, 159);
            this.Qrtxt.Name = "Qrtxt";
            this.Qrtxt.Size = new System.Drawing.Size(358, 22);
            this.Qrtxt.TabIndex = 21;
            this.Qrtxt.TextChanged += new System.EventHandler(this.Qrtxt_TextChanged);
            // 
            // QrStatusTxt
            // 
            this.QrStatusTxt.AutoSize = true;
            this.QrStatusTxt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QrStatusTxt.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.QrStatusTxt.Location = new System.Drawing.Point(572, 184);
            this.QrStatusTxt.Name = "QrStatusTxt";
            this.QrStatusTxt.Size = new System.Drawing.Size(238, 28);
            this.QrStatusTxt.TabIndex = 22;
            this.QrStatusTxt.Text = "Enter or Select Location";
            // 
            // dgvEventParticipants
            // 
            this.dgvEventParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventParticipants.Location = new System.Drawing.Point(577, 215);
            this.dgvEventParticipants.Name = "dgvEventParticipants";
            this.dgvEventParticipants.RowHeadersWidth = 51;
            this.dgvEventParticipants.RowTemplate.Height = 24;
            this.dgvEventParticipants.Size = new System.Drawing.Size(395, 300);
            this.dgvEventParticipants.TabIndex = 23;
            this.dgvEventParticipants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEventParticipants_CellContentClick);
            // 
            // UserAddEventPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.dgvEventParticipants);
            this.Controls.Add(this.QrStatusTxt);
            this.Controls.Add(this.Qrtxt);
            this.Controls.Add(this.QrADDbtn);
            this.Controls.Add(this.btnSaveEvent);
            this.Controls.Add(this.comboAddLocation);
            this.Controls.Add(this.txtNewLocation);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtpAddEnd);
            this.Controls.Add(this.dtpAddStart);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.rtbAddDescription);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAddTitle);
            this.Controls.Add(this.label1);
            this.Name = "UserAddEventPanel";
            this.Size = new System.Drawing.Size(1053, 627);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventParticipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAddTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbAddDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpAddStart;
        private System.Windows.Forms.DateTimePicker dtpAddEnd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewLocation;
        private System.Windows.Forms.ComboBox comboAddLocation;
        private System.Windows.Forms.Button btnSaveEvent;
        private System.Windows.Forms.Button QrADDbtn;
        private System.Windows.Forms.TextBox Qrtxt;
        private System.Windows.Forms.Label QrStatusTxt;
        private System.Windows.Forms.DataGridView dgvEventParticipants;
    }
}
