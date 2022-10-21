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

namespace BillingSystem.VIEW
{
    public partial class frmPurchase : Form
    {
        public frmPurchase()
        {
            InitializeComponent();
        }

        //creates a the data table to insert the parameters into the data grid view
        DataTable dtbl = new DataTable();

        //creates an instance of the Stakeholder Controller class
        StakeholdersController stc = new StakeholdersController();

        //creates an instance of the Products Controller
        ProductsController pc = new ProductsController();

        //creates the Transactions Controller instance
        TransactionsController tc = new TransactionsController();

        //creates the transaction Details Controller
        TransactionDetailsController tdc = new TransactionDetailsController();

        public string ReceiptNumber;

        //method to clear all text fields 
        private void clearText()
        {
            //clears the text boxes 
           // textStakeName.Text = "";
            //textType.Text = "";
            //textEmail.Text = "";
           // textPhone.Text = "";
            //textAddress.Text = "";
            textProductName.Text = "";
            textInventory.Text = "";
            textUnit.Text = "";
            textQuantity.Text = "0.00";
            textPrice.Text = "0.00";
            textSubTotal.Text = "0";
            textDiscount.Text = "0";
            textGrandTotal.Text = "";
            //textStakeSearch.Text = "";
            textProductSearch.Text = "";

            dataGridAddedProducts.DataSource = null;
            dataGridAddedProducts.Rows.Clear();


        }

        private void textStakeSearch_TextChanged(object sender, EventArgs e)
        {
            //creates a string variable for the search text box
            string textSearch = textStakeSearch.Text;

            if (textSearch != "")
            {
                //loads the search results and assign the values to their corresponding text boxes
                //stm: is the instance of the StakeholderModel
                //stc: is the instance of the StakeholdersController
                //SearchSupCus: is the search method in the StakeholdersController class
                //textSearch: is the variable name of the search text box
                StakeholderModel stm = stc.SearchSupCus(textSearch);

                //transfers the contents of the search results to their respective text boxes
                textStakeName.Text = stm.name;
                textType.Text = stm.type;
                textEmail.Text = stm.email;
                textPhone.Text = stm.tel;
                textAddress.Text = stm.address;

            }
            else
            {
                //clears all the text boxes if nothing is typed in the search text box
                textStakeSearch.Text = "";
                textStakeName.Text = "";
                textType.Text = "";
                textEmail.Text = "";
                textPhone.Text = "";
                textAddress.Text = "";

            }
        }

        private void frmPurchase_Load(object sender, EventArgs e)
        {
            //creates the columns for the data grid view when the form loads
            dtbl.Columns.Add("Product");
            dtbl.Columns.Add("Quantity");
            dtbl.Columns.Add("Unit");
            dtbl.Columns.Add("Price");

            dtbl.Columns.Add("Total");

        }

