using BillingSystem;
using BillingSystem.CONTROLLER;
using BillingSystem.MODEL;
using BillingSystem.VIEW;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NGOManagementSystem.Views.Users
{
    public partial class frmChangePassword : Form
    {
        public frmChangePassword()
        {
            InitializeComponent();
        }

        ChangePassModel cpm = new ChangePassModel();
        ChangePassController cpc = new ChangePassController();


        UserModel um = new UserModel();
        UsersController uc = new UsersController();

        //method to clear the text boxes
        private void clearText()
        {
            textConfirmPassword.Text = "";
            textPassword.Text = "";
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            //displays the logged in username
            textUsername.Text = frmLogin.loggedInUser;

            string username = textUsername.Text;
            UserModel umdl = uc.SearchUser(username);
            textID.Text = umdl.UserID.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textUsername.Text.Equals(string.Empty))
            {
               textUsername.Focus();
                return;
            }
            if (textPassword.Text.Equals(string.Empty))
            {
                textPassword.Focus();
                return;        
            }
            else if (textPassword.Text.Length < 6)
            {
                MessageBox.Show("Password Cannot Be less than Six Characters", "Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }

            if (textConfirmPassword.Text.Equals(string.Empty))
            {
                textConfirmPassword.Focus();
                return;

            }
            else if (textConfirmPassword.Text.Length < 6)
            {
                MessageBox.Show("Confirm Password Cannot Be less than Six Characters", "Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textConfirmPassword.Focus();
                return;
            }
            if (textPassword.Text != textConfirmPassword.Text)
            {
                MessageBox.Show("Your Passwords Dont Match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }

            if (!textUsername.Text.Equals(string.Empty) && !textPassword.Text.Equals(string.Empty) && !textConfirmPassword.Text.Equals(string.Empty))
            {
                try
                {
                    cpm.UserID = Convert.ToInt32(textID.Text);
                    cpm.UserName = textUsername.Text;

                    cpm.Password = textPassword.Text.Trim();

                    //saving the details
                    bool Success = cpc.UpdatePassword(cpm);

                    if (Success == true)
                    {
                        MessageBox.Show("Password Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                         this.Hide();

                        frmAdminDashboard AdminDashboard= new frmAdminDashboard();
                        AdminDashboard.Close();

                        frmLogin loginForm = new frmLogin();
                        loginForm.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Failed To Change", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                //if all the text fields are empty, then show this error message
                MessageBox.Show("Please Fill In All The Required Fields", "All Fields Are Required", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears all the text boxes
            clearText();
        }

        private void textUsername_Validating(object sender, CancelEventArgs e)
        {
            if (textUsername.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textUsername, "UserName Cannot Be Empty");
                textUsername.BackColor = Color.MistyRose;

            }
            else
            {
                errorProvider1.SetError(textUsername, "");
                textUsername.BackColor = Color.Empty;
            }
        }

        private void textPassword_Validating(object sender, CancelEventArgs e)
        {
            if (textPassword.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textPassword, "Password Cannot Be Empty");
                textPassword.BackColor = Color.MistyRose;
            }else if (textPassword.Text.Length < 6)
            {
                errorProvider1.SetError(textPassword, "Password Cannot Be Less Than 6 Characters");
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
            if (textConfirmPassword.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textConfirmPassword, "Confirm Password Field Cannot Be Empty");
                textConfirmPassword.BackColor = Color.MistyRose;

            }
            else if (textConfirmPassword.Text.Length < 6)
            {
                errorProvider1.SetError(textConfirmPassword, "Confirm Password Cannot Be less than Six Characters");
                textConfirmPassword.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textConfirmPassword, "");
                textConfirmPassword.BackColor = Color.Empty;
            }

            if (textPassword.Text != textConfirmPassword.Text)
            {
                errorProvider1.SetError(textPassword, "Your Passwords Dont Match");
                textPassword.BackColor = Color.MistyRose;

                errorProvider1.SetError(textConfirmPassword, "Your Passwords Dont Match");
                textConfirmPassword.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textPassword, "");
                textPassword.BackColor = Color.Empty;

                errorProvider1.SetError(textConfirmPassword, "");
                textConfirmPassword.BackColor = Color.Empty;
            }
        }
    }
}
