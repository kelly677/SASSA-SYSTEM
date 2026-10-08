using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class ForgotPasswordForm : Form
    {
        private string generatedOtp = "";
        private string targetEmail = "";
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private void btnSentOTP_Click(object sender, EventArgs e)
        {

            targetEmail = txtEmail.Text.Trim();

            if (string.IsNullOrWhiteSpace(targetEmail) || !targetEmail.Contains("@"))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check email exists in Beneficiaries.txt (email is field index 4)
            bool found = false;

            if (File.Exists("Beneficiaries.txt"))
            {
                foreach (string line in File.ReadAllLines("Beneficiaries.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length < 7) continue;

                    if (parts[4].ToLower() == targetEmail.ToLower())
                    {
                        found = true;
                        break;
                    }
                }
            }

            if (!found)
            {
                MessageBox.Show("No account found with that email.", "Not Found",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate 6-digit OTP
            Random rnd = new Random();
            generatedOtp = rnd.Next(100000, 999999).ToString();

            MessageBox.Show("SASSA OTP\n\nYour OTP is: " + generatedOtp +
                            "\n\n(In a real system this would be sent via email/SMS)",
                            "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reveal step 2, keep step 1 visible (email box stays so user remembers)
            txtOTP.Visible = true;
            btnConfirmOTP.Visible = true;
        }

        private void btnConfirmOTP_Click(object sender, EventArgs e)
        {
            if (generatedOtp == "")
            {
                MessageBox.Show("Please click Send OTP first.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtOTP.Text.Trim() != generatedOtp)
            {
                MessageBox.Show("Incorrect OTP. Please try again.", "Verification Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("OTP verified. Please choose a new password.", "Verified",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reveal step 3
            txtNewpasword.Visible = true;
            btnSavePassword.Visible = true;

            // Hide earlier steps
            txtEmail.Visible = false;
            btnSentOTP.Visible = false;
            txtOTP.Visible = false;
            btnConfirmOTP.Visible = false;
        }

        private void btnSavePassword_Click(object sender, EventArgs e)
        {
            string newPassword = txtNewpasword.Text.Trim();

            if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
            {
                MessageBox.Show("New password must be at least 6 characters.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string[] lines = File.ReadAllLines("Beneficiaries.txt");

            for (int i = 0; i < lines.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(lines[i])) continue;
                string[] parts = lines[i].Split('|');
                if (parts.Length < 7) continue;

                if (parts[4].ToLower() == targetEmail.ToLower())
                {
                    parts[6] = newPassword;   // password field
                    lines[i] = string.Join("|", parts);
                    break;
                }
            }

            File.WriteAllLines("Beneficiaries.txt", lines);

            MessageBox.Show("Password reset successfully. You can now log in.",
                            "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            txtEmail.Visible = true;
            btnSentOTP.Visible = true;

            // Step 2 hidden
            txtOTP.Visible = false;
            btnConfirmOTP.Visible = false;

            // Step 3 hidden
            txtNewpasword.Visible = false;
            btnSavePassword.Visible = false;
        }
    }
}
