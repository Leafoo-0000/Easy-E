using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyEv3
{
    /// <summary>
    /// Minimal Dashboard UserControl for testing
    /// </summary>
    public partial class MinimalDashboardControl : UserControl
    {
        private Label lblTitle;

        /// <summary>
        /// Initializes a new instance of the MinimalDashboardControl class
        /// </summary>
        public MinimalDashboardControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(335, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Minimal Dashboard";
            // 
            // MinimalDashboardControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblTitle);
            this.Name = "MinimalDashboardControl";
            this.Size = new System.Drawing.Size(1460, 571);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
