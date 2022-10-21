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
    class LoginController
    {
        // APPLICATION NAME: SmartBilling
        // AUTHOR:           Mathew Harb
        // SITE:             https://github.com/mathewharb
        // EMAIL:            harbmathew@yahoo.com
        // CONTACT:          +2207425159


        //static  string for the database configuration
        static string myConstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //HANDLING THE ERROR LOG FILE CREATION IN THE FOLDER CALLED "Logs"
        string locationPath = "";
        //the path to the Logs folder
        // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
        //given variable i.e "0" the length of "Application.StartupPath.Length-10"
        string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

        //creates a public boolean method to check our login
        public bool loginCheck(LoginModel lm)
        {

            bool loginSuccess = false;
            //creating the sql connection
            SqlConnection conn = new SqlConnection(myConstr);

            //creating the try, catch, finally block to run the code
            try
            {
                //creates the sql query for the login
                string sql = "SELECT * FROM Users WHERE UserName=@UserName AND Password=@Password AND UserType=@UserType";

                //creates the sql command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the parameters
                cmd.Parameters.AddWithValue("@UserName", lm.UserName);
                cmd.Parameters.AddWithValue("@Password", lm.Password);
                cmd.Parameters.AddWithValue("@UserType", lm.UserType);
                // cmd.Parameters.AddWithValue("@IsActive", lm.IsActive);

                //creates the data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //creates a data table to store the temporary data
                DataTable dt = new DataTable();

                //fill the datatable with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table returns a record

                if (dt.Rows.Count > 0)
                {
                    //if the rows return a value, the login is successfull
                    loginSuccess = true;
                }
                else
                {
                    loginSuccess = false;
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
                conn.Close();
            }


            return loginSuccess;
        }
    }
}
