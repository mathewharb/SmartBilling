using BillingSystem.CONTROLLER;
using BillingSystem.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BillingSystem.VIEW;

namespace BillingSystem.VIEW.Auth
{
    public partial class frmDefaultUser : frmAuthTemplate
    {
        public frmDefaultUser()
        {
           InitializeComponent();
        }

        //Creates the Objects of DefaultUser Model and Controller
        DefaultUserModel dum = new DefaultUserModel();
        DefaultUserController duc = new DefaultUserController();


        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //validating the text boxes

            if (textUserName.Text.Equals(string.Empty))
            {
                textUserName.Focus();

                return;
            }
            if (textPassword.Text.Equals(string.Empty))
            {
                textPassword.Focus();

                return;
            }
            if (textPassword.Text.Length < 6)
            {
                MessageBox.Show("Password Cannot Be less than Six Characters", "Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }

            if (textPassword.Text != textConfirmPassword.Text)
            {
                MessageBox.Show("Your Passwords Dont Match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }
            if (textConfirmPassword.Text.Length < 6)
            {
                MessageBox.Show("Password Cannot Be less than Six Characters", "Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }

            //Save Functionality
            try
            {
                dum.UserName = textUserName.Text.Trim();
                dum.Password = textPassword.Text.Trim();
                dum.UserType = "Admin";
                dum.Role = "Admin";
                dum.IsActive = Convert.ToBoolean("True");

                bool SuccessInsert = duc.InsertDefaultUser(dum);

                //checks if the record is saved or not
                if (SuccessInsert == true)
                {
                    MessageBox.Show("Admin Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Hide();

                    frmLogin loginForm = new frmLogin();

                    loginForm.Close();

                    loginForm.ShowDialog();

                }
                else
                {
                    MessageBox.Show("Failed To Create Admin", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {
                //displays exceptional error messages if any
               // MessageBox.Show(ex.Message);
            }

        }

        private void frmDefaultUser_Load(object sender, EventArgs e)
        {

        }

        private void textUserName_Validating(object sender, CancelEventArgs e)
        {
            //validating the input
            if (textUserName.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textUserName, "Username Name Cannot be Empty");
                textUserName.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textUserName, "");
                textUserName.BackColor = Color.Empty;

            }
        }

        private void textPassword_Validating(object sender, CancelEventArgs e)
        {
            //validating the input
            if (textPassword.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textPassword, "Password Cannot be Empty");
                textPassword.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textPassword, "");
                textPassword.BackColor = Color.Empty;

            }
        }

        private void textConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            //validating the input
            if (textConfirmPassword.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textConfirmPassword, "Confirm Password Cannot be Empty");
                textConfirmPassword.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textConfirmPassword, "");
                textConfirmPassword.BackColor = Color.Empty;

            }
        }
    }
}
