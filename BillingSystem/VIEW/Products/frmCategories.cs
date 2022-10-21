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
    public partial class frmCategories : Form
    {
        public frmCategories()
        {
            InitializeComponent();
        }

 
        //creating an instance of the category model and controller
        CategoriesController ctc = new CategoriesController();
        CategoryModel ctm = new CategoryModel();

        //clears the contents of the textboxes
        private void clear()
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
            DataTable dtbl = ctc.AllCategories();
            dataGridCategories.DataSource = dtbl;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridCategories.Columns[0].Width = 75;
            dataGridCategories.Columns[1].Width = 200;
            dataGridCategories.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //to check if the category name already exists or not
            string CategoryName = textName.Text;
            DataTable dtblCategory = ctc.CategoryNameExists(CategoryName);

            //validates the input
            if (textName.Text.Equals(string.Empty))
            {
                textName.Focus();

                return;
            }

            if (dtblCategory != null && dtblCategory.Rows.Count > 0)
            {
                MessageBox.Show("This Category Name  Already Exist In The Database", "Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    ctm.name = textName.Text;
                    ctm.description = textDescription.Text;
                    ctm.created_by = creator;
                    ctm.created_date = DateTime.Now;

                    //calling the insert method in the controller and assigning it ta boolean variable
                    bool saveSuccess = ctc.Insert(ctm);

                    if (saveSuccess == true)
                    {
                        MessageBox.Show("category Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the text boxes
                        clear();

                        //loads the data grid view
                         loadData();


                    }
                    else
                    {
                        MessageBox.Show("Failed To Insert Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                   //loads the data grid view
                    loadData();

                }

        }

        private void frmCategories_Load(object sender, EventArgs e)
        {
            //loads the data grid view
            loadData();

            //clears the text boxes
            clear();


        }

        private void dataGridCategories_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checks if only one row is selected 
            if (dataGridCategories.SelectedRows.Count == 1)
            {
                //binds the content of the datagrid view with the text box to be updated

                int rowIndex = e.RowIndex;

                textId.Text = dataGridCategories.Rows[rowIndex].Cells[0].Value.ToString();
                textName.Text = dataGridCategories.Rows[rowIndex].Cells[1].Value.ToString();
                textDescription.Text = dataGridCategories.Rows[rowIndex].Cells[2].Value.ToString();

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
                MessageBox.Show("You can Only Select One Row At A Time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clears the text boxes
                clear();

                //loads the data grid view
                loadData();
            }            

        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                    ctm.id = Convert.ToInt32(textId.Text);
                    ctm.name = textName.Text;
                    ctm.description = textDescription.Text;

                    bool updateSuccess = ctc.Update(ctm);

                    if (updateSuccess == true)
                    {
                        MessageBox.Show("category Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                    //clears the text boxes
                    clear();

                    //loads the data grid view
                    loadData();


                }
                    else
                    {
                        MessageBox.Show("Failed To Update Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                //loads the data grid view
                loadData();

               }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();

            //loads the data grid view
            loadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want To Delete This Category ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    //delete functionality
                    ctm.id = Convert.ToInt32(textId.Text);

                    bool deleteSuccess = ctc.Delete(ctm);

                    if (deleteSuccess == true)
                    {
                        MessageBox.Show("Category Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the text boxes
                        clear();

                        //loads the data grid view
                        loadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed To Delete Category", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = textSearch.Text;

            if (searchText != null)
            {
                //if a user types something in the search box, perform this operation

                DataTable dtbl = ctc.SearchCategory(searchText);
                dataGridCategories.DataSource = dtbl;
            }
            else
            {
                //loads the data grid view
                loadData();
            }

        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            //to check if the category name already exists or not
            string CategoryName = textName.Text;
            DataTable dtblCategory = ctc.CategoryNameExists(CategoryName);

            //validating the input
            if (textName.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textName, "Category Name Cannot be Empty");
                textName.BackColor = Color.MistyRose;
            }
            else if (dtblCategory != null && dtblCategory.Rows.Count > 0)
            {
                errorProvider1.SetError(textName, "Category Name Already Exists In database");
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
    }
}
