namespace EasyEv3
{
    partial class ShowAddEventPanel
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
            this.txtAddTitle = new System.Windows.Forms.TextBox();
            this.rtbAddDescription = new System.Windows.Forms.RichTextBox();
            this.dtpAddStart = new System.Windows.Forms.DateTimePicker();
            this.dtpAddEnd = new System.Windows.Forms.DateTimePicker();
            this.comboAddLocation = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSaveEvent = new System.Windows.Forms.Button();
            this.txtNewLocation = new System.Windows.Forms.TextBox();
            this.dgvEventParticipants = new System.Windows.Forms.DataGridView();
            this.btnAddParticipantToEvent = new System.Windows.Forms.Button();
            this.btnRemoveParticipantFromEvent = new System.Windows.Forms.Button();
            this.txtSearchParticipants = new System.Windows.Forms.TextBox();
            this.tnSearchParticipants = new System.Windows.Forms.Button();
            this.btnScanQR = new System.Windows.Forms.Button();
            this.txtQRInput = new System.Windows.Forms.TextBox();
            this.lblScanStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAddTitle
            // 
            this.txtAddTitle.Location = new System.Drawing.Point(70, 79);
            this.txtAddTitle.Name = "txtAddTitle";
            this.txtAddTitle.Size = new System.Drawing.Size(358, 22);
            this.txtAddTitle.TabIndex = 0;
            // 
            // rtbAddDescription
            // 
            this.rtbAddDescription.Location = new System.Drawing.Point(70, 146);
            this.rtbAddDescription.Name = "rtbAddDescription";
            this.rtbAddDescription.Size = new System.Drawing.Size(358, 93);
            this.rtbAddDescription.TabIndex = 2;
            this.rtbAddDescription.Text = "";
          