        private void textProductSearch_TextChanged(object sender, EventArgs e)
        {
            string searchProduct = textProductSearch.Text;

            //checks if the search text box has a value or not
            if (searchProduct != "")
            {
                ProductModel pmdl = pc.TransProductSearch(searchProduct);

                //transfers the contents of the search results to their respective text boxes

                textProductName.Text = pmdl.name;
                textUnit.Text = pmdl.unit;
                textInventory.Text = pmdl.quantity.ToString();
                textPrice.Text = pmdl.price.ToString();

            }
            else
            {
                //clears all the text boxes if no search is typed in the text box
                textProductName.Text = "";
                textInventory.Text = "";
                textUnit.Text = "";

                textQuantity.Text = "0.00";
                textPrice.Text = "0.00";

            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //gets the parameters to be inserted and assign them to vaiables
                string Product = textProductName.Text;
                decimal Quantity = decimal.Parse(textQuantity.Text);
                string Unit = textUnit.Text;
                decimal Price = decimal.Parse(textPrice.Text);
                decimal Inventory = decimal.Parse(textInventory.Text);

                decimal Total = Price * Quantity;

                //calculates the sub total based on the total and displays the value in the sub total text box
                decimal SubTotal = decimal.Parse(textSubTotal.Text);
                //changes the subtotal each time a value is added
                SubTotal = SubTotal + Total;


                //adds the parameters to the gata grid view; by first checking whether the product is selected or not.
                //Thus, when a product is selcted, it will be added to the data grid view, otherwise it will not added to the data grid view.
                if (Product == "")
                {
                    MessageBox.Show("You Need To Insert The Product Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }
                else if (Quantity <= 0)
                {
                    MessageBox.Show("The Quantity cannot Be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }
                else if (Price <= 0)
                {
                    MessageBox.Show("The Price cannot Be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);

                }
                else
                {
                    //adds the parameters to the data grid view
                    dtbl.Rows.Add(Product, Quantity, Unit, Price, Total);

                    //displays the parameters in the data grid view
                    dataGridAddedProducts.DataSource = dtbl;

                    //displays the sub total
                    textSubTotal.Text = SubTotal.ToString();


                    //datagrid column settings: stretches the columns to fit the entire datagrid
                    dataGridAddedProducts.Columns[0].Width = 200;
                    dataGridAddedProducts.Columns[1].Width = 70;
                    dataGridAddedProducts.Columns[2].Width = 50;
                    dataGridAddedProducts.Columns[3].Width = 100;
                    dataGridAddedProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //clears the text boxes
                    textProductSearch.Text = "";
                    textProductName.Text = "";
                    textQuantity.Text = "0.00";
                    textUnit.Text = "";
                    textPrice.Text = "0.00";
                    textInventory.Text = "0.00";

                    textDiscount.Text = "0";
                    textGrandTotal.Text = SubTotal.ToString();

                }

            }
            catch (Exception)
            {

            }
        }

        private void textDiscount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textDiscount.Text == "")
                {
                    MessageBox.Show("please Enter 0 if there is No Discount", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textGrandTotal.Text = "0.00";
                }
                else if (decimal.Parse(textDiscount.Text) >= 0)
                {
                    //if discount is available, then set the discount to the available value and proceed with the calculations
                    decimal discount = Math.Round(decimal.Parse(textDiscount.Text), 2);
                    decimal subTotal = Math.Round(decimal.Parse(textSubTotal.Text), 2);


                    //calculates the grand total from the discount
                    decimal GrandTotal = ((100 - discount) / 100) * subTotal;

                    //displays the value of the Grand Total in the Grand Total Text Box
                    textGrandTotal.Text = GrandTotal.ToString();

                }
                else
                {
                    textDiscount.Text = "0";
                    textGrandTotal.Text = "0.00";
                }

            }
            catch (Exception)
            {

            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (textStakeName.Text == "")
                {
                    MessageBox.Show("Supplier Name Cannot Be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else if (textGrandTotal.Text == "" || textGrandTotal.Text == "0" || decimal.Parse(textGrandTotal.Text) <= 0)
                {
                    MessageBox.Show("You Do Not Have Any Grand Total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {

                    string MonthXt = dateTimeSales.Value.Month.ToString();
                    string YearXt = dateTimeSales.Value.Year.ToString();

                    //gets the logged in user who created the record
                    //this will be inserted in the created_by database field
                    string creator;
                    creator = frmLogin.loggedInUser;

                    //creates an object of the TransactionModel
                    TransactionModel transModel = new TransactionModel();

                    //gets the Names of the Customer or Supplier from the text box and assign it to a variable of string data type
                    string stakeholderName = textStakeName.Text;

                    //calls the the getStakeId method from the StakeholderController and save it in the StakeholderModel variable
                    StakeholderModel stkmdl = stc.getStakeId(stakeholderName);

                    //passes the id in to the Stakeholder Model
                    transModel.stakeholder_id = stkmdl.id;

                    transModel.stakeholder_name = textStakeName.Text;

                    //gets the transaction date, grand total and discount
                    transModel.total = Math.Round(decimal.Parse(textGrandTotal.Text), 2);
                    transModel.discount = Math.Round(decimal.Parse(textDiscount.Text), 2);
                    transModel.transaction_date = dateTimeSales.Text;
                    transModel.type = "Purchase";
                    transModel.created_by = creator;
                    transModel.transaction_month = dateTimeSales.Value.Month.ToString();
                    transModel.transaction_year = dateTimeSales.Value.Year.ToString();
                    transModel.receipt_number = "";
                    transModel.paid_amount = 0;
                    transModel.return_amount = 0;

                    //adds the contents to the transaction Details Data Table in the TransactionModel
                    //note: dtbl is the name of the global data table we created at the top of the form
                    transModel.transactionDetails = dtbl;

                    //creates a boolean variable and set its default value to fales
                    bool saveTrans = false;

                    //functionality to save the sales or purchase transaction into the database by using a TRANSACTIONSCOPE
                    //NOTE: you need to add a reference(System.Transactions) for the TransactionScope
                    using (TransactionScope trscope = new TransactionScope())
                    {
                        //creates a transaction id and set its value to -1
                        int transId = -1;

                        //creates a boolean value to insert the transactions
                        bool transInsert = tc.CreateTransaction(transModel, out transId);

                        //creates for loop to insert the Transaction Details
                        for (int i = 0; i < dtbl.Rows.Count; i++)
                        {
                            //gets the product details
                            TransactionDetailModel tdmdl = new TransactionDetailModel();

                            //creates a variable for the product name
                            string productname = dtbl.Rows[i][0].ToString();

                            ProductModel pmdl = pc.getProductId(productname);

                            //passing the id to the transaction details
                            tdmdl.product_id = pmdl.id;

                            //gets the price, quantity and total from the data table
                            tdmdl.quantity = Math.Round(decimal.Parse(dtbl.Rows[i][1].ToString()), 2);
                            tdmdl.unit = dtbl.Rows[i][2].ToString();
                            tdmdl.price = Math.Round(decimal.Parse(dtbl.Rows[i][3].ToString()), 2);
                            tdmdl.total = Math.Round(decimal.Parse(dtbl.Rows[i][4].ToString()), 2);
                            tdmdl.stakeholder_id = stkmdl.id;
                            tdmdl.created_by = creator;
                            tdmdl.created_date = dateTimeSales.Value;

                            //increases the product quantity when it is purchased
                            bool incProd = pc.IncProduct(tdmdl.product_id, tdmdl.quantity);

                            //saves the transaction details into the database
                            bool saveTransDetails = tdc.InsertTransactionDetails(tdmdl);
                            saveTrans = transInsert && incProd && saveTransDetails;
                        }

                        if (saveTrans == true)
                        {
                            //completes the transactionscope
                            trscope.Complete();

                            MessageBox.Show("Purchase Completed Succesfully !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //clears the text boxes after saving data
                            clearText();
                        }
                        else
                        {
                            MessageBox.Show("Failed Transcation !!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }

                    //clears the text boxes after 
                    clearText();

                    this.Close();
                    frmPurchase Purschaseform = new frmPurchase();
                    Purschaseform.ShowDialog();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textStakeSearch_Validating(object sender, CancelEventArgs e)
        {

        }

        private void textProductSearch_Validating(object sender, CancelEventArgs e)
        {
            //validates the search text box
            if (textProductSearch.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(textProductSearch, "Type a Product Name or ID to Display its Values");
            }
            else
            {
                errorProvider1.SetError(textProductSearch, "");
            }
        }

        private void textStakeSearch_Validating_1(object sender, CancelEventArgs e)
        {
            //validates the search text box
            if (textStakeSearch.Text == "")
            {
                e.Cancel = true;
                errorProvider1.SetError(textStakeSearch, "Type a Name or ID to Search For Supplier");
            }
            else
            {
                errorProvider1.SetError(textStakeSearch, "");
            }
        }

        private void textQuantity_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textQuantity.Text == "" || textQuantity.Text == "0" || decimal.Parse(textQuantity.Text) <= 0)
                {
                    errorProvider1.SetError(textQuantity, "You Need To Add a Quantity");
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textQuantity, "");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                textQuantity.Text = "";
            }
        }

        private void textPrice_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                if (textPrice.Text == "" || textPrice.Text == "0" || decimal.Parse(textPrice.Text) <= 0)
                {
                    errorProvider1.SetError(textPrice, "You Need To Add a Price");
                    e.Cancel = true;

                }
                else
                {
                    errorProvider1.SetError(textPrice, "");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                textPrice.Text = "";
            }
        }

        private void textInventory_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                //shows the alert if the inventory is zero, when making sales
                if (decimal.Parse(textInventory.Text) <= 0 || textInventory.Text == "" || textInventory.Text == "0")
                {
                    errorProvider1.SetError(textInventory, "No Stock Available !!");
                }
                else
                {
                    errorProvider1.SetError(textInventory, "");
                }
            }
            catch (Exception)
            {

            }
        }

        private void textDiscount_Validated(object sender, EventArgs e)
        {

        }

        private void textDiscount_Validating(object sender, CancelEventArgs e)
        {
            //clculating the discount
            try
            {
                if (textDiscount.Text == "" || decimal.Parse(textDiscount.Text) < 0)
                {
                    errorProvider1.SetError(textDiscount, "Please Enter 0 if There is No Discount !!");
                    e.Cancel = true;

                }
                else
                {
                    errorProvider1.SetError(textDiscount, "");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                textDiscount.Text = "";

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text boxes after 
            clearText();

            this.Close();
            frmPurchase Purschaseform = new frmPurchase();
            Purschaseform.ShowDialog();

        }
    }
}
