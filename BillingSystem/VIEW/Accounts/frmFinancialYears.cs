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

namespace BillingSystem.VIEW.Accounts
{
    public partial class frmFinancialYears : Form
    {
        public frmFinancialYears()
        {
            InitializeComponent();
        }

        //method to clear the text boxes and reload the datagrid
        private void clearText()
        {
            //clears the text box
            textID.Text = "";
            textYear.Text = "";

            //loads the data grid view
            DataTable dtbl = fyc.SelectAll();
            dataGridFinancialYears.DataSource = dtbl;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridFinancialYears.Columns[0].Width = 100;
            dataGridFinancialYears.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //disable the update and delete buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //enables the add button
            btnSave.Enabled = true;
        }

        //method to reload the datagrid view
        private void loadDataGrid()
        {
            //loads the data grid view
            DataTable dtbl = fyc.SelectAll();
            dataGridFinancialYears.DataSource = dtbl;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridFinancialYears.Columns[0].Width = 100;
            dataGridFinancialYears.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        //creates the FinancialYears model and controller objects
        FinancialYearModel fym = new FinancialYearModel();
        FinancialYearsController fyc = new FinancialYearsController();

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //checks if the year text box is empty or not
            string yearText = textYear.Text;

            //data atable to check if the year already exists
            DataTable dtblYearExist = fyc.YearExists(yearText);

            if (textYear.Text.Equals(string.Empty))
            {
                textYear.Focus();

                return;

            }
            if (dtblYearExist != null && dtblYearExist.Rows.Count > 0)
            {
                MessageBox.Show("This Year Already Exist", "Already Taken",MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textYear.Focus();

                return;
            }


                try
                {
                    fym.Year = int.Parse(textYear.Text.Trim());

                    bool insertsuccess =fyc.Insert(fym);

                    if (insertsuccess == true)
                    {
                       MessageBox.Show("Year Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the text box
                        textYear.Text = "";

                        //loads the data grid view
                        loadDataGrid();

                        //disable the update and delete buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;
                    }
                    else
                    {
                       MessageBox.Show("Cannot Add Year", "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
           
        }

        private void frmFinancialYears_Load(object sender, EventArgs e)
        {
            //loads the data grid view
            loadDataGrid();

            //disable the update and delete buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //enables the add button
            btnSave.Enabled = true;
        }

        private void dataGridFinancialYears_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checks if only one row is selected or not
            if (dataGridFinancialYears.SelectedRows.Count == 1)
            {
                //displays the contents of the selected items in their respective text boxes

                //creates an integer variable and assign the rowindex
                int rowIndex = e.RowIndex;

                textID.Text = dataGridFinancialYears.Rows[rowIndex].Cells[0].Value.ToString();
                textYear.Text = dataGridFinancialYears.Rows[rowIndex].Cells[1].Value.ToString();

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

                clearText();

            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text boxes and reloads the datagrid view
            clearText();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //checks if the text box is empty or not
            string YearText = textYear.Text;

            if (textYear.Text.Equals(string.Empty))
            {
                textYear.Focus();

                return;
            }

                try
                {
                    //converts the Id text box to integer and pass it to the the model
                    fym.FinancialYearID = Convert.ToInt32(textID.Text);

                    fym.Year = Convert.ToInt32(textYear.Text.Trim());

                    //creates a boolean variable and assign the update functionality it
                    bool SuccessUpdate = fyc.Update(fym);

                    //checks if the record is updated successfully or not
                    if (SuccessUpdate == true)
                    {
                        //displays a success message if record updated successfully
                        MessageBox.Show("Year Updated Successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the text box
                        textYear.Text = "";

                        //loads the data grid view
                        loadDataGrid();

                        //disable the update and delete buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;

                        //enables the save button
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        //displays error message if the record failed to update
                        MessageBox.Show("Cannot Update Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want To Delete The Selected Year ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {

                    //converts the Id text box to integer and pass it to the the model
                    fym.FinancialYearID = Convert.ToInt32(textID.Text);

                    //fym.Year = Convert.ToInt32(textYear.Text);

                    //creates a boolean variable and assign the delete functionality it
                    bool SuccessDelete = fyc.Delete(fym);

                    //checks if the record is deleted successfully or not
                    if (SuccessDelete == true)
                    {
                        //displays a success message if record deleted successfully
                        MessageBox.Show("Year Deleted Successfully", "Update Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the text box
                        textYear.Text = "";

                        //loads the data grid view
                        loadDataGrid();

                        //disable the update and delete buttons
                        btnUpdate.Enabled = false;
                        btnDelete.Enabled = false;

                        //enables the save button
                        btnSave.Enabled = true;
                    }
                    else
                    {
                        //displays error message if the record failed to Delete
                        MessageBox.Show("Cannot Delete  Year", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    //displays exceptional error messages if any
                    MessageBox.Show(ex.Message);

                }

                return;
            }
        }

        private void textYear_Validating(object sender, CancelEventArgs e)
        {
            //to check if the year already exists or not
            string YearName = textYear.Text;
            DataTable dtblYearExists = fyc.YearExists(YearName);

            //validating the input
            if (textYear.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textYear, "Year Cannot be Empty");
                textYear.BackColor = Color.MistyRose;
            }
            else if (dtblYearExists != null && dtblYearExists.Rows.Count > 0)
            {
                errorProvider1.SetError(textYear, "Year Already Exists In database");
                textYear.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textYear, "");
                textYear.BackColor = Color.Empty;

            }
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textSearch.Text;

            if (searchText != null)
            {
                //if a user types something in the search box, perform this operation

                DataTable dtbl = fyc.Search(searchText);
                dataGridFinancialYears.DataSource = dtbl;

                //datagrid column settings: stretches the columns to fit the entire datagrid
                dataGridFinancialYears.Columns[0].Width = 100;
                dataGridFinancialYears.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                //loads the data grid view
                loadDataGrid();
            }
        }
    }
}
