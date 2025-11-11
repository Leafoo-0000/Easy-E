using System;
using System.Drawing;
using System.Windows.Forms;

namespace EasyEv3
{
    /// <summary>
    /// Simple working UserControl for testing
    /// </summary>
    public partial class SimpleControl : UserControl
    {
        private Label lbl;

        /// <summary>
        /// Initializes a new instance of the SimpleControl class
        /// </summary>
        public SimpleControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Required method for Designer support - do not modify the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lbl.ForeColor = System.Drawing.Color.White;
            this.lbl.Location = new System.Drawing.Point(50, 50);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(306, 37);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "Simple Control Works!";
            // 
            // SimpleControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.Controls.Add(this.lbl);
            this.Name = "SimpleControl";
            this.Size = new System.Drawing.Size(1460, 625);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
