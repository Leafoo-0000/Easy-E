namespace EasyEv3
{
    partial class ManageParticipantsPanel
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
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvParticipants = new System.Windows.Forms.DataGridView();
            this.btnAddParticipant = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.AssignToEventBtn = new System.Windows.Forms.Button();
            this.EditParticipantbtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(79, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 28);
            this.label1.TabIndex = 6;
            this.label1.Text = "Manage Participants";
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(570, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(156, 22);
            this.txtSearch.TabIndex = 7;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(756, 46);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dgvParticipants
            // 
            this.dgvParticipants.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParticipants.Location = new System.Drawing.Point(84, 74);
            this.dgvParticipants.Name = "dgvParticipants";
            this.dgvParticipants.RowHeadersWidth = 51;
            this.dgvParticipants.RowTemplate.Height = 24;
            this.dgvParticipants.Size = new System.Drawing.Size(747, 401);
            this.dgvParticipants.TabIndex = 9;
            this.dgvParticipants.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvParticipants_CellContentClick);
            // 
            // btnAddParticipant
            // 
            this.btnAddParticipant.Location = new System.Drawing.Point(857, 74);
            this.btnAddParticipant.Name = "btnAddParticipant";
            this.btnAddParticipant.Size = new System.Drawing.Size(120, 141);
            this.btnAddParticipant.TabIndex = 10;
            this.btnAddParticipant.Text = "+ Add Participant";
            this.btnAddParticipant.UseVisualStyleBackColor = true;
            this.btnAddParticipant.Click += new System.EventHandler(this.btnAddParticipant_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(857, 408);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(120, 67);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // AssignToEventBtn
            // 
            this.AssignToEventBtn.Location = new System.Drawing.Point(857, 293);
            this.AssignToEventBtn.Name = "AssignToEventBtn";
            this.AssignToEventBtn.Size = new System.Drawing.Size(120, 109);
            this.AssignToEventBtn.TabIndex = 12;
            this.AssignToEventBtn.Text = "Assign to event";
            this.AssignToEventBtn.UseVisualStyleBackColor = true;
            this.AssignToEventBtn.Click += new System.EventHandler(this.AssignToEventBtn_Click);
            // 
            // EditParticipantbtn
            // 
            this.EditParticipantbtn.Location = new System.Drawing.Point(857, 221);
            this.EditParticipantbtn.Name = "EditParticipantbtn";
            this.EditParticipantbtn.Size = new System.Drawing.Size(120, 68);
            this.EditParticipantbtn.TabIndex = 13;
            this.EditParticipantbtn.Text = "Edit Participant";
            this.EditParticipantbtn.UseVisualStyleBackColor = true;
            this.EditParticipantbtn.Click += new System.EventHandler(this.EditParticipantbtn_Click);
            // 
            // ManageParticipantsPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.EditParticipantbtn);
            this.Controls.Add(this.AssignToEventBtn);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnAddParticipant);
            this.Controls.Add(this.dgvParticipants);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Name = "ManageParticipantsPanel";
            this.Size = new System.Drawing.Size(1053, 627);
            this.Load += new System.EventHandler(this.ManageParticipantsPanel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParticipants)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvParticipants;
        private System.Windows.Forms.Button btnAddParticipant;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button AssignToEventBtn;
        private System.Windows.Forms.Button EditParticipantbtn;
    }
}