            // 
            // dtpAddStart
            // 
            this.dtpAddStart.Location = new System.Drawing.Point(194, 247);
            this.dtpAddStart.Name = "dtpAddStart";
            this.dtpAddStart.Size = new System.Drawing.Size(200, 22);
            this.dtpAddStart.TabIndex = 3;
            // 
            // dtpAddEnd
            // 
            this.dtpAddEnd.Location = new System.Drawing.Point(194, 282);
            this.dtpAddEnd.Name = "dtpAddEnd";
            this.dtpAddEnd.Size = new System.Drawing.Size(200, 22);
            this.dtpAddEnd.TabIndex = 4;
            // 
            // comboAddLocation
            // 
            this.comboAddLocation.FormattingEnabled = true;
            this.comboAddLocation.Location = new System.Drawing.Point(70, 389);
            this.comboAddLocation.Name = "comboAddLocation";
            this.comboAddLocation.Size = new System.Drawing.Size(121, 24);
            this.comboAddLocation.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(65, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Event Title";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(65, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "Description";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(69, 242);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 28);
            this.label3.TabIndex = 9;
            this.label3.Text = "Start Date";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label4.Location = new System.Drawing.Point(72, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 28);
            this.label4.TabIndex = 10;
            this.label4.Text = "End Date";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.Location = new System.Drawing.Point(65, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(238, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Enter or Select Location";
            // 
            // btnSaveEvent
            // 
            this.btnSaveEvent.Location = new System.Drawing.Point(70, 428);
            this.btnSaveEvent.Name = "btnSaveEvent";
            this.btnSaveEvent.Size = new System.Drawing.Size(199, 77);
            this.btnSaveEvent.TabIndex = 12;
            this.btnSaveEvent.Text = "SAVE";
            this.btnSaveEvent.UseVisualStyleBackColor = true;
            this.btnSaveEvent.Click += new System.EventHandler(this.btnSaveEvent_Click);
            // 
            // txtNewLocation
            // 
            this.txtNewLocation.Location = new System.Drawing.Point(70, 361);
            this.txtNewLocation.Name = "txtNewLocation";
            this.txtNewLocation.Size = new System.Drawing.Size(100, 22);
            this.txtNewLocation.TabIndex = 13;
            // 
            // dgvEventParticipants
            // 
            this.dgvEventParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEventParticipants.Location = new System.Drawing.Point(522, 115);
            this.dgvEventParticipants.Name = "dgvEventParticipants";
            this.dgvEventParticipants.RowHeadersWidth = 51;
            this.dgvEventParticipants.RowTemplate.Height = 24;
            this.dgvEventParticipants.Size = new System.Drawing.Size(432, 198);
            this.dgvEventParticipants.TabIndex = 14;
            // 
            // btnAddParticipantToEvent
            // 
            this.btnAddParticipantToEvent.Location = new System.Drawing.Point(522, 330);
            this.btnAddParticipantToEvent.Name = "btnAddParticipantToEvent";
            this.btnAddParticipantToEvent.Size = new System.Drawing.Size(199, 77);
            this.btnAddParticipantToEvent.TabIndex = 15;
            this.btnAddParticipantToEvent.Text = "+ Add Participant";
            this.btnAddParticipantToEvent.UseVisualStyleBackColor = true;
            this.btnAddParticipantToEvent.Click += new System.EventHandler(this.btnAddParticipantToEvent_Click);
            // 
            // btnRemoveParticipantFromEvent
            // 
            this.btnRemoveParticipantFromEvent.Location = new System.Drawing.Point(755, 330);
            this.btnRemoveParticipantFromEvent.Name = "btnRemoveParticipantFromEvent";
            this.btnRemoveParticipantFromEvent.Size = new System.Drawing.Size(199, 77);
            this.btnRemoveParticipantFromEvent.TabIndex = 16;
            this.btnRemoveParticipantFromEvent.Text = "- Remove Participant";
            this.btnRemoveParticipantFromEvent.UseVisualStyleBackColor = true;
            this.btnRemoveParticipantFromEvent.Click += new System.EventHandler(this.btnRemoveParticipantFromEvent_Click);
            // 
            // txtSearchParticipants
            // 
            this.txtSearchParticipants.Location = new System.Drawing.Point(631, 79);
            this.txtSearchParticipants.Name = "txtSearchParticipants";
            this.txtSearchParticipants.Size = new System.Drawing.Size(242, 22);
            this.txtSearchParticipants.TabIndex = 17;
            // 
            // tnSearchParticipants
            // 
            this.tnSearchParticipants.Location = new System.Drawing.Point(879, 78);
            this.tnSearchParticipants.Name = "tnSearchParticipants";
            this.tnSearchParticipants.Size = new System.Drawing.Size(75, 23);
            this.tnSearchParticipants.TabIndex = 18;
            this.tnSearchParticipants.Text = "Search";
            this.tnSearchParticipants.UseVisualStyleBackColor = true;
            // 
            // btnScanQR
            // 
            this.btnScanQR.Location = new System.Drawing.Point(522, 457);
            this.btnScanQR.Name = "btnScanQR";
            this.btnScanQR.Size = new System.Drawing.Size(199, 48);
            this.btnScanQR.TabIndex = 19;
            this.btnScanQR.Text = "Add with QR";
            this.btnScanQR.UseVisualStyleBackColor = true;
            this.btnScanQR.Click += new System.EventHandler(this.btnScanQR_Click);
            // 
            // txtQRInput
            // 
            this.txtQRInput.Location = new System.Drawing.Point(744, 470);
            this.txtQRInput.Name = "txtQRInput";
            this.txtQRInput.Size = new System.Drawing.Size(199, 22);
            this.txtQRInput.TabIndex = 20;
            this.txtQRInput.TextChanged += new System.EventHandler(this.txtQRInput_TextChanged);
            // 
            // lblScanStatus
            // 
            this.lblScanStatus.AutoSize = true;
            this.lblScanStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScanStatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblScanStatus.Location = new System.Drawing.Point(786, 495);
            this.lblScanStatus.Name = "lblScanStatus";
            this.lblScanStatus.Size = new System.Drawing.Size(0, 28);
            this.lblScanStatus.TabIndex = 21;
            // 
            // ShowAddEventPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblScanStatus);
            this.Controls.Add(this.txtQRInput);
            this.Controls.Add(this.btnScanQR);
            this.Controls.Add(this.tnSearchParticipants);
            this.Controls.Add(this.txtSearchParticipants);
            this.Controls.Add(this.btnRemoveParticipantFromEvent);
            this.Controls.Add(this.btnAddParticipantToEvent);
            this.Controls.Add(this.dgvEventParticipants);
            this.Controls.Add(this.txtNewLocation);
            this.Controls.Add(this.btnSaveEvent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboAddLocation);
            this.Controls.Add(this.dtpAddEnd);
            this.Controls.Add(this.dtpAddStart);
            this.Controls.Add(this.rtbAddDescription);
            this.Controls.Add(this.txtAddTitle);
            this.Name = "ShowAddEventPanel";
            this.Size = new System.Drawing.Size(1053, 627);
      
            ((System.ComponentModel.ISupportInitialize)(this.dgvEventParticipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddTitle;
        private System.Windows.Forms.RichTextBox rtbAddDescription;
        private System.Windows.Forms.DateTimePicker dtpAddStart;
        private System.Windows.Forms.DateTimePicker dtpAddEnd;
        private System.Windows.Forms.ComboBox comboAddLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSaveEvent;
        private System.Windows.Forms.TextBox txtNewLocation;
        private System.Windows.Forms.DataGridView dgvEventParticipants;
        private System.Windows.Forms.Button btnAddParticipantToEvent;
        private System.Windows.Forms.Button btnRemoveParticipantFromEvent;
        private System.Windows.Forms.TextBox txtSearchParticipants;
        private System.Windows.Forms.Button tnSearchParticipants;
        private System.Windows.Forms.Button btnScanQR;
        private System.Windows.Forms.TextBox txtQRInput;
        private System.Windows.Forms.Label lblScanStatus;
    }
}
