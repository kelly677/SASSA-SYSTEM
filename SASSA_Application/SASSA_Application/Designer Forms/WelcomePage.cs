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
                if (File.Exists("Staff.txt"))
                {
                    foreach (string line in File.ReadAllLines("Staff.txt"))
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;
                        string[] parts = line.Split('|');
                        if (parts.Length < 4) continue;

                        string savedStaffNumber = parts[1];
                        string savedEmail = parts[3];

                        if (savedStaffNumber == id && savedEmail == password)
                        {
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
            if (!File.Exists("Beneficiaries.txt"))
            {
                MessageBox.Show("No accounts registered yet.", "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (string line in File.ReadAllLines("Beneficiaries.txt"))
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length < 7) continue;

                string savedId = parts[2];
                string savedPassword = parts[6];

                if (savedId == id && savedPassword == password)
                {
                    if (savedPassword.Contains("Admin"))
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

            MessageBox.Show("Invalid ID number or password.", "Login Failed",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}