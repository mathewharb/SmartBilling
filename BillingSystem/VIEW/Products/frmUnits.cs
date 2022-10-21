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
    public partial class frmUnits : Form
    {
        public frmUnits()
        {
            InitializeComponent();
        }

        //creates an instance of the model and controller
        UnitsController uc = new UnitsController();
        UnitModel um = new UnitModel();

        //clears the text boxes
        private  void clearText()
        {
            textId.Text = "";
            textName.Text = "";
            textDescription.Text = "";

            //disables these buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;
        }

        //method load data into data grid view
        private void loadData()
        {
            //loads the data grid view
            DataTable dtbl = uc.AllUnits();
            dataGridUnits.DataSource = dtbl;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridUnits.Columns[0].Width = 90;
            dataGridUnits.Columns[1].Width = 180;
            dataGridUnits.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmUnits_Load(object sender, EventArgs e)
        {
            //loads the data grid view
            loadData();

            //clears the text boxes
            clearText();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (textName.Text=="")
            {
                MessageBox.Show("Unit Name Cannot Be Empty","Error", MessageBoxButtons.OK,MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    //gets the user input and assign it to the model
                    um.name = textName.Text;
                    um.description = textDescription.Text;
                    um.created_date = DateTime.Now;

                    //calls the Insert method from the Units Controller and assign it to variable of boolean data type

                    bool insertSuccess = uc.Insert(um);

                    if (insertSuccess == true)
                    {
                        //if record is successfully inserted, do the following:
                        MessageBox.Show("Unit Created Successfully", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);

                        //clears the text boxes
                        clearText();

                        //loads the data grid view
                        DataTable dtbl = uc.Select();
                        dataGridUnits.DataSource = dtbl;
                    }
                    else
                    {
                        MessageBox.Show("Could Not Create Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        //loads the data grid view
                        DataTable dtbl = uc.Select();
                        dataGridUnits.DataSource = dtbl;
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridUnits_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //getting the valuse from the datagrid view and pass them to the text boxex to be edited

            //gets the row index and assign it to an integer variable
            int rowIndex = e.RowIndex;

            //gets the contents of the datagrid view, converts them to string data type and pass them to their respective text boxes
            //note the index begins from 0 values

            textId.Text = dataGridUnits.Rows[rowIndex].Cells[0].Value.ToString();
            textName.Text = dataGridUnits.Rows[rowIndex].Cells[1].Value.ToString();
            textDescription.Text = dataGridUnits.Rows[rowIndex].Cells[2].Value.ToString();

            //sets the error messages to null
            errorProvider1.SetError(textName, "");

            //disables the save button
            btnSave.Enabled = false;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (textName.Text=="")
            {
                MessageBox.Show("Unit Name Cannot Be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            else
            {
                try
                {
                    //the update functionality
                    //NOTE: when updating, we are passing the ID as well, thus it needs to be converted to integer data type.

                    um.id = Convert.ToInt32(textId.Text);
                    um.name = textName.Text;
                    um.description = textDescription.Text;

                    //calling the save method from the Units Controller Class, and passing the model we have instantiated.

                    bool updateSuccess = uc.Update(um);

                    //checking if the update is successfull or not

                    if (updateSuccess == true)
                    {
                        MessageBox.Show("Unit Updated Successfully","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the text boxes
                        clearText();

                        //loads the data grid view
                        DataTable dtbl = uc.Select();
                        dataGridUnits.DataSource = dtbl;

                        //disables the updte and delete buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("Could Not Update Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch(Exception ex)
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
                    //NOTE: when deleting, we are passing the ID as well, thus it needs to be converted to integer data type.

                    um.id = Convert.ToInt32(textId.Text);

                    //calling the delete method from the Units Controller class and assigning to a boolean data type.
                    bool deleteSuccess = uc.Delete(um);

                    //checking if deleted successfully or not
                    if (deleteSuccess == true)
                    {
                        MessageBox.Show("Unit Deleted Successfully", "Success", MessageBoxButtons.OK,MessageBoxIcon.Information);

                        //clears the text boxes
                        clearText();

                        //loads the data grid view
                        DataTable dtbl = uc.Select();
                        dataGridUnits.DataSource = dtbl;

                        //disables the updte and delete buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                        btnSave.Enabled = true;

                    }
                    else
                    {
                        MessageBox.Show("Could Not Delete Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                return;
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text boxes
            clearText();

            //disables these buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            btnSave.Enabled = true;

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchUnitsTxt = textSearch.Text;

            if (searchUnitsTxt !=null)
            {
                //call the search method from the units controller and assign it to a data table
                DataTable dtbl = uc.SearchUnit(searchUnitsTxt);

               // fills the data grid view with contents of the searched item
                dataGridUnits.DataSource = dtbl;

            }
            else
            {
                //loads the data grid view
                DataTable dtbl = uc.Select();
                dataGridUnits.DataSource = dtbl;
            }
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            //validating the input
            if (textName.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textName, "Unit Name Cannot be Empty");
                textName.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textName, "");
                textName.BackColor = Color.Empty;

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            //validates the input
            if (textName.Text.Equals(string.Empty))
            {
                textName.Focus();

                return;
            }

            try
            {
                //updatig the record
                um.id = Convert.ToInt32(textId.Text);
                um.name = textName.Text;
                um.description = textDescription.Text;

                bool updateSuccess = uc.Update(um);

                if (updateSuccess == true)
                {
                    MessageBox.Show("Unit Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clears the text boxes
                    clearText();

                    //loads the data grid view
                    loadData();


                }
                else
                {
                    MessageBox.Show("Failed To Update Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

                //loads the data grid view
                loadData();

            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            //loads the data grid view
            loadData();

            //clears the text boxes
            clearText();
        }

        private void dataGridUnits_RowHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checks if only one row is selected 
            if (dataGridUnits.SelectedRows.Count == 1)
            {
                //binds the content of the datagrid view with the text box to be updated

                int rowIndex = e.RowIndex;

                textId.Text = dataGridUnits.Rows[rowIndex].Cells[0].Value.ToString();
                textName.Text = dataGridUnits.Rows[rowIndex].Cells[1].Value.ToString();
                textDescription.Text = dataGridUnits.Rows[rowIndex].Cells[2].Value.ToString();

                //sets the error messages to null
                errorProvider1.SetError(textName, "");

                //disables the save button
                btnSave.Enabled = false;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                //displays this error message when more than one row is selected
                MessageBox.Show("You can Only Select One Row At a Time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //loads the data grid view
                loadData();

                //clears the text boxes
                clearText();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            //validates the input
            if (textName.Text.Equals(string.Empty))
            {
                textName.Focus();

                return;
            }

            try
            {
                //gets the logged in user who created the record
                //this will be inserted in the created_by database field
                string creator;
                creator = frmLogin.loggedInUser;

                //binding the input with the model
                um.name = textName.Text;
                um.description = textDescription.Text;
                um.created_by = creator;
                um.created_date = DateTime.Now;

                //calling the insert method in the controller and assigning it ta boolean variable
                bool saveSuccess = uc.Insert(um);

                if (saveSuccess == true)
                {
                    MessageBox.Show("Unit Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //clears the text boxes
                    clearText();

                    //loads the data grid view
                    loadData();


                }
                else
                {
                    MessageBox.Show("Failed To Insert Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //loads the data grid view
                loadData();

            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want To Delete This Unit ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    //delete functionality
                    um.id = Convert.ToInt32(textId.Text);

                    bool deleteSuccess = uc.Delete(um);

                    if (deleteSuccess == true)
                    {
                        MessageBox.Show("Unit Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the text boxes
                        clearText();

                        //loads the data grid view
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed To Delete Unit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //loads the data grid view
                    loadData();
                }

                return;
            }
        }

        private void textSearch_TextChanged_1(object sender, EventArgs e)
        {
            string searchText = textSearch.Text;

            if (searchText != null)
            {
                //if a user types something in the search box, perform this operation

                DataTable dtbl = uc.SearchUnit(searchText);
                dataGridUnits.DataSource = dtbl;
            }
            else
            {
                //loads the data grid view
                loadData();
            }
        }
    }
}
