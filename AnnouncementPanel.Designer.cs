namespace EasyEv3
{
    partial class AnnouncementPanel
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
            this.AnnouncemnentDGV = new System.Windows.Forms.DataGridView();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.AnnoucnementTxtBox = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AnnouncemnentDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // AnnouncemnentDGV
            // 
            this.AnnouncemnentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AnnouncemnentDGV.Location = new System.Drawing.Point(60, 94);
            this.AnnouncemnentDGV.Name = "AnnouncemnentDGV";
            this.AnnouncemnentDGV.RowHeadersWidth = 51;
            this.AnnouncemnentDGV.RowTemplate.Height = 24;
            this.AnnouncemnentDGV.Size = new System.Drawing.Size(493, 386);
            this.AnnouncemnentDGV.TabIndex = 0;
            this.AnnouncemnentDGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.AnnouncemnentDGV_CellContentClick);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(60, 66);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(179, 22);
            this.txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(245, 65);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 19;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // AnnoucnementTxtBox
            // 
            this.AnnoucnementTxtBox.Location = new System.Drawing.Point(615, 101);
            this.AnnoucnementTxtBox.Name = "AnnoucnementTxtBox";
            this.AnnoucnementTxtBox.Size = new System.Drawing.Size(374, 247);
            this.AnnoucnementTxtBox.TabIndex = 20;
            this.AnnoucnementTxtBox.Text = "";
            this.AnnoucnementTxtBox.TextChanged += new System.EventHandler(this.AnnoucnementTxtBox_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(840, 354);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(149, 65);
            this.btnSend.TabIndex = 21;
            this.btnSend.Text = "Send Announcement";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 28);
            this.label2.TabIndex = 22;
            this.label2.Text = "Announcements";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(610, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 28);
            this.label1.TabIndex = 23;
            this.label1.Text = "New Announcement";
            // 
            // AnnouncementPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.AnnoucnementTxtBox);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.AnnouncemnentDGV);
            this.Name = "AnnouncementPanel";
            this.Size = new System.Drawing.Size(1053, 627);
            ((System.ComponentModel.ISupportInitialize)(this.AnnouncemnentDGV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView AnnouncemnentDGV;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox AnnoucnementTxtBox;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
