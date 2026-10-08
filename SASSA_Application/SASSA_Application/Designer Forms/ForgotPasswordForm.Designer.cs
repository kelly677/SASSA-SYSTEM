namespace SASSA_Application.Designer_Forms
{
    partial class ForgotPasswordForm
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
            label5 = new Label();
            label14 = new Label();
            btnSentOTP = new SASSA_Application.Classes.RoundedButton();
            txtEmail = new SASSA_Application.Classes.RoundedTextBox();
            label1 = new Label();
            txtOTP = new SASSA_Application.Classes.RoundedTextBox();
            lbl = new Label();
            txtNewpasword = new SASSA_Application.Classes.RoundedTextBox();
            btnConfirmOTP = new SASSA_Application.Classes.RoundedButton();
            btnSavePassword = new SASSA_Application.Classes.RoundedButton();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 19.9F, FontStyle.Bold);
            label5.Location = new Point(216, 23);
            label5.Name = "label5";
            label5.Size = new Size(288, 46);
            label5.TabIndex = 17;
            label5.Text = "Forgot Password";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label14.Location = new Point(12, 73);
            label14.Name = "label14";
            label14.Size = new Size(168, 28);
            label14.TabIndex = 20;
            label14.Text = "Enter Your Email";
            // 
            // btnSentOTP
            // 
            btnSentOTP.BackColor = Color.FromArgb(26, 70, 130);
            btnSentOTP.FlatAppearance.BorderSize = 0;
            btnSentOTP.FlatStyle = FlatStyle.Flat;
            btnSentOTP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSentOTP.ForeColor = Color.White;
            btnSentOTP.HoverColor = Color.Empty;
            btnSentOTP.Location = new Point(12, 190);
            btnSentOTP.Name = "btnSentOTP";
            btnSentOTP.PressedColor = Color.Empty;
            btnSentOTP.Size = new Size(188, 38);
            btnSentOTP.TabIndex = 19;
            btnSentOTP.Text = "Sent OTP";
            btnSentOTP.UseVisualStyleBackColor = false;
            btnSentOTP.Click += btnSentOTP_Click;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.White;
            txtEmail.Font = new Font("Segoe UI", 10F);
            txtEmail.Location = new Point(12, 126);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Email Address";
            txtEmail.Size = new Size(402, 44);
            txtEmail.TabIndex = 18;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(12, 249);
            label1.Name = "label1";
            label1.Size = new Size(142, 28);
            label1.TabIndex = 22;
            label1.Text = "Enter OTP Pin";
            // 
            // txtOTP
            // 
            txtOTP.BackColor = Color.White;
            txtOTP.Font = new Font("Segoe UI", 10F);
            txtOTP.Location = new Point(12, 293);
            txtOTP.Name = "txtOTP";
            txtOTP.PlaceholderText = "Enter OTP";
            txtOTP.Size = new Size(402, 44);
            txtOTP.TabIndex = 21;
            // 
            // lbl
            // 
            lbl.AutoSize = true;
            lbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbl.Location = new Point(12, 422);
            lbl.Name = "lbl";
            lbl.Size = new Size(254, 28);
            lbl.TabIndex = 24;
            lbl.Text = "Enter Your New Password";
            // 
            // txtNewpasword
            // 
            txtNewpasword.BackColor = Color.White;
            txtNewpasword.Font = new Font("Segoe UI", 10F);
            txtNewpasword.Location = new Point(12, 463);
            txtNewpasword.Name = "txtNewpasword";
            txtNewpasword.PlaceholderText = "New Password";
            txtNewpasword.Size = new Size(402, 44);
            txtNewpasword.TabIndex = 23;
            // 
            // btnConfirmOTP
            // 
            btnConfirmOTP.BackColor = Color.FromArgb(26, 70, 130);
            btnConfirmOTP.FlatAppearance.BorderSize = 0;
            btnConfirmOTP.FlatStyle = FlatStyle.Flat;
            btnConfirmOTP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnConfirmOTP.ForeColor = Color.White;
            btnConfirmOTP.HoverColor = Color.Empty;
            btnConfirmOTP.Location = new Point(12, 361);
            btnConfirmOTP.Name = "btnConfirmOTP";
            btnConfirmOTP.PressedColor = Color.Empty;
            btnConfirmOTP.Size = new Size(188, 38);
            btnConfirmOTP.TabIndex = 25;
            btnConfirmOTP.Text = "Confirm";
            btnConfirmOTP.UseVisualStyleBackColor = false;
            btnConfirmOTP.Click += btnConfirmOTP_Click;
            // 
            // btnSavePassword
            // 
            btnSavePassword.BackColor = Color.FromArgb(26, 70, 130);
            btnSavePassword.FlatAppearance.BorderSize = 0;
            btnSavePassword.FlatStyle = FlatStyle.Flat;
            btnSavePassword.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSavePassword.ForeColor = Color.White;
            btnSavePassword.HoverColor = Color.Empty;
            btnSavePassword.Location = new Point(12, 529);
            btnSavePassword.Name = "btnSavePassword";
            btnSavePassword.PressedColor = Color.Empty;
            btnSavePassword.Size = new Size(188, 38);
            btnSavePassword.TabIndex = 26;
            btnSavePassword.Text = "Save Password";
            btnSavePassword.UseVisualStyleBackColor = false;
            btnSavePassword.Click += btnSavePassword_Click;
            // 
            // ForgotPasswordForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientActiveCaption;
            ClientSize = new Size(731, 672);
            Controls.Add(btnSavePassword);
            Controls.Add(btnConfirmOTP);
            Controls.Add(lbl);
            Controls.Add(txtNewpasword);
            Controls.Add(label1);
            Controls.Add(txtOTP);
            Controls.Add(label14);
            Controls.Add(btnSentOTP);
            Controls.Add(txtEmail);
            Controls.Add(label5);
            Name = "ForgotPasswordForm";
            Text = "ForgotPasswordForm";
            Load += ForgotPasswordForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label14;
        private Classes.RoundedButton btnSentOTP;
        private Classes.RoundedTextBox txtEmail;
        private Label label1;
        private Classes.RoundedTextBox txtOTP;
        private Label lbl;
        private Classes.RoundedTextBox txtNewpasword;
        private Classes.RoundedButton btnConfirmOTP;
        private Classes.RoundedButton btnSavePassword;
    }
}