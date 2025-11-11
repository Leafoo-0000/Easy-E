namespace EasyEv3
{
    partial class LoginScreen
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.LoginBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Username = new System.Windows.Forms.Label();
            this.PasswordTxtBx = new System.Windows.Forms.TextBox();
            this.UsernameTxtBx = new System.Windows.Forms.TextBox();
            this.Logo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SignUp = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(56)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.SignUp);
            this.panel1.Controls.Add(this.LoginBtn);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.Username);
            this.panel1.Controls.Add(this.PasswordTxtBx);
            this.panel1.Controls.Add(this.UsernameTxtBx);
            this.panel1.Location = new System.Drawing.Point(656, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(516, 382);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // LoginBtn
            // 
            this.LoginBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.LoginBtn.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoginBtn.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.LoginBtn.Location = new System.Drawing.Point(165, 240);
            this.LoginBtn.Name = "LoginBtn";
            this.LoginBtn.Size = new System.Drawing.Size(186, 81);
            this.LoginBtn.TabIndex = 4;
            this.LoginBtn.Text = "Login";
            this.LoginBtn.UseVisualStyleBackColor = false;
            this.LoginBtn.Click += new System.EventHandler(this.LoginBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(112, 169);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Password";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Username.Location = new System.Drawing.Point(112, 86);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(70, 16);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            // 
            // PasswordTxtBx
            // 
            this.PasswordTxtBx.Location = new System.Drawing.Point(115, 189);
            this.PasswordTxtBx.Name = "PasswordTxtBx";
            this.PasswordTxtBx.Size = new System.Drawing.Size(300, 22);
            this.PasswordTxtBx.TabIndex = 1;
            this.PasswordTxtBx.TextChanged += new System.EventHandler(this.PasswordTxtBx_TextChanged);
            // 
            // UsernameTxtBx
            // 
            this.UsernameTxtBx.Location = new System.Drawing.Point(115, 105);
            this.UsernameTxtBx.Name = "UsernameTxtBx";
            this.UsernameTxtBx.Size = new System.Drawing.Size(300, 22);
            this.UsernameTxtBx.TabIndex = 0;
            this.UsernameTxtBx.TextChanged += new System.EventHandler(this.UsernameTxtBx_TextChanged_1);
            // 
            // Logo
            // 
            this.Logo.AutoSize = true;
            this.Logo.Font = new System.Drawing.Font("Unispace", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logo.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Logo.Location = new System.Drawing.Point(110, 172);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(425, 144);
            this.Logo.TabIndex = 1;
            this.Logo.Text = "EasyE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.Location = new System.Drawing.Point(662, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sign In";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label3.Location = new System.Drawing.Point(129, 323);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(389, 28);
            this.label3.TabIndex = 3;
            this.label3.Text = "Efficient Event Management, Simplified";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // SignUp
            // 
            this.SignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.SignUp.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUp.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.SignUp.Location = new System.Drawing.Point(196, 327);
            this.SignUp.Name = "SignUp";
            this.SignUp.Size = new System.Drawing.Size(125, 41);
            this.SignUp.TabIndex = 5;
            this.SignUp.Text = "Sign up";
            this.SignUp.UseVisualStyleBackColor = false;
            this.SignUp.Click += new System.EventHandler(this.SignUp_Click);
            // 
            // LoginScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1306, 580);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Logo);
            this.Controls.Add(this.panel1);
            this.Name = "LoginScreen";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Logo;
        private System.Windows.Forms.TextBox UsernameTxtBx;
        private System.Windows.Forms.TextBox PasswordTxtBx;
        private System.Windows.Forms.Button LoginBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SignUp;
    }
}

