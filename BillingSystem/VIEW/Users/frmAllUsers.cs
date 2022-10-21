
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
    public partial class frmAllUsers : Form
    {
        public frmAllUsers()
        {
            InitializeComponent();
        }


        //creates an object of UsersController and UserModel 
        UsersController uc = new UsersController();
        UserModel um = new UserModel();

        //method to clear the text boxes
        private void clearText()
        {
           textUserID.Text="";
           textFullName.Text="";
           textContact.Text="";
           textEmail.Text="";
           textUsername.Text="";
           comboUserTypes.Text="";
           textPassword.Text="";
           textConfirmPassword.Text = "";
           comboRole.Text="";
           comboIsActive.Text = "";
        }

        //disables these text boxes
        private void disableText()
        {


            comboUserTypes.Enabled = false;
            textPassword.Enabled = false;
            textConfirmPassword.Enabled = false;
            comboRole.Enabled = false;
            comboIsActive.Enabled = false;

            btnUpdate.Enabled = false;
        }
        //enables these text boxes
        private void enableText()
        {
            comboUserTypes.Enabled = true;
            textPassword.Enabled = true;
            textConfirmPassword.Enabled = true;
            comboRole.Enabled = true;
            comboIsActive.Enabled = true;

            btnUpdate.Enabled = true;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmAllUsers_Load(object sender, EventArgs e)
        {
            //creates an instance of the UserTypes Controller
            UserTypesController utc = new UserTypesController();

            //fills the user type combo box with the user types 
            comboUserTypes.DataSource = utc.SelectType();

            comboUserTypes.DisplayMember = "UserType";
            comboUserTypes.ValueMember = "UserType";

            comboUserTypes.Text = "";

            //fills the data grid with the list of users when the form loads
            DataTable dt = uc.Select();
            dataGridUsers.DataSource = dt;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridUsers.Columns[0].Width = 75;
            dataGridUsers.Columns[1].Width = 170;
            dataGridUsers.Columns[2].Width = 90;
            dataGridUsers.Columns[3].Width = 150;
            dataGridUsers.Columns[4].Width = 70;
            dataGridUsers.Columns[5].Width = 0;
            dataGridUsers.Columns[5].Visible = false;
            dataGridUsers.Columns[6].Width = 75;
            dataGridUsers.Columns[7].Width = 65;
            dataGridUsers.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //disables the input fields when the form loads
            disableText();
           
        }

        private void dataGridUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //checks if only one row is selected or not
            if (dataGridUsers.SelectedRows.Count == 1)
            {
                //fills the text boxes with theirrespective details, when a row is selected
                int rowIndex = e.RowIndex;
                textUserID.Text = dataGridUsers.Rows[rowIndex].Cells[0].Value.ToString();
                textFullName.Text = dataGridUsers.Rows[rowIndex].Cells[1].Value.ToString();
                textContact.Text = dataGridUsers.Rows[rowIndex].Cells[2].Value.ToString();
                textEmail.Text = dataGridUsers.Rows[rowIndex].Cells[3].Value.ToString();
                textUsername.Text = dataGridUsers.Rows[rowIndex].Cells[4].Value.ToString();
                textPassword.Text = dataGridUsers.Rows[rowIndex].Cells[5].Value.ToString();
                comboUserTypes.Text = dataGridUsers.Rows[rowIndex].Cells[6].Value.ToString();
                comboRole.Text = dataGridUsers.Rows[rowIndex].Cells[7].Value.ToString();
               comboIsActive.Text = dataGridUsers.Rows[rowIndex].Cells[8].Value.ToString();

                //enables the input fields
                enableText();
            }
            else
            {
                //displays this error message when more than one row is selected
                MessageBox.Show("Please Select One Row Ae a Time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
            //updating user details
            try
            {
                //checks if  the required text boxes are not empty before updating any record
                if (textUsername.Text !="" && comboUserTypes.Text !="" && textPassword.Text !="" && textConfirmPassword.Text !="" && comboRole.Text !="")
                {
                    if (textPassword.Text.Trim() !=textConfirmPassword.Text.Trim())
                    {
                        MessageBox.Show("Your Passwords Dont Match", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        textConfirmPassword.Focus();
                        return;
                    }
                    um.UserID = Convert.ToInt32(textUserID.Text);
                    //um.FullName = textFullName.Text;
                   // um.Contact = textContact.Text;
                   // um.Email = textEmail.Text;
                    um.UserName = textUsername.Text;
                    um.UserType = comboUserTypes.Text;
                    um.Password = textPassword.Text.Trim();
                    um.Role = comboRole.Text;
                    um.IsActive = Convert.ToBoolean(comboIsActive.Text);

                    bool SuccessUpdate = uc.Update(um);

                    //checks if the update is successful or not
                    if (SuccessUpdate==true)
                    {
                        MessageBox.Show("User Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //refreshes the data grid view
                        DataTable dt = uc.Select();
                        dataGridUsers.DataSource = dt;

                        //clears the text boxes
                        clearText();

                        //disables the input
                        disableText();
                    }
                    else
                    {
                        MessageBox.Show("Failed To Update User", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                  
                }
                else
                {
                    MessageBox.Show("Please Fill In All The Required Fields","Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (Exception ex)
            {
                //displays exceptional error messages if any
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text boxes
            clearText();

            //disables the 
            disableText();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            //search functionality
            //checks if the user types anything in the search text box or not
            string searchText = textSearch.Text;
            if (!searchText.Equals(string.Empty))
            {
                //displays the search result, when the types a serach in the search text box
                DataTable dtbl = uc.SearchAllUsers(searchText);

                dataGridUsers.DataSource = dtbl;
            }
            else
            {
                //if the user does not search for anything, then display all users
                DataTable dtbl = uc.Select();
                dataGridUsers.DataSource = dtbl;
            }
        }

        private void btnNewUser_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmAddUser AddUserForm = new frmAddUser();
            AddUserForm.ShowDialog();

        }
    }
}
