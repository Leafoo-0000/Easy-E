using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyEv3
{
    /// <summary>
    /// Simple test UserControl to verify navigation is working
    /// </summary>
    public partial class TestControl : UserControl
    {
        private System.Windows.Forms.Label lblTest;

        /// <summary>
        /// Initializes a new instance of the TestControl class
        /// </summary>
        public TestControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTest = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblTest
            // 
            this.lblTest.AutoSize = true;
            this.lblTest.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTest.ForeColor = System.Drawing.Color.White;
            this.lblTest.Location = new System.Drawing.Point(50, 50);
            this.lblTest.Name = "lblTest";
            this.lblTest.Size = new System.Drawing.Size(335, 46);
            this.lblTest.TabIndex = 0;
            this.lblTest.Text = "Test Control Works!";
            // 
            // TestControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lblTest);
            this.Name = "TestControl";
            this.Size = new System.Drawing.Size(1460, 625);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
