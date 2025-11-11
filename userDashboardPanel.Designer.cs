namespace EasyEv3
{
    partial class userDashboardPanel
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
            this.label2 = new System.Windows.Forms.Label();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.PendingEvReq = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PendingEvReq)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(426, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "On-going events";
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(75, 59);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowHeadersWidth = 51;
            this.dgvEvents.RowTemplate.Height = 24;
            this.dgvEvents.Size = new System.Drawing.Size(886, 223);
            this.dgvEvents.TabIndex = 5;
            this.dgvEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellContentClick);
            // 
            // PendingEvReq
            // 
            this.PendingEvReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PendingEvReq.Location = new System.Drawing.Point(75, 338);
            this.PendingEvReq.Name = "PendingEvReq";
            this.PendingEvReq.RowHeadersWidth = 51;
            this.PendingEvReq.RowTemplate.Height = 24;
            this.PendingEvReq.Size = new System.Drawing.Size(886, 225);
            this.PendingEvReq.TabIndex = 6;
            this.PendingEvReq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PendingEvReq_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(446, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "My Events";
            // 
            // userDashboardPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PendingEvReq);
            this.Controls.Add(this.dgvEvents);
            this.Controls.Add(this.label2);
            this.Name = "userDashboardPanel";
            this.Size = new System.Drawing.Size(1053, 627);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PendingEvReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvEvents;
        private System.Windows.Forms.DataGridView PendingEvReq;
        private System.Windows.Forms.Label label1;
    }
}
