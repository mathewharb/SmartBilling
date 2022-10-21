using BillingSystem.MODEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.CONTROLLER
{
    class ProductsController
    {
        // APPLICATION NAME: SmartBilling
        // AUTHOR:           Mathew Harb
        // SITE:             https://github.com/mathewharb
        // EMAIL:            harbmathew@yahoo.com
        // CONTACT:          +2207425159



        //creates the database configuration 
        static string Myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //creates the select functionality
        #region SELECT
        public DataTable Select()
        {
            //creates the database connection instance
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the select functionality
            try
            {
                //creates the select query
                string sql = "SELECT id[ID], category[CATEGORY], name[PRODUCT NAME], description[DESCRIPTION], quantity[QUANTITY], unit[UNIT], price[PRICE], created_by[ADDED BY], created_date[ADDED DATE], updated_by[UPDATED BY], updated_date[UPDATED DATE] FROM products";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the sql adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents of the adapter
                adapter.Fill(dt);


            }catch(Exception ex){
                //displaysds error mesages
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

           //returns the contents of the data table
            return dt;


        }
        #endregion

        //creates the insert functionality
        #region INSERT
        public bool Insert(ProductModel pm)
        {
            //connection
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successInsert = false;

            //try, catch and finally block to implement the insert functionality
            try
            {
                //creates the insert Query
                string sql = "INSERT INTO products(category_id, unit_id, name, category, description, unit, quantity, price, created_by, Created_date ) VALUES(@category_id, @unit_id, @name, @category, @description, @unit, @quantity, @price, @created_by, @created_date)";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters 
                cmd.Parameters.AddWithValue("@category_id", pm.category_id);
                cmd.Parameters.AddWithValue("@unit_id", pm.unit_id);
                cmd.Parameters.AddWithValue("@name", pm.name);
                cmd.Parameters.AddWithValue("@category", pm.category);
                cmd.Parameters.AddWithValue("@description", pm.description);
                cmd.Parameters.AddWithValue("@unit", pm.unit);
                cmd.Parameters.AddWithValue("@quantity", pm.quantity);
                cmd.Parameters.AddWithValue("@price", pm.price);
                cmd.Parameters.AddWithValue("@created_by", pm.created_by);
                cmd.Parameters.AddWithValue("@created_date",pm.created_date);

                //opens the connection
                conn.Open();

                //creates the integer variable and assign the execute non query function to it
                int row = cmd.ExecuteNonQuery();

                //checks if the insert functionality succeeds or not,

                if (row>0)
                {
                    //if the insert is successful, then set the boolean value of succeeInsert to true
                    successInsert = true;
                }
                else
                {
                    //if the insert is fails, then set the boolean value of succeeInsert to false
                    successInsert = false;
                }


            }catch(Exception ex)
            {
                //display error messages
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //closes the connection
                conn.Close();
            }

            return successInsert;
        }
        #endregion

        //creates the update functionality
        #region UPDATE
        public bool Update(ProductModel pm)
        {
            //database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successUpdate = false;

            //try, catch and finally block to implement the update functionality
            try
            {
                //creates the update Query
                //NOTE: The update query should include the ID of the item to be updated
                string sql = "UPDATE products SET category_id=@category_id, unit_id=@unit_id, name=@name, category=@category, description=@description, unit=@unit, quantity=@quantity, price=@price, updated_by=@updated_by, updated_date=@updated_date WHERE id=@id";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //parssing the parameters with values
                cmd.Parameters.AddWithValue("@category_id", pm.category_id);
                cmd.Parameters.AddWithValue("@unit_id", pm.unit_id);
                cmd.Parameters.AddWithValue("@name", pm.name);
                cmd.Parameters.AddWithValue("@category", pm.category);
                cmd.Parameters.AddWithValue("@description", pm.description);
                cmd.Parameters.AddWithValue("@unit", pm.unit);
                cmd.Parameters.AddWithValue("@quantity", pm.quantity);
                cmd.Parameters.AddWithValue("@price", pm.price);
                cmd.Parameters.AddWithValue("@updated_by", pm.updated_by);
                cmd.Parameters.AddWithValue("@updated_date", pm.updated_date);
                cmd.Parameters.AddWithValue("@id", pm.id);

                //opens the database connection
                conn.Open();

                int row = cmd.ExecuteNonQuery();

                if (row>0)
                {
                    successUpdate = true;
                }
                else
                {
                    successUpdate = false;
                }

            }catch(Exception ex)
            {
                //displays error messages
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the connection
                conn.Close();
            }

            return successUpdate;
        }
        #endregion

        //creates the delete functionality
        #region DELETE
        public bool Delete(ProductModel pm)
        {
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successDelete = false;
            try
            {
                //delete query
                string sql = "DELETE FROM products WHERE id=@id";

                //execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //bind the parameter with the value
                cmd.Parameters.AddWithValue("@id", pm.id);

                //opens the database connection 
                conn.Open();

                //execute non query 
                int row = cmd.ExecuteNonQuery();

                if (row>0)
                {
                    successDelete = true;
                }
                else
                {
                    successDelete = false;
                }

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return successDelete;
        }
        #endregion

        //creates the search functionality
        #region SEARCH

        public DataTable SearchProduct(string search)
        {
            //connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //data table to hold the temporary data
            DataTable dt = new DataTable();

            try
            {
                //search query
                string sql = "SELECT id[ID], name[Product Name], category[Category], description[Description], unit[Unit], quantity[QTY], price[Price], created_by[Created By], created_date[Created Date], updated_by[Updated By], updated_date[Updated Date] FROM products WHERE id LIKE '%" + search+"%' OR name LIKE '%"+search+"%' OR category LIKE '%"+search+"%'  ";

                //executes the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fill the data table with the contents of the adapter
                adapter.Fill(dt);

            }catch(Exception ex)
            {
                //displays error messages
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the connection
                conn.Close();
            }

            return dt;
        }

        #endregion

        //method to search for a product when making purchase or sales
        #region SEARCH PRODUCT METHOD FOR PURCHASE OR SALES FUNCTIONALITY
        public ProductModel TransProductSearch(string search)
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates an instance of the model and return it
            ProductModel pmdl = new ProductModel();

            //creates a datatable to store the temporary data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the search functionality
            try
            {
                //sql query to search products 
                string sql = "SELECT name, unit, quantity, price FROM products WHERE id LIKE '%"+search+"%' OR name LIKE '%"+search+"%' ";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql database adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the ProductModel
                if (dt.Rows.Count>0)
                {
                    //pass the data table values to the ProductModel
                    pmdl.name = dt.Rows[0]["name"].ToString();
                    pmdl.unit = dt.Rows[0]["unit"].ToString();
                    pmdl.quantity = decimal.Parse(dt.Rows[0]["quantity"].ToString());
                    pmdl.price = decimal.Parse(dt.Rows[0]["price"].ToString());

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

            return pmdl;
        }
        #endregion

        //method to get the product Id based on the Name of the Product when making sales or purchase
        #region GET PRODUCT ID FROM PRODUCT NAME
        public ProductModel getProductId(string getProductName)
        {
            //creates an object of the ProductModel
            ProductModel pmdl = new ProductModel();

            //creates the database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the Data Table to hold the Temporary Data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the  functionality
            try
            {
                //sql query to get the id(getting the Name of the product based on the Id)
                string sql = "SELECT id FROM products WHERE name='"+getProductName+"' ";

                //creates the sql adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //opens the database connection
                conn.Open();

                //fills the Data Table with the contents of the Data Adapter
                adapter.Fill(dt);

                //if the data table returns a value, then the values will be passed to the ProductModel
                if (dt.Rows.Count > 0)
                {
                   pmdl.id = int.Parse(dt.Rows[0]["id"].ToString());

                }



            }
            catch (Exception ex)
            {
                //displays error messages
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }


            //returns the StakeholderModel variable
            return pmdl;
        }

        #endregion

        //1. method to get the Quantity from the Product Id when increasing or decreasing product
        #region GET PRODUCT QUANTITY BASED ON ID
        //the metho is of decimal data type
        public decimal GetQuantityId(int productId)
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //variable of decimal data type with default value of 0
            decimal qtyId = 0;

            //datatable to hold temporal data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query to get the quantity from the database
                string sql = "SELECT quantity FROM products WHERE id = "+productId;

                //sql command and sql adapter to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table withe the contents of the data adapter
                adapter.Fill(dt);

                //checks whether the data table returns a value or not
                if (dt.Rows.Count>0)
                {
                    //if the data table returns a value, then it will be passed into the quantity decimal variable
                    qtyId = decimal.Parse(dt.Rows[0]["quantity"].ToString());


                }
            }catch(Exception ex)
            {
                //outputs error messages if there is any
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

            return qtyId;

        }
        #endregion

        //2. method to update quantity(to be used int the increment and decrement method below)
        #region UPDATE QUANTITY
        //this method is of boolean data type
        public bool UpdateQuantity(int productId, decimal Quantity)
        {
            //variable of boolean data type with a default value of fales;
            bool SuccessUpdateQty = false;

            //creates the data abse connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query to update the quantity
                string sql = "UPDATE products SET quantity=@quantity WHERE id=@id";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //passintg the values into the query through parameters
                cmd.Parameters.AddWithValue("@quantity", Quantity);
                cmd.Parameters.AddWithValue("@id", productId);

                //opens the database connection
                conn.Open();

                //variable of integer data type to check whether the query is executed successfully or not
                int row = cmd.ExecuteNonQuery();

                //checks if the executed successfully or not
                if (row>0)
                {
                    //if row is greater than 0 then the query executes successfully
                    SuccessUpdateQty = true;
                }
                else
                {
                    SuccessUpdateQty = false;
                }
   
            }
            catch (Exception ex)
            {
                //outputss any error message if there is any
                MessageBox.Show(ex.Message);

            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

            return SuccessUpdateQty;
        }

        #endregion

       //3. method to increase the quantity when a product is purchased from supplier
        #region INCREASE QUANTITY FROM PURCHASE
        //the method is of decimal data typr
        public bool IncProduct(int productId, decimal IncQuantity)
        {
            //variable of boolean data type with a default value of false
            bool SuccessInc = false;

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the functionality
            try
            {
                //variable of decimal data type to get the quantity based on id; from the database
                //also, here we use the method ceated on top called GetQuantityId
                decimal currentQuantity = GetQuantityId(productId);

                //increases the current quantity when its purchased
                decimal newQuantity = currentQuantity + IncQuantity;

                //updates the quantity
                //note: this uses the method created above called UpdateQuantity
                SuccessInc = UpdateQuantity(productId, newQuantity);


            }
            catch (Exception ex)
            {
                //outputs error messages if there is any
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

            return SuccessInc;
        }

        #endregion

        //4. method to Decrease the quantity when a product is Sold
        #region DECREASE QUANTITY ON SALE
        //the method is of decimal data type
        public bool DecProduct(int productId, decimal IncQuantity)
        {
            //variable of boolean data type with a default value of false
            bool SuccessDec = false;

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the functionality
            try
            {
                //variable of decimal data type to get the quantity based on id; from the database
                //also, here we use the method ceated on top called GetQuantityId
                decimal currentQuantity = GetQuantityId(productId);

                //Decreases the current quantity when it is Sold
                decimal newQuantity = currentQuantity - IncQuantity;

                //updates the quantity
                //note: this uses the method created above called UpdateQuantity
                SuccessDec = UpdateQuantity(productId, newQuantity);
            }
            catch (Exception ex)
            {
                //outputs error messages if there is any
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

           return SuccessDec;

        }

        #endregion

        //method to show product report from category selection
        #region SHOW PRODUCT FROM CATEGORY SELECTION
        public DataTable ProductFromCategory(string CategorySelect)
        {
            //sql connection
            SqlConnection conn = new SqlConnection(Myconstr);

            DataTable dt = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query
                string sql = "SELECT id[ID], category[CATEGORY], name[PRODUCT NAME], description[DESCRIPTION], quantity[QUANTITY], unit[UNIT], price[PRICE], created_by[ADDED BY], created_date[ADDED DATE], updated_by[UPDATED BY], updated_date[UPDATED DATE]  FROM products WHERE category='" + CategorySelect+"' ";

                //sql command and sql data adapter to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open the database connection
                conn.Open();

                //fills the data table with the contents of the data adapter
                adapter.Fill(dt);



            }catch(Exception ex)
            {
                //displays error messages if any
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

            return dt;
                 
        }
        #endregion

        //method to display products in the data grid view
        #region SELECT
        public DataTable AllProducts()
        {
            //creates the database connection instance
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the select functionality
            try
            {
                //creates the select query
                string sql = "SELECT id[ID], name[Product Name], category[Category], description[Description], unit[Unit], quantity[QTY], price[Price], created_by[Created By], created_date[Created Date], updated_by[Updated By], updated_date[Updated Date] FROM products";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the sql adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents of the adapter
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {
                //displaysds error mesages
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

            //returns the contents of the data table
            return dt;


        }
        #endregion

    }
}
