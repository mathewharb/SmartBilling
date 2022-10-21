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
using System.Transactions;
using System.Windows.Forms;

namespace NGOManagementSystem.Views.Users
{
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }

        //creates a the data table to insert the parameters into the data grid view
        // DataTable dtbl = new DataTable();

        UserModel um = new UserModel();
        UsersController uc = new UsersController();

        //creates an object of the EmployeeModel and EmployeesController
        EmployeeModel em = new EmployeeModel();
        EmployeesController ec =new EmployeesController();

        //method to clear all the text boxes
        private void clearText()
        {
            textEmployeeID.Text = "";
            textEmployee.Text = "";
            comboUserTypes.Text = "";
            textID.Text = "";
            textFullName.Text = "";
            textContact.Text = "";
            textEmail.Text = "";

            textUsername.Text = "";
            textPassword.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAddUser_Load(object sender, EventArgs e)
        {
            //creates an instance of the UserTypes Controller
            UserTypesController utc = new UserTypesController();

            //fills the user type combo box with the user types 

            comboUserTypes.DataSource = utc.SelectType();


             comboUserTypes.DisplayMember = "UserType";
             comboUserTypes.ValueMember = "UserType";

            comboUserTypes.Text = "";

        }

        private void textEmployee_TextChanged(object sender, EventArgs e)
        {

            //creates a string variable for the search text box
            string textSearch = textEmployee.Text;

            if (textSearch != "")
            {
                //loads the search results and assign the values to their corresponding text boxes
                EmployeeModel emdl = ec.SearchEmployee(textSearch);

                //transfers the contents of the search results to their respective text boxes
                textEmployeeID.Text = emdl.EmployeeID.ToString();
                textFullName.Text = emdl.FullName;
                textEmail.Text = emdl.Email;
                textContact.Text = emdl.Contact;

                textID.Text = emdl.EmployeeID.ToString();

           }
            else
            {
                //clears all the text boxes if nothing is typed in the search text box
                textEmployeeID.Text = "";
                textEmployee.Text = "";
                textFullName.Text = "";
                comboUserTypes.Text = "";
                textEmail.Text = "";
                textContact.Text = "";
                textUsername.Text = "";
                textPassword.Text = "";
                textConfirmPassword.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //to check if the username already exists or not
            string userName = textUsername.Text;
            
            DataTable dtblUser = uc.UserNameExists(userName);

            //validations
            if (textFullName.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textFullName, "Full Name Cannot Be Empty");
                textEmployee.Focus();
                return;
            }
            if (comboUserTypes.Text=="")
            {
                errorProvider1.SetError(comboUserTypes, "You Need To Select User Type");
                comboUserTypes.Focus();
                return;
            }
            if (textUsername.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textUsername, "UserName Cannot Be Empty");
                textUsername.Focus();
                return;
            }
            if (dtblUser !=null && dtblUser.Rows.Count >0)
            {
                MessageBox.Show("This Username  Already Exist, Please Try Another One", "Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textUsername.Focus();
                return;
            }
            if (textPassword.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textPassword, "Password Cannot Be Empty");
                textPassword.Focus();
                return;
            }
            if (textPassword.Text.Length < 6)
            {
                MessageBox.Show("Password Cannot Be less than Six Characters", "Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }
            if (textConfirmPassword.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textConfirmPassword, "Confirm Password Field Cannot Be Empty");
                textConfirmPassword.Focus();
                return;
            }

            if (textPassword.Text != textConfirmPassword.Text)
            {
                MessageBox.Show("Your Passwords Dont Match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textConfirmPassword.Focus();
                return;
            }
            if (textConfirmPassword.Text.Length <6)
            {
                MessageBox.Show("Password Cannot Be less than Six Characters", "Password Length", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textPassword.Focus();
                return;
            }


            //insert functionality
            try
            {

                
                um.UserType = comboUserTypes.Text;
                um.Employee_ID = Convert.ToInt32(textID.Text);
                um.FullName = textFullName.Text;
                um.Contact = textContact.Text;
                um.Email=textEmail.Text;

                um.UserName = textUsername.Text.Trim();
                um.Password = textPassword.Text.Trim();

                um.Role = "";
                um.IsActive = false;

                //checks whether the user already exists to avoid duplicated login credentials
                string FullName = textFullName.Text;
                DataTable dtblFullName = uc.UserExists(FullName);

                if (dtblFullName != null && dtblFullName.Rows.Count > 0)
                {
                    MessageBox.Show("This User Already Exist", "User Exist", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    return;
                }

                //saving the details
                bool Success = uc.Insert(um);

                if (Success == true)
                {
                    MessageBox.Show("User Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clears all the text boxes
                    //clearText();

                    this.Hide();

                    //opens the Users form
                    frmAllUsers UsersList = new frmAllUsers();
                    UsersList.ShowDialog();

                    

                }
                else
                {
                    MessageBox.Show("Failed To Create User", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                
               
            }
            catch (Exception)
            {

            }
        }

        private void textContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears all the text boxes
            clearText();
        }
    }
}
