using SASSA_Application.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SASSA_Application.Designer_Forms
{
    public partial class AdminPortal : Form
    {
        public AdminPortal()
        {
            InitializeComponent();
        }

        private void pnlReports_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void btnAdminDashboard_Click(object sender, EventArgs e)
        {
            pnlAdminDashboard.BringToFront();
        }

        private void btnServices_Click(object sender, EventArgs e)
        {
            pnlServices.BringToFront();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            pnlStaff.BringToFront();
        }

        private void btnCentres_Click(object sender, EventArgs e)
        {
            pnlCentres.BringToFront();

        }

        private void btnBookings_Click(object sender, EventArgs e)
        {
            pnlBookings.BringToFront();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            pnlReports.BringToFront();
        }

      

        private void btnAddStaff_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string centre = cmbCentre.Text.Trim();
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(centre))
            {
                MessageBox.Show("Please fill in all fields.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Please enter a valid email address.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Generate a random 13-digit staff number
            Random rnd = new Random();

            string staffNumber = "";

            for (int i = 0; i < 13; i++)
            {
                staffNumber += rnd.Next(0, 10).ToString();
            }

            // Save to file: Name|StaffNumber|Centre|Email
            string filepath ="Users.txt";

            int count = File.Exists(filepath) ? File.ReadAllLines(filepath).Length : 0;
            

            string line =$"{name}|Staff|{staffNumber}|STAFF|N/A|{email}|{centre}|{email}";
            File.AppendAllText(filepath, line + Environment.NewLine);

            // Add row to the grid
            dgvStaffMembers.Rows.Add(name, staffNumber, centre, email);

            MessageBox.Show("Staff member added!\n\n" +
                            "Full Name: " + name + "\n" +
                            "Staff Number: " + staffNumber + "\n" +
                            "Centre: " + centre + "\n" +
                            "Email (password): " + email,
                            "Staff Added",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the fields
            //txtName.Clear();
            //txtEmail.Clear();
            cmbCentre.SelectedIndex = -1;

        }

        private void cmbServiceCentre_Click(object sender, EventArgs e)
        {

        }

        

        private void AdminPortal_Load_1(object sender, EventArgs e)
        {
            cmbCentre.AddRange("Johannesburg Central", "Soweto", "Pretoria Marabastad", "Tembisa");
        }
    }
    
}
