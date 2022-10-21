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

namespace BillingSystem.VIEW
{
    public partial class frmStakeholders : Form
    {
        public frmStakeholders()
        {
            InitializeComponent();
        }

        public static string lblStakeholderTitle;

        public static string comboCustomerSupplier;

        //cretes instances of the stakeholder Model and Controller
        StakeholderModel sm = new StakeholderModel();
        StakeholdersController sc = new StakeholdersController();

        //clears the contents of the text boxes
       private void clearText()
        {
            textId.Text = "";
            textName.Text = "";
            textEmail.Text = "";
            textPhone.Text = "";
            textAddress.Text = "";

        }


        private void frmStakeholders_Load(object sender, EventArgs e)
        {
            //load the contents of the data grid view
            DataTable dtbl = sc.ShowCustomerSupplier(comboCustomerSupplier);
            dataGridStakeholders.DataSource = dtbl;

            //disables these buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;

            lblStakeholder.Text = lblStakeholderTitle;

            comboType.Text = comboCustomerSupplier;
            comboType.DisplayMember = comboCustomerSupplier;
            comboType.ValueMember = comboCustomerSupplier;

            comboType.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textName.Text=="" || comboType.Text=="")
            {
                MessageBox.Show("You Need To Enter a Value in the Name and Type Field");
            }
            else
            {
                try
                {
                    //gets the logged in user who created the record
                    //this will be inserted in the created_by database field
                    string creator;
                    creator = frmLogin.loggedInUser;

                    //save functionality
                    sm.type = comboType.Text;
                    sm.name = textName.Text;
                    sm.email = textEmail.Text;
                    sm.tel = textPhone.Text;
                    sm.address = textAddress.Text;
                    sm.created_by = creator;
                    sm.created_date = DateTime.Now;

                    //calls the insert method from the Stakeholders Controller instance and pass the contents of the model, then assigns it to a boolean variable
                    bool saveSuccess = sc.Insert(sm);

                    //checks if the record is inserted or not
                    if (saveSuccess == true)
                    {
                        MessageBox.Show("Record Inserted Successfully");

                        //clears the contents of the text boxes
                        clearText();

                        //disables these buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;

                        //loads the contents of the data grid view
                        DataTable dtbl = sc.ShowCustomerSupplier(comboCustomerSupplier);
                        dataGridStakeholders.DataSource = dtbl;

                    }
                    else
                    {
                        MessageBox.Show("ERROR!! Failed To Insert Record");

                        //disables these buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridStakeholders_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridStakeholders_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //row header click event to select record from the datagrid view so its contents gets populated in their corresponding text boxes
            int rowIndex = e.RowIndex;

            textId.Text = dataGridStakeholders.Rows[rowIndex].Cells[0].Value.ToString();
            comboType.Text = dataGridStakeholders.Rows[rowIndex].Cells[1].Value.ToString();
            textName.Text = dataGridStakeholders.Rows[rowIndex].Cells[2].Value.ToString();
            textEmail.Text = dataGridStakeholders.Rows[rowIndex].Cells[3].Value.ToString();
            textPhone.Text = dataGridStakeholders.Rows[rowIndex].Cells[4].Value.ToString();
            textAddress.Text = dataGridStakeholders.Rows[rowIndex].Cells[5].Value.ToString();

            //sets the error messages to null
            errorProvider1.SetError(textName, "");
            errorProvider1.SetError(comboType, "");

            //disables the save button
            btnSave.Enabled = false;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearText();

            //disables these buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textName.Text=="")
            {
                MessageBox.Show("Name Cannot Be Empty");
            }
            else if(comboType.Text==""){
                MessageBox.Show("Type Cannot Be Empty");
            }else
            {
                try
                {

                    //update functionality

                    sm.id = Convert.ToInt32(textId.Text);
                    sm.type = comboType.Text;
                    sm.name = textName.Text;
                    sm.email = textEmail.Text;
                    sm.tel = textPhone.Text;
                    sm.address = textAddress.Text;

                    //calls the update method from the staheholders Controller instance 
                    bool updateRecord = sc.Update(sm);

                    //checks if theupdate is successful or not
                    if (updateRecord == true)
                    {
                        MessageBox.Show("Record Updated Successfully");

                        //clears the contents of the text boxes
                        clearText();

                        //disables these buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;

                        btnSave.Enabled = true;

                        //loads the contents of the data grid view
                        DataTable dtbl = sc.ShowCustomerSupplier(comboCustomerSupplier);
                        dataGridStakeholders.DataSource = dtbl;

                    }
                    else
                    {
                        MessageBox.Show("ERROR!! Failed To Update Record");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    //delete functionality
                    sm.id = Convert.ToInt32(textId.Text);

                    //calling the delete method from the Stakeholders Controller 
                    bool deleteRecord = sc.Delete(sm);

                    if (deleteRecord == true)
                    {
                        MessageBox.Show("Record Deleted Successfully");

                        //clears the contents of the text boxes
                        clearText();

                        //disables these buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;

                        btnSave.Enabled = true;

                        //loads the contents of the data grid view
                        DataTable dtbl = sc.ShowCustomerSupplier(comboCustomerSupplier);
                        dataGridStakeholders.DataSource = dtbl;

                    }
                    else
                    {
                        MessageBox.Show("ERROR!! Failed To Delete Record");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return;
            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textSearch.Text;

            //checks if the search text box contains any searches or not
            if (searchText != null)
            {
                //loads the contents of the saerched data if anything is typed in the search text box
                DataTable dtbl = sc.SearchRecord(searchText);

                dataGridStakeholders.DataSource = dtbl;
            }
            else
            {
                //loads the contents of the data grid view if nothing is typed in the search text box
            DataTable dtbl = sc.ShowCustomerSupplier(comboCustomerSupplier);
            dataGridStakeholders.DataSource = dtbl;
            }
        }

        private void comboType_Validating(object sender, CancelEventArgs e)
        {
            //validating the input
            if (comboType.Text == "")
            {
                errorProvider1.SetError(comboType, "You Need To Select Type");
            }
            else
            {
                errorProvider1.SetError(comboType, "");

            }
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            //validating the input
            if (textName.Text == "")
            {
                errorProvider1.SetError(textName, "Name Cannot be Empty");
            }
            else
            {
                errorProvider1.SetError(textName, "");

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
