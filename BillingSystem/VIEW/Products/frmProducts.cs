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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        //creates instance of the Products Controller and Model
        ProductsController pc = new ProductsController();
        ProductModel pm=new ProductModel();

        CategoriesController cc = new CategoriesController();

        UnitsController uc = new UnitsController();

        //clears the text boxes
        private void clearText()
        {
            textId.Text = "";
            textCategoryID.Text = "";
            textUnitID.Text = "";
            textName.Text = "";
            comboCategory.Text = "";
            textDescription.Text = "";
            comboUnit.Text = "";
            textQuantity.Text = "";
            textPrice.Text = "";

            btnSave.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

        }

        //method to load the contents of the datagrid view
        private void LoadData()
        {
            //loads the contents of the table in to the datagrid 
            DataTable dt = pc.AllProducts();
            dataGridProducts.DataSource = dt;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridProducts.Columns[0].Width = 90;
            dataGridProducts.Columns[1].Width = 210;
            dataGridProducts.Columns[2].Width = 120;
            dataGridProducts.Columns[3].Width = 200;
            dataGridProducts.Columns[4].Width = 78;
            dataGridProducts.Columns[5].Width = 100;
            dataGridProducts.Columns[6].Width = 100;
            dataGridProducts.Columns[7].Width = 100;
            dataGridProducts.Columns[8].Width = 120;
            dataGridProducts.Columns[9].Width = 100;
            dataGridProducts.Columns[10].Width = 120;
            //dataGridProducts.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }



        private void frmProducts_Load(object sender, EventArgs e)
        {

            //loads the categories and units in the combo boxes when the form loads
            //to achive thus, we have to create an instance of both the Categories and Units Controllers
            CategoriesController ctc = new CategoriesController();
            UnitsController uc = new UnitsController();

            comboCategory.DataSource = ctc.Select();
            comboUnit.DataSource = uc.Select();

            //to show the categories and units in their respective combo boxes.
            //we have to call, the display member and value member functions and specify the name of the field from the dable  we want to display.
            comboCategory.DisplayMember = "name";
            comboCategory.ValueMember = "name";

            comboUnit.DisplayMember = "name";
            comboUnit.ValueMember = "name";

            //clears the text boxes
            clearText();

            //loads the contents of the data grid view
            LoadData();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //input validations
            if (textName.Text.Equals(string.Empty))
            {
                textName.Focus();
                return;
            }
            if (comboCategory.Text.Equals(string.Empty))
            {
                comboCategory.Focus();
                return;
            }
            if (comboUnit.Text.Equals(string.Empty))
            {
                comboUnit.Focus();
                return;
            }
            if (textQuantity.Text.Equals(string.Empty))
            {
                textQuantity.Focus();
                return;
            }
            if (textPrice.Text.Equals(string.Empty))
            {
                textPrice.Focus();
                return;
            }


                                try
                                {
                                    decimal Q;
                                    decimal P;
                                    Q = decimal.Parse(textQuantity.Text);
                                    P = decimal.Parse(textPrice.Text);

                                    if (Q < 0 || P < 0)
                                    {
                                        MessageBox.Show("Quantity And Price Can Only Be Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                    }
                                    else
                                    {
                                        //gets the logged in user who created the record
                                        //this will be inserted in the created_by database field
                                        string creator;
                                        creator = frmLogin.loggedInUser;

                                        //save functionality
                                         pm.category_id = Convert.ToInt32(textCategoryID.Text);
                                         pm.unit_id = Convert.ToInt32(textUnitID.Text);
                                        pm.name = textName.Text;
                                        pm.category = comboCategory.Text;
                                        pm.description = textDescription.Text;
                                        pm.unit = comboUnit.Text;
                                        pm.quantity = Convert.ToDecimal(textQuantity.Text);
                                        pm.price = Convert.ToDecimal(textPrice.Text);
                                        pm.created_by = creator;
                                        pm.created_date = DateTime.Now;

                                        //calls the Insert method from the Products Controlle, passing the model instance, and assigning it to a variable of boolean data type.
                                        bool insertSuccess = pc.Insert(pm);

                                        //checks if the record is successfully inserted or not
                                        if (insertSuccess == true)
                                        {
                                            MessageBox.Show("Product Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            //clears the text boxes
                                            clearText();

                                           //loads the contents of the data grid view
                                            LoadData();



                                        }
                                        else
                                        {
                                            MessageBox.Show("Failed to Insert Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                                catch(Exception)
                                {
                                    //displays the  message
                                    errorProvider1.SetError(textQuantity, "Quantity Must Be a Number");
                                    errorProvider1.SetError(textPrice, "Price Must Be a Number");
                                }
                                finally
                                {
                                  //loads the contents of the data grid view
                                   LoadData();

                              }                
                      
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text boxes
            clearText();

            //loads the contents of the data grid view
            LoadData();
        }

        private void dataGridProducts_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checks if only one row is selected 
            if (dataGridProducts.SelectedRows.Count == 1)
            {
                //getting the contents of the selected row fromthe data grid view, and displaying them to their respective text boxes.

                int rowIndex = e.RowIndex;

                textId.Text = dataGridProducts.Rows[rowIndex].Cells[0].Value.ToString();
                textName.Text = dataGridProducts.Rows[rowIndex].Cells[1].Value.ToString();
                comboCategory.Text = dataGridProducts.Rows[rowIndex].Cells[2].Value.ToString();
                textDescription.Text = dataGridProducts.Rows[rowIndex].Cells[3].Value.ToString();
                comboUnit.Text = dataGridProducts.Rows[rowIndex].Cells[4].Value.ToString();
                textQuantity.Text = dataGridProducts.Rows[rowIndex].Cells[5].Value.ToString();
                textPrice.Text = dataGridProducts.Rows[rowIndex].Cells[6].Value.ToString();

                //shows the category id when a row is selected
                string categoryText = comboCategory.Text;

                if (categoryText != "")
                {
                    CategoryModel cmdl = cc.SelectCategoryID(categoryText);

                    textCategoryID.Text = cmdl.id.ToString();
                }
                //shows the unit id when a row is selected
                string unitText = comboUnit.Text;

                if (unitText != "")
                {
                    UnitModel umdl = uc.SelectUnitID(unitText);

                    textUnitID.Text = umdl.id.ToString();
                }

                //clears validation error messages
                errorProvider1.SetError(textName, "");
                errorProvider1.SetError(comboCategory, "");
                errorProvider1.SetError(comboUnit, "");
                errorProvider1.SetError(textQuantity, "");
                errorProvider1.SetError(textPrice, "");

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                btnSave.Enabled = false;
            }
            else
            {
                //displays this error message when more than one row is selected
                MessageBox.Show("You can Only Select One Row At A Time", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //clears the text boxes
                clearText();

                //loads the contents of the data grid view
                LoadData();
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //input validations
            if (textName.Text.Equals(string.Empty))
            {
                textName.Focus();
                return;
            }
            if (comboCategory.Text.Equals(string.Empty))
            {
                comboCategory.Focus();
                return;
            }
            if (comboUnit.Text.Equals(string.Empty))
            {
                comboUnit.Focus();
                return;
            }
            if (textQuantity.Text.Equals(string.Empty))
            {
                textQuantity.Focus();
                return;
            }
            if (textPrice.Text.Equals(string.Empty))
            {
                textPrice.Focus();
                return;
            }

                try
                {
                    decimal Q;
                    decimal P;
                    Q = decimal.Parse(textQuantity.Text);
                    P = decimal.Parse(textPrice.Text);

                    if (Q < 0 || P < 0)
                    {
                        MessageBox.Show("Quantity And Price Can Only Be Numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                    else
                    {

                        //gets the logged in user who created the record
                        //this will be inserted in the created_by database field
                        string creator;
                        creator = frmLogin.loggedInUser;

                        //update functionality
                        pm.id = Convert.ToInt32(textId.Text);
                        pm.category_id = Convert.ToInt32(textCategoryID.Text);
                        pm.unit_id = Convert.ToInt32(textUnitID.Text);
                        pm.name = textName.Text;
                        pm.category = comboCategory.Text;
                        pm.description = textDescription.Text;
                        pm.unit = comboUnit.Text;
                        pm.quantity = Convert.ToDecimal(textQuantity.Text);
                        pm.price = Convert.ToDecimal(textPrice.Text);
                        pm.updated_by = creator;
                        pm.updated_date = DateTime.Now;

                        //calling the update method from the Products Controller an assigning it to a variable of boolean data type
                        bool successUpdate = pc.Update(pm);

                        //checking if record is updated or not
                        if (successUpdate == true)
                        {
                            MessageBox.Show("Product Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //clears the contents of the text boxes
                            clearText();

                            //loads the contents of the data grid view
                            LoadData();


                        }
                        else
                        {
                            MessageBox.Show("failed To Update Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }

                    }

                }
                catch (Exception)
                {
                    //outputs error messages
                    errorProvider1.SetError(textQuantity, "Quantity Must Be a Number");
                    errorProvider1.SetError(textPrice, "Price Must Be a Number");
                }
                finally
                {
                    //loads the contents of the data grid view
                    LoadData();
                }

        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            //search functionality

            string searchItem = textSearch.Text;
            //checking if the user typed any search in the search text box or not
            if (searchItem !=null)
            {
                //if the user searches a record then display the results based on the search
                DataTable dtbl = pc.SearchProduct(searchItem);
                dataGridProducts.DataSource = dtbl;

            }
            else
            {

                //if the user does not type anything in the search bar then, load the contents of the data grid view
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Do You Want To Delete This Product ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
            {
                try
                {
                    //delete functionality
                    pm.id = Convert.ToInt32(textId.Text);

                    //calling the delete method from the Products Controller 
                    bool deleteSuccess = pc.Delete(pm);

                    //checking if the delete operation is successful or not
                    if (deleteSuccess == true)
                    {
                        MessageBox.Show("Product Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //clears the contents of the text boxes
                        clearText();

                        //loads the contents of the data grid view
                        LoadData();
                    }
                    else
                    {
                        MessageBox.Show("Failed To Delete Product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    //loads the contents of the data grid view
                    LoadData();
                }

                return;
            }
        }

        private void textName_Validating(object sender, CancelEventArgs e)
        {
            //validating the input box
            if (textName.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textName, "Product Name Cannot Be Empty");
                textName.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textName, "");
                textName.BackColor = Color.Empty;
            }
        }

        private void comboCategory_Validating(object sender, CancelEventArgs e)
        {
            //validation
            if (comboCategory.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(comboCategory, "You Need To Select A Category");
                comboCategory.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(comboCategory, "");
                comboCategory.BackColor = Color.Empty;
            }
        }

        private void comboUnit_Validating(object sender, CancelEventArgs e)
        {
            //validation errors
            if (comboUnit.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(comboUnit, "You Need To select A Unit");
                comboUnit.BackColor = Color.MistyRose;

            }
            else
            {
                errorProvider1.SetError(comboUnit, "");
                comboUnit.BackColor = Color.Empty;
            }
        }

        private void textQuantity_Validating(object sender, CancelEventArgs e)
        {
            //validation errors

            if (textQuantity.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textQuantity, "Quantity Cannot Be Empty");
                textQuantity.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textQuantity, "");
                textQuantity.BackColor = Color.Empty;
            }
        }

        private void textPrice_Validating(object sender, CancelEventArgs e)
        {
            //validation errors
            if (textPrice.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textPrice, "Price Cannot Be Empty");
                textPrice.BackColor = Color.MistyRose;
            }
            else
            {
                errorProvider1.SetError(textPrice, "");
                textPrice.BackColor = Color.Empty;
            }
        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void comboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gets the category id when the category name is selected from the drop down
            string categoryText = comboCategory.Text;
            if (categoryText != "")
            {
                CategoryModel cmdl = cc.SelectCategoryID(categoryText);

                textCategoryID.Text = cmdl.id.ToString();

                return;
            }
        }

        private void comboUnit_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gets the unit id when the unit name is selected from the drop down
            string unitText = comboUnit.Text;
            if (unitText != "")
            {
                UnitModel umdl = uc.SelectUnitID(unitText);

                textUnitID.Text = umdl.id.ToString();

                return;
            }
        }
    }
}
