using BillingSystem.MODEL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.CONTROLLER
{
    class TransactionDetailsController
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

        //method to insert the transaction details
        #region INSERT
        public bool InsertTransactionDetails(TransactionDetailModel tdm)
        {
            //database connection instance\
            SqlConnection conn = new SqlConnection(Myconstr);

            bool trDetailSuccess = false;

            //try, catch andfinally block to implement the insert functionality
            try
            {
                //sql query to insert transaction details
                string sql = "INSERT INTO transaction_details(product_id, quantity, unit, price, total, stakeholder_id, created_by, created_date) VALUES(@product_id, @quantity, @unit, @price, @total, @stakeholder_id, @created_by, @created_date)";

                //sqlcommand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters
                cmd.Parameters.AddWithValue("@product_id", tdm.product_id);
                cmd.Parameters.AddWithValue("@quantity", tdm.quantity);
                cmd.Parameters.AddWithValue("@unit", tdm.unit);
                cmd.Parameters.AddWithValue("@price", tdm.price);
                cmd.Parameters.AddWithValue("total", tdm.total);
                cmd.Parameters.AddWithValue("stakeholder_id", tdm.stakeholder_id);
                cmd.Parameters.AddWithValue("created_by", tdm.created_by);
                cmd.Parameters.AddWithValue("created_date", tdm.created_date);

                //opens the database connection
                conn.Open();

                //executes the query 
                int row = cmd.ExecuteNonQuery();

                //checks if the query is executec successfully or not
                if (row>0)
                {
                    trDetailSuccess = true;
                }
                else
                {
                    trDetailSuccess = false;
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
                //closes the database connection
                conn.Close();
            }

            return trDetailSuccess;


        }
        #endregion

    }
}
