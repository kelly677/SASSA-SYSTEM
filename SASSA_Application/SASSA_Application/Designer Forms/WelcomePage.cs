using SASSA_Application.Designer_Forms;
using System.IO;

namespace SASSA_Application
{
    public partial class frmWelcomePage : Form
    {
        public frmWelcomePage()
        {
            InitializeComponent();
        }

        private void lblSlogan_Click(object sender, EventArgs e)
        {
        }

        private void btnCreateAccount_Click(object sender, EventArgs e)
        {
            Registration register = new Registration();
            register.FormClosed += (s, args) => this.Show();
            register.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string id = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter your ID and password.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ---- STAFF LOGIN (password is an email) ----
            if (password.Contains("@") && password.Contains("."))
            {
                if (File.Exists("Users.txt"))
                {
                    foreach (string line in File.ReadAllLines("Users.txt"))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('|');
                        if (parts.Length < 8) continue;

                        string savedStaffNumber = parts[3].Trim();
                        string savedEmail = parts[5].Trim();

                        if (savedStaffNumber.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase)
                            && savedEmail.Equals(password.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            string centre = parts[6].Trim();
                            MessageBox.Show("Welcome " + parts[0] + "!", "Staff Login",
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            StaffPortal staff = new StaffPortal();
                            staff.Show();
                            this.Hide();
                            return;
                        }
                    }
                }

                MessageBox.Show("Invalid staff number or email.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ---- ADMIN / BENEFICIARY LOGIN ----
            if (!File.Exists("Users.txt"))
            {
                MessageBox.Show("No accounts registered yet.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string[] lines = File.ReadAllLines("Users.txt");
            bool isAuthenticated = false;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split(new char[] { ',', '|' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length < 8) continue;

                string savedId = parts[2].Trim();
                string savedPassword = parts[7].Trim();

                if (savedId.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase)
                    && savedPassword == password.Trim())
                {
                    isAuthenticated = true;

                    if (savedPassword.Contains("Admin") || parts[3].StartsWith("STAFF", StringComparison.OrdinalIgnoreCase))
                    {
                        AdminPortal admin = new AdminPortal();
                        admin.Show();
                    }
                    else
                    {
                        BeneficiaryPortal bene = new BeneficiaryPortal();
                        bene.Show();
                    }

                    this.Hide();
                    return;
                }
            }
            if (!isAuthenticated)
            {
                MessageBox.Show("Invalid ID number or password.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
