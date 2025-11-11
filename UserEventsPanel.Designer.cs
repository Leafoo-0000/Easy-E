namespace EasyEv3
{
    partial class UserEventsPanel
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
            this.PendingEvReq = new System.Windows.Forms.DataGridView();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCreateEvent = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.EditEventBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PendingEvReq)).BeginInit();
            this.SuspendLayout();
            // 
            // PendingEvReq
            // 
            this.PendingEvReq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PendingEvReq.Location = new System.Drawing.Point(57, 91);
            this.PendingEvReq.Name = "PendingEvReq";
            this.PendingEvReq.RowHeadersWidth = 51;
            this.PendingEvReq.RowTemplate.Height = 24;
            this.PendingEvReq.Size = new System.Drawing.Size(661, 412);
            this.PendingEvReq.TabIndex = 7;
            this.PendingEvReq.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.PendingEvReq_CellContentClick);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(305, 63);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(57, 63);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(242, 22);
            this.txtSearch.TabIndex = 20;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(386, 63);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.Text = "Search";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCreateEvent
            // 
            this.btnCreateEvent.Location = new System.Drawing.Point(790, 137);
            this.btnCreateEvent.Name = "btnCreateEvent";
            this.btnCreateEvent.Size = new System.Drawing.Size(175, 136);
            this.btnCreateEvent.TabIndex = 22;
            this.btnCreateEvent.Text = "Create Event";
            this.btnCreateEvent.UseVisualStyleBackColor = true;
            this.btnCreateEvent.Click += new System.EventHandler(this.btnCreateEvent_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(17, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 28);
            this.label2.TabIndex = 24;
            this.label2.Text = "My Events";
            // 
            // EditEventBtn
            // 
            this.EditEventBtn.Location = new System.Drawing.Point(790, 316);
            this.EditEventBtn.Name = "EditEventBtn";
            this.EditEventBtn.Size = new System.Drawing.Size(175, 136);
            this.EditEventBtn.TabIndex = 25;
            this.EditEventBtn.Text = "Edit Event";
            this.EditEventBtn.UseVisualStyleBackColor = true;
            this.EditEventBtn.Click += new System.EventHandler(this.EditEventBtn_Click);
            // 
            // UserEventsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.EditEventBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCreateEvent);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.PendingEvReq);
            this.Name = "UserEventsPanel";
            this.Size = new System.Drawing.Size(1053, 627);
            ((System.ComponentModel.ISupportInitialize)(this.PendingEvReq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView PendingEvReq;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCreateEvent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button EditEventBtn;
    }
}
