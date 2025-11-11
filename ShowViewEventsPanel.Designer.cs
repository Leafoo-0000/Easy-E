namespace EasyEv3
{
    partial class ShowViewEventsPanel
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
            this.dgvOngoingEvents = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.EditEventBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOngoingEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOngoingEvents
            // 
            this.dgvOngoingEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOngoingEvents.Location = new System.Drawing.Point(56, 68);
            this.dgvOngoingEvents.Name = "dgvOngoingEvents";
            this.dgvOngoingEvents.RowHeadersWidth = 51;
            this.dgvOngoingEvents.RowTemplate.Height = 24;
            this.dgvOngoingEvents.Size = new System.Drawing.Size(836, 484);
            this.dgvOngoingEvents.TabIndex = 0;
            this.dgvOngoingEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOngoingEvents_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(730, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(156, 22);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(51, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ongoing Events";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(892, 35);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // EditEventBtn
            // 
            this.EditEventBtn.Location = new System.Drawing.Point(898, 211);
            this.EditEventBtn.Name = "EditEventBtn";
            this.EditEventBtn.Size = new System.Drawing.Size(106, 155);
            this.EditEventBtn.TabIndex = 8;
            this.EditEventBtn.Text = "Edit ";
            this.EditEventBtn.UseVisualStyleBackColor = true;
            this.EditEventBtn.Click += new System.EventHandler(this.EditEventBtn_Click);
            // 
            // ShowViewEventsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.EditEventBtn);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvOngoingEvents);
            this.Name = "ShowViewEventsPanel";
            this.Size = new System.Drawing.Size(1053, 627);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOngoingEvents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOngoingEvents;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button EditEventBtn;
    }
}
