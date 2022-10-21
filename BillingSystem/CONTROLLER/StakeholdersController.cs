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
    class StakeholdersController
    {
        // APPLICATION NAME: SmartBilling
        // AUTHOR:           Mathew Harb
        // SITE:             https://github.com/mathewharb
        // EMAIL:            harbmathew@yahoo.com
        // CONTACT:          +2207425159



        //database configuration
        static string Myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //HANDLING THE ERROR LOG FILE CREATION IN THE FOLDER CALLED "Logs"
        string locationPath = "";
        //the path to the Logs folder
        // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
        //given variable i.e "0" the length of "Application.StartupPath.Length-10"
        string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

        //creates the select functionality
        #region SELECT
        public DataTable Select()
        {
            //creates the sql connection string instance
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the temporary data table to hold the data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the functionalities
            try
            {
                //creates the query to select data from the database
                string sql = "SELECT * FROM stakeholders";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the database adapter to get the data
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());

            }
            finally
            {
                //closes the database connection
                conn.Close();
            }

            //returns the contents of thhe data table
            return dt;

        }
        #endregion

        //creates the Insert functionality
        #region INSERT
        public  bool Insert(StakeholderModel sm)
        {
            //creates the sql connection instance
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successInsert = false;

            //try catch and finally block to implement the functionalities
            try
            {
                //creates the query to insert data into the database
                string sql = "INSERT INTO stakeholders(type, name, email, tel, address, created_by, created_date ) VALUES(@type, @name, @email, @tel, @address, @created_by, @created_date)";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with its values
                cmd.Parameters.AddWithValue("@type", sm.type);
                cmd.Parameters.AddWithValue("@name", sm.name);
                cmd.Parameters.AddWithValue("@email", sm.email);
                cmd.Parameters.AddWithValue("@tel", sm.tel);
                cmd.Parameters.AddWithValue("@address", sm.address);
                cmd.Parameters.AddWithValue("@created_by", sm.created_by);
                cmd.Parameters.AddWithValue("created_date", sm.created_date);

                //opens the database connection
                conn.Open();

                //creates an integer variable and assign the execute non query functionality to it
                int row = cmd.ExecuteNonQuery();

                //checks if the variable returns value or  not, meaning record is inserted or otherwise
                if (row>0)
                {
                    successInsert = true;
                }
                else
                {
                    successInsert = false;
                }


            }catch(Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
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
        public bool Update(StakeholderModel sm)
        {
            //sql connection
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successUpdate = false;
            try
            {
                //create the query to update the data passing the id of the data to be updated
                string sql = "UPDATE stakeholders SET type=@type, name=@name, email=@email, tel=@tel, address=@address WHERE id=@id";

                //sql command toexecute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters to their respective values
                cmd.Parameters.AddWithValue("@type", sm.type);
                cmd.Parameters.AddWithValue("@name", sm.name);
                cmd.Parameters.AddWithValue("@email", sm.email);
                cmd.Parameters.AddWithValue("@tel", sm.tel);
                cmd.Parameters.AddWithValue("@address", sm.address);
                cmd.Parameters.AddWithValue("@id", sm.id);

                //opens thedatabase connection
                conn.Open();

                //creates an integer variable to hold the execute non query function
                int row = cmd.ExecuteNonQuery();

                //checks if the value returns a value or not
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
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
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
        public bool Delete(StakeholderModel sm)
        {
            //connection string
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successDelete = false;

            try
            {
                //creates the query to delete a record from the database table with the id of the item to be deleted
                string sql = "DELETE FROM stakeholders WHERE id=@id";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binding the parameters
                cmd.Parameters.AddWithValue("@id", sm.id);

                //opens the database connection
                conn.Open();

                //creates an integer variable to hold the execute non query method
                int row = cmd.ExecuteNonQuery();

                //checks if the row returns a value or not
                if (row>0)
                {
                    successDelete = true;
                }
                else
                {
                    successDelete = false; 
                }

            }
            catch (Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());


            }
            finally
            {
                //closes the connection
                conn.Close();

            }

            return successDelete;

        }
        #endregion

        //creates the search functionality
        #region SEARCH
        public DataTable SearchRecord(string search)
        {
            //connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //data table to hold the temporary data
            DataTable dt = new DataTable();

            try
            {
                //search query
                string sql = "SELECT id[ID], type[TYPE], name[NAME], email[EMAIL], tel[PHONE], address[ADDRESS], created_by[ADDED BY], created_date[DATE ADDED] FROM stakeholders WHERE id LIKE '%" + search+"%' OR type LIKE '%"+search+"%' OR name LIKE '%"+search+"%' OR email LIKE '%"+search+"%'";

                //sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fill the fdatatable with the contents of the data adapter
                adapter.Fill(dt);
                

            }catch(Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
            }
            finally
            {
                //closes the connection
                conn.Close();
            }

            return dt;
        }
        #endregion

        //method to search to search for customer or supplier when making purchase or sales transaction
        #region SEARCH FOR CUSTOMER OR SUPPLIER FOR PRCHASE OR SALES TRANSACTIONS
        public StakeholderModel SearchSupCus(string search)
        {
            //creates an instance(object) of the StakeholderModel, assign it to a variable and return it
            StakeholderModel stm = new StakeholderModel();

            //database connection instance
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary values
            DataTable dt = new DataTable();

            //try, catchand finally block to implement the search functionality
            try
            {
                //query to search for customer or supplier
                string sql = "SELECT  name, type, email, tel, address FROM stakeholders WHERE id LIKE '%"+search+"%' OR name LIKE '%"+search+"%' ";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the StakeholderModel
                if (dt.Rows.Count>0)
                {
                    
                    stm.name = dt.Rows[0]["name"].ToString();
                    stm.type = dt.Rows[0]["type"].ToString();
                    stm.email = dt.Rows[0]["email"].ToString();
                    stm.tel = dt.Rows[0]["tel"].ToString();
                    stm.address = dt.Rows[0]["address"].ToString();
                }



            }catch(Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());

            }
            finally
            {
                //colses the database connection
                conn.Close();
            }


            return stm;

        }
        #endregion

        //method to get the ID of the Customer or Supplier based on their names
        #region GETS THE ID OF STAKEHOLDER TO SAVE TRANSACTIONS
        public StakeholderModel getStakeId(string getStakeName)
        {
            //creates an object of the StakeholderModel
            StakeholderModel stakemdl = new StakeholderModel();

            //creates the database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the Data Table to hold the Temporary Data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the  functionality
            try
            {
                //sql query to get the id(getting the Name of the Customer or Supplier based on the Id)
                string sql = "SELECT id FROM stakeholders WHERE name='"+getStakeName+"' ";

                //creates the sql adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //opens the database connection
                conn.Open();

                //fills the Data Table with the contents of the Data Adapter
                adapter.Fill(dt);

                //if the data table returns a value, then the values will be passed to the StakeholderModel
                if (dt.Rows.Count>0)
                {
                    stakemdl.id = int.Parse(dt.Rows[0]["id"].ToString());

                }

            }catch(Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
            }
            finally
            {
                //closes the database connection
                conn.Close();
            }


            //returns the StakeholderModel variable
            return stakemdl;
        }
        #endregion

        //method to count the customers and display the count results on the dashboard
        #region COUNT NUMBER OF CUSTOMERS
        public string CustomersCount()
        {
            //creates an instance of the database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a variable of string data type and set its defaults to 0, inorder to count the customers
            string setCustomers = "0";

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query to count the number of customers
                string sql = "SELECT type FROM stakeholders WHERE type='Customer'";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //adapter to fetch the data from the database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //creates a data table to hold the temporal data fetched from the database
                DataTable dtbl = new DataTable();

                //opens the database connection
                conn.Open();

                //fills the datatable with the contents of the data adapter
                adapter.Fill(dtbl);

                //fetches the number of customers
                setCustomers = dtbl.Rows.Count.ToString();

            }
            catch (Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
            }
            finally
            {
                //closes the database connection
                conn.Close();

            }

            return setCustomers;
        }
        #endregion

        //method to display supplier or customer based on clicked menu link
        #region DISPLAY CUSTOMER OR SUPPLIER BASED ON SELECTED MENU
        public DataTable ShowCustomerSupplier(string keyText)
        {
            //connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //data table to hold the temporary data
            DataTable dt = new DataTable();

            try
            {
                //search query
                string sql = "SELECT id[ID], type[TYPE], name[NAME], email[EMAIL], tel[PHONE], address[ADDRESS], created_by[ADDED BY], created_date[DATE ADDED] FROM stakeholders WHERE type LIKE '%" + keyText + "%'";

                //sql command to execute query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fill the fdatatable with the contents of the data adapter
                adapter.Fill(dt);


            }
            catch (Exception ex)
            {
                //displays any exception error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
            }
            finally
            {
                //closes the connection
                conn.Close();
            }

            return dt;
        }
        #endregion

    }
}
