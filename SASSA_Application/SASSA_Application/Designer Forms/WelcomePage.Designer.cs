namespace SASSA_Application
{
    partial class frmWelcomePage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWelcomePage));
            pnlLeft = new Panel();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            pnlRight = new Panel();
            lblShowPassword = new Label();
            lblForgotPassword = new Label();
            lblPassword = new Label();
            lblUserID = new Label();
            txtPassword = new SASSA_Application.Classes.RoundedTextBox();
            txtUserName = new SASSA_Application.Classes.RoundedTextBox();
            label1 = new Label();
            lblWelcome = new Label();
            btnCreateAccount = new SASSA_Application.Classes.RoundedButton();
            btnLogin = new SASSA_Application.Classes.RoundedButton();
            pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            pnlRight.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLeft
            // 
            pnlLeft.BackColor = SystemColors.InactiveCaption;
            pnlLeft.Controls.Add(pictureBox2);
            pnlLeft.Controls.Add(pictureBox1);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(550, 653);
            pnlLeft.TabIndex = 0;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(44, 361);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(485, 199);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(44, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(485, 306);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(lblShowPassword);
            pnlRight.Controls.Add(lblForgotPassword);
            pnlRight.Controls.Add(lblPassword);
            pnlRight.Controls.Add(lblUserID);
            pnlRight.Controls.Add(txtPassword);
            pnlRight.Controls.Add(txtUserName);
            pnlRight.Controls.Add(label1);
            pnlRight.Controls.Add(lblWelcome);
            pnlRight.Controls.Add(btnCreateAccount);
            pnlRight.Controls.Add(btnLogin);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(550, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(532, 653);
            pnlRight.TabIndex = 1;
            // 
            // lblShowPassword
            // 
            lblShowPassword.AutoSize = true;
            lblShowPassword.ForeColor = Color.FromArgb(26, 70, 130);
            lblShowPassword.Location = new Point(407, 324);
            lblShowPassword.Name = "lblShowPassword";
            lblShowPassword.Size = new Size(66, 20);
            lblShowPassword.TabIndex = 30;
            lblShowPassword.Text = "👁️Show";
            // 
            // lblForgotPassword
            // 
            lblForgotPassword.AutoSize = true;
            lblForgotPassword.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblForgotPassword.ForeColor = Color.FromArgb(26, 70, 130);
            lblForgotPassword.Location = new Point(89, 507);
            lblForgotPassword.Name = "lblForgotPassword";
            lblForgotPassword.Size = new Size(130, 20);
            lblForgotPassword.TabIndex = 8;
            lblForgotPassword.Text = "Forgot password?";
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 10.4F, FontStyle.Bold);
            lblPassword.Location = new Point(89, 257);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(92, 25);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // lblUserID
            // 
            lblUserID.AutoSize = true;
            lblUserID.Font = new Font("Segoe UI", 10.4F, FontStyle.Bold);
            lblUserID.Location = new Point(89, 159);
            lblUserID.Name = "lblUserID";
            lblUserID.Size = new Size(198, 25);
            lblUserID.TabIndex = 6;
            lblUserID.Text = "Username/ID Number";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.Font = new Font("Segoe UI", 10F);
            txtPassword.Location = new Point(89, 298);
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter Password";
            txtPassword.Size = new Size(312, 46);
            txtPassword.TabIndex = 5;
            // 
            // txtUserName
            // 
            txtUserName.BackColor = Color.White;
            txtUserName.Font = new Font("Segoe UI", 10F);
            txtUserName.Location = new Point(89, 208);
            txtUserName.Name = "txtUserName";
            txtUserName.PlaceholderText = "Enter your ID Number";
            txtUserName.Size = new Size(312, 46);
            txtUserName.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(67, 110);
            label1.Name = "label1";
            label1.Size = new Size(392, 28);
            label1.TabIndex = 3;
            label1.Text = "Access your SASSA Queue Booking account";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(106, 29);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(295, 81);
            lblWelcome.TabIndex = 2;
            lblWelcome.Text = "Welcome";
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.BackColor = Color.FromArgb(26, 70, 130);
            btnCreateAccount.FlatAppearance.BorderSize = 0;
            btnCreateAccount.FlatStyle = FlatStyle.Flat;
            btnCreateAccount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateAccount.ForeColor = Color.White;
            btnCreateAccount.HoverColor = Color.Empty;
            btnCreateAccount.Location = new Point(67, 440);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.PressedColor = Color.Empty;
            btnCreateAccount.Size = new Size(443, 50);
            btnCreateAccount.TabIndex = 1;
            btnCreateAccount.Text = "Create a New Account";
            btnCreateAccount.UseVisualStyleBackColor = false;
            btnCreateAccount.Click += btnCreateAccount_Click;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.FromArgb(26, 70, 130);
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.HoverColor = Color.Empty;
            btnLogin.Location = new Point(67, 361);
            btnLogin.Name = "btnLogin";
            btnLogin.PressedColor = Color.Empty;
            btnLogin.Size = new Size(443, 50);
            btnLogin.TabIndex = 0;
            btnLogin.Text = "Login to My Account";
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // frmWelcomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1082, 653);
            Controls.Add(pnlRight);
            Controls.Add(pnlLeft);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmWelcomePage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Welcome Page";
            pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            pnlRight.ResumeLayout(false);
            pnlRight.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLeft;
        private Panel pnlRight;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label lblWelcome;
        private Classes.RoundedButton btnCreateAccount;
        private Classes.RoundedButton btnLogin;
        private Label label1;
        private Label lblUserID;
        private Classes.RoundedTextBox txtPassword;
        private Classes.RoundedTextBox txtUserName;
        private Label lblForgotPassword;
        private Label lblPassword;
        private Label lblShowPassword;
    }
}
