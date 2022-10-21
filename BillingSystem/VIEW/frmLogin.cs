using BillingSystem.CONTROLLER;
using BillingSystem.MODEL;
using BillingSystem.VIEW.Auth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BillingSystem.VIEW
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        //creates an instance of the login model and controller
        LoginModel lm = new LoginModel();
        LoginController lc = new LoginController();

        UsersController uc = new UsersController();

        public static string loggedInUser;

        public static string IsUserActive;


        //default user model and controller objects
        DefaultUserModel dum = new DefaultUserModel();
        DefaultUserController duc = new DefaultUserController();


        private void textUsername_Validating(object sender, CancelEventArgs e)
        {
            //validating the useername input 
            if (textUsername.Text == "")
            {

                errorProvider1.SetError(textUsername, "You must enter a username");
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
            //validating the password input 
            if (textPassword.Text == "")
            {

                errorProvider1.SetError(textPassword, "You must enter a Password");
                textPassword.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textPassword, "");
                textPassword.BackColor = Color.Empty;
            }
        }

        private void comboUsertype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboUsertype_Validating(object sender, CancelEventArgs e)
        {
            //validating the usertype input 
            if (comboUsertype.Text == "")
            {

                errorProvider1.SetError(comboUsertype, "You must select a User type");
                comboUsertype.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(comboUsertype, "");
                comboUsertype.BackColor = Color.Empty;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //login functionality

            lm.UserName = textUsername.Text.ToLower().Trim();
            lm.Password = textPassword.Text.Trim();
            lm.UserType = comboUsertype.Text.Trim();

            bool loginSuccess = lc.loginCheck(lm);

            //check whether the user is active or not
            string usernametxt = textUsername.Text.Trim();
            string passwordtxt = textPassword.Text.Trim();
            DataTable dtbl = uc.CheckActive(usernametxt, passwordtxt);

            if (dtbl != null && dtbl.Rows.Count > 0)
            {
                bool status = Convert.ToBoolean(dtbl.Rows[0]["IsActive"]);
                if (status)
                {
                    if (loginSuccess == true)
                    {
                        //hides the login form when the login is successfull

                        this.Hide();

                        //checks to redirect logged in user to their respective dashboards
                        if (lm.UserType == "Admin")
                        {
                            loggedInUser = lm.UserName;

                            frmAdminDashboard adminDashboard = new frmAdminDashboard();
                            adminDashboard.Show();

                        }
                        else if (lm.UserType == "User")
                        {
                            loggedInUser = lm.UserName;

                            frmAdminDashboard adminDashboard = new frmAdminDashboard();
                            adminDashboard.Show();

                        }
                        else
                        {
                            MessageBox.Show("Invalid User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Invalid User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("Account Inactive, Please Contact Admin", "Inactive User Account", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("Invalid Login Credentials", "Invalid Login", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            //checks the users table for admin account when the login form loads
            string UserType = "Admin";
            DataTable dt = duc.SelectAdmin(UserType);

            if (dt.Rows.Count > 0)
            {
                this.Show();

            }
            else
            {
                this.Hide();
                frmDefaultUser DefaultUser = new frmDefaultUser();
                DefaultUser.ShowDialog();

            }

            //creates an instance of the UserTypes Controller
            UserTypesController utc = new UserTypesController();

            //fills the user type combo box with the user types 

            comboUsertype.DataSource = utc.SelectType();


            comboUsertype.DisplayMember = "UserType";
            comboUsertype.ValueMember = "UserType";

            comboUsertype.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
