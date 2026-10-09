using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class Registration : Form
    {

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
            lblShowPassword.Text = "👁️ Show";
            cmbServiceCentre.Items.Clear();

            bool loadedFromFile = false;

            if (File.Exists("Centres.txt"))
            {
                foreach (string line in File.ReadAllLines("Centres.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length < 3) continue;

                    cmbServiceCentre.Items.Add(parts[0]);
                    loadedFromFile = true;
                }
            }

            // If no centres in the file, use defaults so the dropdown is never empty
            if (!loadedFromFile)
            {
                cmbServiceCentre.AddRange(
                    "Johannesburg Central",
                    "Soweto",
                    "Pretoria Marabastad",
                    "Tembisa"
                );
            }
        }

        private void btnRegisterAccount_Click(object sender, EventArgs e)
        {
            string name = txtFullName.Text.Trim();
            string surname = txtLastName.Text.Trim();
            string idNum = txtIDNumber.Text.Trim();
            string phoneNumber = txtPhoneNumber.Text.Trim();
            string email = txtEmail.Text.Trim();
            string centre = cmbServiceCentre.Text.Trim();
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            errorProvider1.Clear();
            bool isValid = true;

            // ---- Name ----
            if (string.IsNullOrWhiteSpace(name))
            {
                errorProvider1.SetError(txtFullName, "Name is Required");
                isValid = false;
            }
            else if (name.Length < 2)
            {
                errorProvider1.SetError(txtFullName, "Name must be at least 2 characters");
                isValid = false;
            }

            // ---- Surname ----
            if (string.IsNullOrWhiteSpace(surname))
            {
                errorProvider1.SetError(txtLastName, "Surname is Required");
                isValid = false;
            }
            else if (surname.Length < 2)
            {
                errorProvider1.SetError(txtLastName, "Surname must be at least 2 characters");
                isValid = false;
            }

            // ---- ID Number (13 digits) ----
            if (string.IsNullOrWhiteSpace(idNum))
            {
                errorProvider1.SetError(txtIDNumber, "ID Number is Required");
                isValid = false;
            }
            else if (idNum.Length != 13)
            {
                errorProvider1.SetError(txtIDNumber, "ID Number must be 13 digits");
                isValid = false;
            }
            else
            {
                foreach (char c in idNum)
                {
                    if (!char.IsDigit(c))
                    {
                        errorProvider1.SetError(txtIDNumber, "ID Number must contain digits only");
                        isValid = false;
                        break;
                    }
                }
            }

            // ---- Phone Number (10 digits) ----
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                errorProvider1.SetError(txtPhoneNumber, "Phone Number is Required");
                isValid = false;
            }
            else if (phoneNumber.Length != 10)
            {
                errorProvider1.SetError(txtPhoneNumber, "Phone Number must be 10 digits");
                isValid = false;
            }
            else
            {
                foreach (char c in phoneNumber)
                {
                    if (!char.IsDigit(c))
                    {
                        errorProvider1.SetError(txtPhoneNumber, "Phone Number must contain digits only");
                        isValid = false;
                        break;
                    }
                }
            }

            // ---- Email ----
            if (string.IsNullOrWhiteSpace(email))
            {
                errorProvider1.SetError(txtEmail, "Email is Required");
                isValid = false;
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                errorProvider1.SetError(txtEmail, "Email must be valid (e.g. name@gmail.com)");
                isValid = false;
            }

            // ---- Service Centre ----
            if (string.IsNullOrWhiteSpace(centre))
            {
                errorProvider1.SetError(cmbServiceCentre, "Select a Service Centre");
                isValid = false;
            }

            // ---- Password ----
            if (string.IsNullOrWhiteSpace(password))
            {
                errorProvider1.SetError(txtPassword, "Password is Required");
                isValid = false;
            }
            else if (password.Length < 6)
            {
                errorProvider1.SetError(txtPassword, "Password must be at least 6 characters");
                isValid = false;
            }

            // ---- Confirm Password ----
            if (string.IsNullOrWhiteSpace(confirmPassword))
            {
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is Required");
                isValid = false;
            }
            else if (password != confirmPassword)
            {
                errorProvider1.SetError(txtConfirmPassword, "Passwords do not match");
                isValid = false;
            }

            if (!isValid)
            {
                return;
            }

            // ---- Check for duplicate ID ----
            if (File.Exists("Beneficiaries.txt"))
            {
                foreach (string line in File.ReadAllLines("Beneficiaries.txt"))
                {
                    if (string.IsNullOrWhiteSpace(line)) continue;
                    string[] parts = line.Split('|');
                    if (parts.Length < 7) continue;

                    if (parts[2] == idNum)
                    {
                        MessageBox.Show("An account with this ID number already exists.",
                                        "Duplicate Account",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            // ---- Create the Beneficiary object ----
            Beneficiary newBeneficiary = new Beneficiary();
            newBeneficiary.Name = name;
            newBeneficiary.Surname = surname;
            newBeneficiary.IdNumber = idNum;
            newBeneficiary.Cell = phoneNumber;
            newBeneficiary.Email = email;
            newBeneficiary.PreferredCentre = centre;
            newBeneficiary.Password = password;

            // ---- Save to Beneficiaries.txt ----
            string newLine = newBeneficiary.Name + "|" + newBeneficiary.Surname + "|" +
                             newBeneficiary.IdNumber + "|" + newBeneficiary.Cell + "|" +
                             newBeneficiary.Email + "|" + newBeneficiary.PreferredCentre + "|" +
                             newBeneficiary.Password;

            File.AppendAllText("Beneficiaries.txt", newLine + Environment.NewLine);

            MessageBox.Show("Account created successfully!", "Registration Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            // ---- Clear the form ----
            txtFullName.Text = "";
            txtLastName.Text = "";
            txtIDNumber.Text = "";
            txtPhoneNumber.Text = "";
            txtEmail.Text = "";
            cmbServiceCentre.SelectedItem = null;
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";

            this.Close();
        }

        private void cmbServiceCentre_TextChanged(object sender, EventArgs e)
        {
            //cmbServiceCentre.AddRange("Johannesburg Central", "Soweto", "Pretoria Marabastad", "Tembisa");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {

            frmWelcomePage welcome = new frmWelcomePage();
            welcome.Show();
            this.Close();

        }

        private void lblShowPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '*')
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
                lblShowPassword.Text = "🙈 Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
                lblShowPassword.Text = "👁️ Show";
            }
        }
    }
}


            
    

