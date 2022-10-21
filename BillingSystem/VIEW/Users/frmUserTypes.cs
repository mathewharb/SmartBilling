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

namespace NGOManagementSystem.Views
{
    public partial class frmUserTypes : Form
    {
        public frmUserTypes()
        {
            InitializeComponent();
        }

        //creates the usertype model and controller objects
        UserTypeModel utm = new UserTypeModel();
        UserTypesController utc = new UserTypesController();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmUserTypes_Load(object sender, EventArgs e)
        {
            //loads the data grid view
            DataTable dtbl = utc.Select();

            dataGridUserTypes.DataSource = dtbl;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridUserTypes.Columns[0].Width = 100;
            dataGridUserTypes.Columns[1].AutoSizeMode=DataGridViewAutoSizeColumnMode.Fill;

            //disable the update and delete buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //enables the add button
            btnSave.Enabled = true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            ////checks if the user type text box is empty or not
            //string UserTypeText = textUserType.Text;

            ////data atable to check if the user already exists
            //DataTable dtblUType = utc.UserTypeExists(UserTypeText);

            //if (UserTypeText.Equals (string.Empty))
            //{
            //    errorProvider1.SetError(textUserType, "User Type Cannot Be Empty");

            //}else if (dtblUType != null && dtblUType.Rows.Count >0)
            //{
            //    MessageBox.Show("This User Type Already Exist","Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    textUserType.Focus();
            //}
            //else
            //{
               
            //    try
            //    {
            //        utm.UserType = textUserType.Text.Trim();

            //        bool InsertSuccess = utc.Insert(utm);

            //        if (InsertSuccess == true)
            //        {
            //            MessageBox.Show("User Type Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            //clears the text box
            //            textUserType.Text = "";

            //            //loads the data grid view
            //            DataTable dtbl = utc.Select();
            //            dataGridUserTypes.DataSource = dtbl;

            //            //disable the update and delete buttons
            //            btnUpdate.Enabled = false;
            //            btnDelete.Enabled = false;
            //        }
            //        else
            //        {
            //            MessageBox.Show("Cannot Add User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text box
            textUserType.Text = "";

            //disable the update and delete buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //enables the add button
            btnSave.Enabled = true;

        }

        private void dataGridUserTypes_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            //checks if only one row is selected or not
            if (dataGridUserTypes.SelectedRows.Count==1)
            {
                //displays the contents of the selected items in their respective text boxes

                //creates an integer variable and assign the rowindex
                 int rowIndex = e.RowIndex;

                textID.Text = dataGridUserTypes.Rows[rowIndex].Cells[0].Value.ToString();
                textUserType.Text = dataGridUserTypes.Rows[rowIndex].Cells[1].Value.ToString();
             
                //YOU CAN ALSO GET THE CONTENTS FROM THE ROW THIS WAY, WITHOUT CREATING THE "rowIndex" VARIABLE
               // textID.Text = dataGridUserTypes.CurrentRow.Cells[0].Value.ToString();
                //textUserType.Text = dataGridUserTypes.CurrentRow.Cells[1].Value.ToString();

                //enables the update and save buttons whenever the row is selected
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                //disables the save button whenever the row is selected
                btnSave.Enabled = false;
            }
            else
            {
                //displays this error message when more than one row is selected
                MessageBox.Show("Please Select One Row To Edit Or Delete a Record", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }



        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ////checks if the text box is empty or not
            //string UserTypeText = textUserType.Text;

            //if (UserTypeText.Equals(string.Empty))
            //{
            //    errorProvider1.SetError(textUserType, "User Type Cannot Be Empty");

            //}
            //else
            //{
            //    try
            //    {
            //        //converts the Id text box to integer and pass it to the the model
            //        utm.UserTypeID = Convert.ToInt32(textID.Text);

            //        utm.UserType = textUserType.Text;

            //        //creates a boolean variable and assign the update functionality it
            //        bool SuccessUpdate = utc.Update(utm); 

            //        //checks if the record is updated successfully or not
            //        if (SuccessUpdate ==true)
            //        {
            //            //displays a success message if record updated successfully
            //            MessageBox.Show("User Type Updated Successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            //clears the text box
            //            textUserType.Text = "";

            //            //loads the data grid view
            //            DataTable dtbl = utc.Select();
            //            dtbl.Rows.Add("ID","User Type");
            //            dataGridUserTypes.DataSource = dtbl;

            //            //disable the update and delete buttons
            //            btnUpdate.Enabled = false;
            //            btnDelete.Enabled = false;

            //            //enables the save button
            //            btnSave.Enabled = true;
            //        }
            //        else
            //        {
            //            //displays error message if the record failed to update
            //            MessageBox.Show("Cannot Update User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }

                    

            //    }catch(Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}


       }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            //if (DialogResult.Yes == MessageBox.Show("Do You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            //{
            //    try
            //    {

            //        //converts the Id text box to integer and pass it to the the model
            //        utm.UserTypeID = Convert.ToInt32(textID.Text);

            //        utm.UserType = textUserType.Text;

            //        //creates a boolean variable and assign the delete functionality it
            //        bool SuccessDelete = utc.Delete(utm);

            //        //checks if the record is deleted successfully or not
            //        if (SuccessDelete == true)
            //        {
            //            //displays a success message if record deleted successfully
            //            MessageBox.Show("User Type Deleted Successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //            //clears the text box
            //            textUserType.Text = "";

            //            //loads the data grid view
            //            DataTable dtbl = utc.Select();
            //            dataGridUserTypes.DataSource = dtbl;

            //            //disable the update and delete buttons
            //            btnUpdate.Enabled = false;
            //            btnDelete.Enabled = false;

            //            //enables the save button
            //            btnSave.Enabled = true;
            //        }
            //        else
            //        {
            //            //displays error message if the record failed to Delete
            //            MessageBox.Show("Cannot Delete  User Type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        //displays exceptional error messages if any
            //        MessageBox.Show(ex.Message);

            //    }

            //    return;
            //}

 
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            //implementing the search functionality

            string searchText = textSearch.Text;

            //checks if the user types anything in the search text box or not
            if (!searchText .Equals (string.Empty))
            {
                //if the user enters a search in the search bar;
                
                //this cals the "Search" method from the "UserTypes" Controller
                DataTable dtbl = utc.Search(searchText);
                //then displays the search results in the data grid
                dataGridUserTypes.DataSource = dtbl;

            }
            else
            {
                //if the user does not search for anything;
                //then display the contents of the data grid
                DataTable dtbl = utc.Select();

                dataGridUserTypes.DataSource = dtbl;

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
