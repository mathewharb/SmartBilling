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
    class ChangePassController
    {
        // APPLICATION NAME: SmartBilling
        // AUTHOR:           Mathew Harb
        // SITE:             https://github.com/mathewharb
        // EMAIL:            harbmathew@yahoo.com
        // CONTACT:          +2207425159



        //database configuaration
        static string Myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //HANDLING THE ERROR LOG FILE CREATION IN THE FOLDER CALLED "Logs"
        string locationPath = "";
        //the path to the Logs folder
        // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
        //given variable i.e "0" the length of "Application.StartupPath.Length-10"
        string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

        //method to update own password
        #region UPDATE OWN PASSWORD
        public bool UpdatePassword(ChangePassModel um)
        {
            //database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            bool ChangeSuccess = false;

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query
                string sql = "UPDATE users SET Password=@Password WHERE UserID=@UserID";

                //sqlcommand to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //adds the parameters to the model
                cmd.Parameters.AddWithValue("@Password", um.Password);
                cmd.Parameters.AddWithValue("@UserID", um.UserID);

                //opens the database connection
                conn.Open();

                //assigns the result of the query to an integer variable
                int QueryResult = cmd.ExecuteNonQuery();

                //checks if the query returns a value or not
                if (QueryResult > 0)
                {
                    ChangeSuccess = true;
                }
                else
                {
                    ChangeSuccess = false;
                }
            }
            catch (Exception ex)
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

            return ChangeSuccess;
        }
        #endregion


    }
}
