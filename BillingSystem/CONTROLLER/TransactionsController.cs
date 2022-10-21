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
    class TransactionsController
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

        //insert transactions method
        #region INSERT
        public bool CreateTransaction(TransactionModel tm, out int TransactionId)
        {
            //creates the sql connection instance
            SqlConnection conn = new SqlConnection(Myconstr);

            bool transactSuccess = false;

            //sets the transaction id to -1
            TransactionId = -1;

            //try, catch and finally bolock to implement the create transactions functionality
            try
            {
                //sql query to insert transactions
                string sql = "INSERT INTO transactions(stakeholder_id, stakeholder_name, type, transaction_date, total, discount, created_by, transaction_month, transaction_year, receipt_number, paid_amount, return_amount) VALUES(@stakeholder_id, @stakeholder_name, @type, @transaction_date, @total, @discount, @created_by, @transaction_month, @transaction_year, @receipt_number, @paid_amount, @return_amount) SELECT @@IDENTITY";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters to its corresponding values in the Model
                cmd.Parameters.AddWithValue("@stakeholder_id", tm.stakeholder_id);
                cmd.Parameters.AddWithValue("@stakeholder_name", tm.stakeholder_name);
                cmd.Parameters.AddWithValue("@type", tm.type);
                cmd.Parameters.AddWithValue("@transaction_date", tm.transaction_date);
                cmd.Parameters.AddWithValue("@total", tm.total);
                cmd.Parameters.AddWithValue("@discount", tm.discount);
                cmd.Parameters.AddWithValue("@created_by", tm.created_by);
                cmd.Parameters.AddWithValue("@transaction_month", tm.transaction_month);
                cmd.Parameters.AddWithValue("@transaction_year", tm.transaction_year);
                cmd.Parameters.AddWithValue("@receipt_number", tm.receipt_number);
                cmd.Parameters.AddWithValue("@paid_amount", tm.paid_amount);
                cmd.Parameters.AddWithValue("@return_amount", tm.return_amount);

                //opens the database connection
                conn.Open();

                //ExecuteNonQuery: returns the number of rows affected after executing the query
                //ExecuteScalar: returns the value of the first column of the first row from the query result

                //Thus, this uses ExecuteScalar to execute the query
                //the result is stored in an object
                object obj = cmd.ExecuteScalar();

                //if the query executes successfully, then the object variable obj will return a value
                //otherwise, the value will be null
                if (obj!=null)
                {
                    //changes the value of the transactionId, when the query is successfull
                    TransactionId = int.Parse(obj.ToString());

                    transactSuccess = true;

                }
                else
                {
                    transactSuccess = false;
                }

 

            }catch(Exception ex)
            {
                //displays any exceptional error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
            }
            finally
            {
                //cloases the connection
                conn.Close();
            }

            return transactSuccess;

        }
        #endregion

        //method to diaplay all the transactions in the transactions report
        #region SHOW ALL TRANSACTIONS IN REPORT
        public DataTable AllTransactions()
        {
            //database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //data table to hold the temporary data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //query to show all transactions
                string sql = "SELECT id[ID], stakeholder_name[CUSTOMER / SUPPLIER], type[TYPE], transaction_date[TRANSACTION DATE], total[TOTAL], discount[DISCOUNT %], created_by[ADDED BY] FROM transactions";

                //sql command and adapter to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents of the data adapter
                adapter.Fill(dt);

            }catch(Exception ex)
            {
                //displays exceptional message if any
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

        //method to show Transactions based on the Type of Transaction selected
        #region SHOW TRANSACTION FROM TRANSACTION TYPE SELECTION
       public DataTable TransactionFromType(string transactionType)
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //data table to hold temporary data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query
                string sql = "SELECT id[ID], stakeholder_name[CUSTOMER / SUPPLIER], type[TYPE], transaction_date[TRANSACTION DATE], total[TOTAL], discount[DISCOUNT %], created_by[ADDED BY] FROM transactions WHERE type='" + transactionType+"' ";

                //sql command and data adapter to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

            }catch(Exception ex)
            {
                //shows exceptional messages if any
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

        //method to select total sales and purchases, this will show on the dashboard
        #region TOTAL SALES AND PURCHASE
        public DataTable TransactionsAmount(string keyText)
        {

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //database query
                string sql = "SELECT total FROM transactions WHERE type='" + keyText + "'";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //fill the datatable with the contents of the data adapter
                adapter.Fill(dtbl);

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

            return dtbl;
        }
        #endregion

        //method to display transaction totals based on year selection for profit/loss report
        #region TRANSACTION TOTALS BASED ON YEAR FOR PROFIT/LOSS STATEMENT
        public DataTable YearlyProfitLoss(string yearText, string typeText)
        {

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //database query
                string sql = "SELECT total FROM transactions WHERE transaction_year='" + yearText + "' AND type='" + typeText + "'";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //fill the datatable with the contents of the data adapter
                adapter.Fill(dtbl);

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

            return dtbl;
        }
        #endregion

    }
}
