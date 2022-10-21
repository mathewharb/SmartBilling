using BillingSystem.CONTROLLER;
using BillingSystem.MODEL;
using BillingSystem.VIEW.FrontendSetup;
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
    public partial class frmSales : Form
    {
        public frmSales()
        {
            InitializeComponent();
        }

        public static System.Drawing.Printing.PrintDocument PrintDoc2 = new System.Drawing.Printing.PrintDocument();
        public static System.Windows.Forms.PrintDialog printDLG2 = new System.Windows.Forms.PrintDialog();

        //creates a the data table to insert the parameters into the data grid view
        DataTable dtbl = new DataTable();       

        //creates an instance of the Stakeholder Controller class
        StakeholdersController stc = new StakeholdersController();

        //creates an instance of the Products Controller
        ProductsController pc = new ProductsController();

        ProductModel pm = new ProductModel();

        //creates the Transactions Controller instance
        TransactionsController tc = new TransactionsController();

        //creates the transaction Details Controller
        TransactionDetailsController tdc = new TransactionDetailsController();

        AppSettingsController ASC = new AppSettingsController();

        //global variable to handle the deletinf of a selected row
        int index = 0;

        public string ReceiptNumber;
        public Bitmap ReceiptImage;

        public static string PName;

        //method to clear all text fields
        private void clearText()
        {
            //clears the text boxes 
            //textStakeName.Text = "";
            //textType.Text = "";
            //textEmail.Text = "";
            //textPhone.Text = "";
            //textAddress.Text = "";
            textProductName.Text = "";
            textInventory.Text = "";
            textUnit.Text = "";
            textQuantity.Text = "0.00";
            textPrice.Text = "0.00";
            textSubTotal.Text = "0";
            textDiscount.Text = "";
            textPaidAmount.Text = "";
            lblReturnAmount.Text = "";
            textGrandTotal.Text = "";
            //textStakeSearch.Text = "";
           // textProductSearch.Text = "";

            dataGridAddedProducts.DataSource = null;
            dataGridAddedProducts.Rows.Clear();

            //disables the save button when the form loads
            btnSave.Enabled = false;

        }

        private void groupCustomerSupplier_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textStakeHolderSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPurchaseSales_Load(object sender, EventArgs e)
        {

            clearText();

            //disables the save button when the form loads
            btnSave.Enabled = false;

            //creates the columns for the data grid view when the form loads
            dtbl.Columns.Add("Product");
            dtbl.Columns.Add("Quantity");
            dtbl.Columns.Add("Unit");
            dtbl.Columns.Add("Price");

            dtbl.Columns.Add("Total");
            //dtbl.Columns.Add("TotalAmount");

        }



        private void textStakeSearch_TextChanged(object sender, EventArgs e)
        {
            //creates a string variable for the search text box
            string textSearch = textStakeSearch.Text;

            if (textSearch!="")
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

        private void textProductSearch_TextChanged(object sender, EventArgs e)
        {
            string searchProduct = textProductSearch.Text;

            //checks if the search text box has a value or not
            if (searchProduct!="")
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

        private void textStakeSearch_Validating(object sender, CancelEventArgs e)
        {
            //validates the search text box
            if (textStakeSearch.Text=="")
            {
                e.Cancel = true;
                errorProvider1.SetError(textStakeSearch, "Type a Name or ID to Search For Customer");
            }
            else
            {
                errorProvider1.SetError(textStakeSearch, "");
            }
        }

        private void textProductSearch_Validating(object sender, CancelEventArgs e)
        {
            //validates the search text box
            if (textProductSearch.Text=="")
            {
                e.Cancel = true;
                errorProvider1.SetError(textProductSearch, "Type a Product Name or ID to Display its Values");
            }
            else
            {
                errorProvider1.SetError(textProductSearch, "");
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
                decimal TotalAmount=0;

                //decimal TotalQuantity = 0;


                //calculates the sub total based on the total and displays the value in the sub total text box
                decimal SubTotal = decimal.Parse(textSubTotal.Text);
                //changes the subtotal each time a value is added
                SubTotal = SubTotal + Total;

                // decimal TotalAmount = SubTotal;

                //adds the parameters to the gata grid view; by first checking whether the product is selected or not.
                //Thus, when a product is selcted, it will be added to the data grid view, otherwise it will not added to the data grid view.

                ProductModel pmdl = pc.TransProductSearch(textProductSearch.Text);
                string StockCount = pmdl.quantity.ToString();

                if (Product == "")
                {
                    MessageBox.Show("You Need To Insert The Product Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (Quantity <= 0)
                {
                    MessageBox.Show("The Quantity cannot Be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (Price <= 0)
                {
                    MessageBox.Show("The Price cannot Be Zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    return;
                }
                if (decimal.Parse(StockCount) <= 0 || StockCount=="0" || textInventory.Text=="0")
                {
                    MessageBox.Show("No Stock is Available For Sale", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textInventory.BackColor = Color.MistyRose;
                    
                }
                else if(decimal.Parse(StockCount) < decimal.Parse(textQuantity.Text))
                {
                    MessageBox.Show("You Have Insufficent Stock To Make This Sale", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    textInventory.BackColor = Color.MistyRose;

                }
                else
                {

                    textInventory.BackColor = Color.Empty;

                    //adds the parameters to the data grid view
                    dtbl.Rows.Add(Product, Quantity, Unit, Price, Total);

                    //displays the parameters in the data grid view
                    dataGridAddedProducts.DataSource = dtbl;

                    //datagrid column settings: stretches the columns to fit the entire datagrid
                    dataGridAddedProducts.Columns[0].Width = 200;
                    dataGridAddedProducts.Columns[1].Width = 70;
                    dataGridAddedProducts.Columns[2].Width = 50;
                    dataGridAddedProducts.Columns[3].Width = 100;
                    //dataGridAddedProducts.Columns[4].Width = 100;
                    // dataGridAddedProducts.Columns[5].Width = 0;
                    //dataGridAddedProducts.Columns[5].Visible = false;
                    dataGridAddedProducts.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    //displays the sub total
                    // textSubTotal.Text = SubTotal.ToString();

                    //displays the sub total
                    // decimal TotalAmount = 0;
                    for (int i = 0; i < dataGridAddedProducts.Rows.Count; i++)
                    {
                        TotalAmount += Convert.ToDecimal(dataGridAddedProducts.Rows[i].Cells[4].Value);
                    }

                        textSubTotal.Text = TotalAmount.ToString();
                        //enables the save button when the subtotal has a value
                        btnSave.Enabled = true;

                        //clears the text boxes
                        textProductSearch.Text = "";
                        textProductName.Text = "";
                        textQuantity.Text = "0.00";
                        textUnit.Text = "";
                        textPrice.Text = "0.00";
                        textInventory.Text = "0.00";

                        textDiscount.Text = "";
                        textGrandTotal.Text = SubTotal.ToString();
                        textPaidAmount.Text = "";
                        lblReturnAmount.Text = "";


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

                if(decimal.Parse(textDiscount.Text)>=0)
                {
                    //if discount is available, then set the discount to the available value and proceed with the calculations
                    decimal discount = Math.Round(decimal.Parse(textDiscount.Text), 2);
                    decimal subTotal = Math.Round(decimal.Parse(textSubTotal.Text), 2);


                    //calculates the grand total from the discount
                    decimal GrandTotal = ((100 - discount) / 100) * subTotal;

                    //displays the value of the Grand Total in the Grand Total Text Box
                    textGrandTotal.Text = GrandTotal.ToString();

                    //resets the paid amount to nothing
                    textPaidAmount.Text = "";

                    return;
                }
                //else
                //{
                //    textDiscount.Text = "0";
                //    textGrandTotal.Text = "0.00";
                //}

            }
            catch (Exception) {
                  
                }
            finally
            {
                //resets the paid amount to nothing
                textPaidAmount.Text = "";
            }

         


        }

        private void textVat_TextChanged(object sender, EventArgs e)
        {
 
   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (textStakeName.Text == "")
                {
                    MessageBox.Show("Customer Name Cannot Be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                else if (textGrandTotal.Text == "" || textGrandTotal.Text == "0" || decimal.Parse(textGrandTotal.Text) <= 0)
                {
                    MessageBox.Show("You Do Not Have Any Grand Total", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {
                    //checks if the paid amount is a negative value
                    if (decimal.Parse(textPaidAmount.Text) <=0)
                    {
                        MessageBox.Show("You Neded To Make A Payment", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);                       
                    }
                    else if (decimal.Parse(lblReturnAmount.Text) < 0 || lblReturnAmount.Text==null)
                    {
                        MessageBox.Show("Please Settle The Pending Balance", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (textDiscount.Text == "" || decimal.Parse(textDiscount.Text) < 0)
                    {
                        MessageBox.Show("please Enter 0 if there is No Discount", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        textGrandTotal.Text = "0.00";

                    }
                    else
                    {
                         string ReceiptDate = " " + DateTime.Now.ToShortDateString().ToString();
                        //generate random value for the receipt number
                        Random rand = new Random();
                        int randValue = rand.Next(0, 1000);
                        string MonthXt = dateTimeSales.Value.Month.ToString();
                        string YearXt = dateTimeSales.Value.Year.ToString();
                        // generate a unique name for the receipt number
                        ReceiptNumber = " " + "HB" + randValue + MonthXt + YearXt;

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
                        transModel.type = "Sales";
                        transModel.created_by = creator;
                        transModel.transaction_month=dateTimeSales.Value.Month.ToString();
                        transModel.transaction_year = dateTimeSales.Value.Year.ToString();
                        transModel.receipt_number = ReceiptNumber;
                        transModel.paid_amount = Math.Round(decimal.Parse(textPaidAmount.Text), 2);
                        transModel.return_amount = Math.Round(decimal.Parse(lblReturnAmount.Text), 2);

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
                                

                                //Decreases the product quantity when it is Sold
                                bool decProd = pc.DecProduct(tdmdl.product_id, tdmdl.quantity);

                                //saves the transaction details into the database
                                bool saveTransDetails = tdc.InsertTransactionDetails(tdmdl);
                                saveTrans = transInsert && decProd && saveTransDetails;
                            }

                            if (saveTrans == true)
                            {
                                //completes the transactionscope
                                trscope.Complete();

                                MessageBox.Show("Sales Completed Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);



                                string DBPrinter = PName;
                                //SELECTS A PRINTER
                                if (DBPrinter !="")
                                {
                                    DataGridViewRowCollection prodAdded;
                                    prodAdded = dataGridAddedProducts.Rows;

                                    //DRAWS THE RECEIPT
                                    ReceiptImage = DrawReceipt(prodAdded, ReceiptNumber, ReceiptDate, decimal.Parse(textGrandTotal.Text));

                                    //sets the print control to have the same settings as the print dialog
                                    //using the same printer
                                    PrintDoc.PrinterSettings.PrinterName = DBPrinter;

                                    PrintDoc.Print();
                                }

                                //if (printDLG.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                //{
                                //    PrintDoc.PrinterSettings = printDLG.PrinterSettings;

                                //    PrintDoc.Print();
                                //}


                                //clears the text boxes after saving data
                                clearText();
 
                            }
                            else
                            {
                                MessageBox.Show("Failed Transcation !!");
                            }
                         

                        }


                        //clears the text boxes 
                        clearText();

                        this.Close();
                        frmSales salesform = new frmSales();
                        salesform.ShowDialog();


                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

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

                    //resets the paid amount to nothing
                    textPaidAmount.Text = "";

                }
                else
                {
                    errorProvider1.SetError(textDiscount, "");

                    //resets the paid amount to nothing
                    textPaidAmount.Text = "";
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                textDiscount.Text = "";

                //resets the paid amount to nothing
                textPaidAmount.Text = "";

            }

        }

        private void textVat_Validating(object sender, CancelEventArgs e)
        {
     


        }

        private void textGrandTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void textPaidAmount_TextChanged(object sender, EventArgs e)
        {
                
                try
                {
                decimal paidtext = Convert.ToDecimal(textPaidAmount.Text.Trim());
                if (paidtext <=0 || textPaidAmount.Text.Equals(string.Empty) ||textPaidAmount.Text.Length <=0)
                    {
                        MessageBox.Show("You Need To Add a paid Amount", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                       lblReturnAmount.Text = "0.00";

                    }
                    else
                    {

                        //checks the paid amount and calculate the return amount
                        decimal grandTotal = decimal.Parse(textGrandTotal.Text);
                        decimal amountPaid = decimal.Parse(textPaidAmount.Text);

                        decimal amountReturn = Math.Round(amountPaid - grandTotal, 2);

                        //diaplays the amount to be returned 
                        lblReturnAmount.Text = amountReturn.ToString();
                    }

                }

                catch (Exception)
                {
                // MessageBox.Show("You Need To Enter A Numeric Value");
                lblReturnAmount.Text = "0.00";
            }


        }

        private void textReturnAmount_TextChanged(object sender, EventArgs e)
        {
          

        }

        private void textInventory_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                ProductModel pmdl = pc.TransProductSearch(textProductSearch.Text);
                string StockCount = pmdl.quantity.ToString();

                //shows the alert if the inventory is zero, when making sales
                if (decimal.Parse(StockCount) <= 0 || textInventory.Text == "" || textInventory.Text == "0")
                {
                    errorProvider1.SetError(textInventory, "No Stock Available !!");
                    textInventory.BackColor = Color.MistyRose;
                    textQuantity.Focus();
                }

                else if (decimal.Parse(StockCount) <= decimal.Parse(textQuantity.Text))
                {
                    errorProvider1.SetError(textInventory, "Insufficent Stock To Make This Sale");
                    textInventory.BackColor = Color.MistyRose;
                    textQuantity.Focus();
                }
                else
                {
                    errorProvider1.SetError(textInventory, "");
                    textInventory.BackColor = Color.Empty;
                }
            }
            catch (Exception)
            {

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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

                textQuantity.Text = "";
            }
        }

        private void textPrice_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAdd_Validating(object sender, CancelEventArgs e)
        {
          

           
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
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);

                textPrice.Text = "";
            }
        }

        private void textInventory_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridAddedProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textStakeName_TextChanged(object sender, EventArgs e)
        {

        }

        private void textQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text boxes 
            clearText();

            this.Close();
            frmSales salesform = new frmSales();
            salesform.ShowDialog();
        }

        private void dataGridAddedProducts_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            //handles the right clicks, when a user selects a row and right clicks
            if (e.Button == MouseButtons.Right)
            {
                //ensures that the row that the user right clicks is selected
                //selects the entire row
                dataGridAddedProducts.Rows[e.RowIndex].Selected = true;

                index = e.RowIndex;

                //sets the current cell where the user right clicks
                //in this case, it only shows the context menu i.e "Delete"
                dataGridAddedProducts.CurrentCell = dataGridAddedProducts.Rows[e.RowIndex].Cells[1];
                //displays the context menu
                contextMenuStrip1.Show(dataGridAddedProducts, e.Location);
                contextMenuStrip1.Show(Cursor.Position);

            }
        }

        private void contextMenuStrip1_Click(object sender, EventArgs e)
        {
            //handles the click event of the contextmenustrip
            //deletes the selected row

            ////checks if the row is new or empty, before deleting 
            if (!dataGridAddedProducts.Rows[index].IsNewRow)
            {
                //removes a selected row from the data grid view
                dataGridAddedProducts.Rows.RemoveAt(index);

                decimal TotalAmount= Convert.ToDecimal(dataGridAddedProducts.Rows[0].Cells[4].Value);
                decimal textSubTotal2 = Convert.ToDecimal(textSubTotal.Text);
                for (int i = 0; i > dataGridAddedProducts.Rows.Count; i++)
                {
                    //increases the value of the subtotal when a row is added;
                    TotalAmount += Convert.ToDecimal(dataGridAddedProducts.Rows[i].Cells[4].Value);
                    
                   
                }
                if (TotalAmount >0)
                {
                    //reduces the value of the subtotal when a row is removed;
                    textSubTotal.Text = (textSubTotal2 - TotalAmount).ToString();

                        textDiscount.Text = "";

                        textGrandTotal.Text ="";

                        //resets the paid amount to nothing
                        textPaidAmount.Text = "";
                }
                else
                {
                    //clears the text boxes when all the rows are deleted
                    // clearText();
                    textSubTotal.Text = "0";

                    dataGridAddedProducts.DataSource = null;
                    dataGridAddedProducts.Rows.Clear();

                    textDiscount.Text = "";

                    textGrandTotal.Text = "";

                    //resets the paid amount to nothing
                    textPaidAmount.Text = "";
                }


            }


        }

        private void dataGridAddedProducts_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void textSubTotal_TextChanged(object sender, EventArgs e)
        {

        }

        private void textSubTotal_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textPaidAmount_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                decimal i=0;
                i = decimal.Parse(textPaidAmount.Text);
                if (i <= 0)
                {
                    errorProvider1.SetError(textPaidAmount, "You Need To Add a paid Amount");
                    lblReturnAmount.Text = "0.00";
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textPaidAmount, "");

                }
                if (i <0)
                {
                    errorProvider1.SetError(textPaidAmount, "You Need To Add a paid Amount");
                    lblReturnAmount.Text = "0.00";
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textPaidAmount, "");

                }

                if (textPaidAmount.Text == "" || textPaidAmount.Text == "0")
                {
                    errorProvider1.SetError(textPaidAmount, "You Need To Add a paid Amount");
                    lblReturnAmount.Text = "0.00";
                    e.Cancel = true;
                }
                else
                {
                    errorProvider1.SetError(textPaidAmount, "");

                }

            }
            catch (Exception)
            {
               // MessageBox.Show(ex.Message);

                textPaidAmount.Text = "";
                lblReturnAmount.Text = "0.00";
            }

        }

        private void lblReturnAmount_Click(object sender, EventArgs e)
        {

        }

        private void lblReturnAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void textProductName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblProductID_TextChanged(object sender, EventArgs e)
        {

        }


        //METHOD TO DRAW THE RECEIPT
        public static Bitmap DrawReceipt(DataGridViewRowCollection Rows, string ReceiptNo, string ReceiptDate, decimal ReceiptTotal)
        {
 
            //SETS THE BASIC RECEIPT SIZE
            int UnitHeight = 16;
            int UnitWidth = 22;
           // int FontSize= 10;

            int ReceiptWidth = 15 * UnitWidth;
            int ReceiptDetailsHeight = Rows.Count * UnitHeight;
            int ReceiptHeight = 6 * UnitWidth + ReceiptDetailsHeight;

            //creates the bitmap
            Bitmap BMP = new Bitmap(ReceiptWidth + 1 , ReceiptHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

            //creates the graphics object: to be used to draw on the bitmap itself
            Graphics GR = Graphics.FromImage(BMP);

            //fills the image with white color
            //GR.FillRectangle(Brushes.White, 0, 0, ReceiptWidth, ReceiptHeight);
            GR.Clear(Color.White);

            //DRAWS THE BASIC LINES

            //DRAWS THE HEADERS
            var LNHeaderYStart = 3 * UnitHeight;
            var LNDetailsStart = LNHeaderYStart + UnitHeight;
            //draws the rectangle with black lines:
            //Draws the first cell: the X axis is= UnitWidth * 0, the Y axis is = LNHeaderSYtart, Units=UnitWidth And the height=UnitHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 0, LNHeaderYStart, UnitWidth, UnitHeight);

            //the X axis is= UnitWidth * 1, the Y axis is = LNHeaderSYtart, with Units=UnitWidth * 5 And the height=UnitHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 1, LNHeaderYStart, UnitWidth * 5, UnitHeight);

            //the X axis is= UnitWidth*6, the Y axis is = LNHeaderSYtart, with Units=UnitWidth * 2 And the height=UnitHeight
            GR.DrawRectangle(Pens.Black, UnitWidth*6, LNHeaderYStart, UnitWidth * 2, UnitHeight);

            //the X axis is=UnitWidth * 8, the Y axis is = LNHeaderSYtart, with Units=UnitWidth * 2 And the height=UnitHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 10, LNHeaderYStart, UnitWidth * 2, UnitHeight);

            //the X axis is=UnitWidth * 10, the Y axis is = LNHeaderSYtart, with Units=UnitWidth * 2 And the height=UnitHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 8, LNHeaderYStart, UnitWidth * 2, UnitHeight);

            //the X axis is= UnitWidth * 12, the Y axis is = LNHeaderSYtart, with Units=UnitWidth * 3 And the height=UnitHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 12, LNHeaderYStart, UnitWidth * 3, UnitHeight);



            //DRAWS THE DETAILS PART
            //Draws the first cell: the X axis is= UnitWidth * 0, the Y axis is = LNDetailsStart, Units=UnitWidth * 1 And the height=ReceiptDetailsHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 0, LNDetailsStart, UnitWidth * 1, ReceiptDetailsHeight);

            //the X axis is= UnitWidth * 1, the Y axis is = LNDetailsStart, with Units=UnitWidth * 5 And the height=ReceiptDetailsHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 1, LNDetailsStart, UnitWidth * 5, ReceiptDetailsHeight);

            //the X axis is= UnitWidth * 6, the Y axis is = LNDetailsStart, with Units=UnitWidth * 2 And the height=ReceiptDetailsHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 6, LNDetailsStart, UnitWidth * 2, ReceiptDetailsHeight);

            //the X axis is= UnitWidth * 8, the Y axis is = LNDetailsStart, with Units=UnitWidth * 2 And the height=ReceiptDetailsHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 10, LNDetailsStart, UnitWidth * 2, ReceiptDetailsHeight);

            //the X axis is= UnitWidth * 10, the Y axis is = LNDetailsStart, with Units=UnitWidth * 2 And the height=ReceiptDetailsHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 8, LNDetailsStart, UnitWidth * 2, ReceiptDetailsHeight);

            //the X axis is= UnitWidth * 12, the Y axis is = LNDetailsStart, with Units=UnitWidth * 3 And the height=ReceiptDetailsHeight
            GR.DrawRectangle(Pens.Black, UnitWidth * 12, LNDetailsStart, UnitWidth * 3, ReceiptDetailsHeight);

            //FILLS THE RECIPT HEADER WITH TEXT
            Font FNT = new Font("Timew", 10, FontStyle.Bold);



            GR.DrawString("No", FNT, Brushes.Black, UnitWidth * 0, LNHeaderYStart);
            GR.DrawString("Item", FNT, Brushes.Black, UnitWidth * 1, LNHeaderYStart);
            GR.DrawString("Price", FNT, Brushes.Black, UnitWidth * 6, LNHeaderYStart);
            GR.DrawString("Qty", FNT, Brushes.Black, UnitWidth * 8, LNHeaderYStart);
            GR.DrawString("Unit", FNT, Brushes.Black, UnitWidth * 10, LNHeaderYStart);
            GR.DrawString("Sum", FNT, Brushes.Black, UnitWidth * 12, LNHeaderYStart);

            //FINALLY, RENDER THE TEXT ON THE RECEIPT
            int i;
            for (i=1; i <= Rows.Count-1; i++)
            {
                //creates the graphics object: to be used to draw on the bitmap itself

                //finds the Y axis
                var YLOC = UnitHeight * i + LNDetailsStart;

                //receipt numbering
               GR.DrawString(i.ToString(), FNT, Brushes.Black, UnitWidth * 0 , YLOC);

                //renders the values
                GR.DrawString(Rows[0].Cells[0].Value.ToString(), FNT, Brushes.Black, UnitWidth * 1, YLOC);
                GR.DrawString(Rows[0].Cells[3].Value.ToString(), FNT, Brushes.Black, UnitWidth * 6, YLOC);
                GR.DrawString(Rows[0].Cells[1].Value.ToString(), FNT, Brushes.Black, UnitWidth * 8, YLOC);
                GR.DrawString(Rows[0].Cells[2].Value.ToString(), FNT, Brushes.Black, UnitWidth * 10, YLOC);
                GR.DrawString(Rows[0].Cells[4].Value.ToString(), FNT, Brushes.Black, UnitWidth * 12, YLOC);

            }

            //RENDERS THE RECEIPT
            GR.DrawString("Total:" + ReceiptTotal, FNT, Brushes.Black, 0, LNDetailsStart + ReceiptDetailsHeight);

            //writes the receipt number and the receipt date
            GR.DrawString("Receipt No:" + ReceiptNo, FNT, Brushes.Black, 0, 0);
            GR.DrawString("Receipt Date:" + ReceiptDate, FNT, Brushes.Black, 0, UnitHeight);



            //ends the drawing
            return BMP;



        }



        //is used to print the document-receipt
        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //the graphics of the printer
            e.Graphics.DrawImage(ReceiptImage, 0,0, ReceiptImage.Width,ReceiptImage.Height);
            e.HasMorePages = false;
        }
    }
}
