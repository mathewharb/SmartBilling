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
    class DefaultUserController
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

        //method to insert the default admin settings
        #region INSERT DEFAULT ADMIN USER
        public bool InsertDefaultUser(DefaultUserModel dum)
        {
            //creartes a boolean variable and set its deafult value to false
            bool InsertSuccess = false;

            //database connection object
            SqlConnection connect = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the insert functionality
            try
            {
                //sql query to insert the details
                string sql = "INSERT INTO users(UserName, Password, UserType, Role, IsActive) VALUES(@UserName, @Password, @UserType, @Role, @IsActive)";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, connect);

                //pass the parameters to the model
                cmd.Parameters.AddWithValue("@UserName", dum.UserName);
                cmd.Parameters.AddWithValue("@Password", dum.Password);
                cmd.Parameters.AddWithValue("@UserType", dum.UserType);
                cmd.Parameters.AddWithValue("@Role", dum.Role);
                cmd.Parameters.AddWithValue("@IsActive", dum.IsActive);


                //opens the database connection 
                connect.Open();

                //creates an integer variable and assign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //ckeck if the query returns a value or not
                if (QueryResult > 0)
                {
                    InsertSuccess = true;
                }
                else
                {
                    InsertSuccess = false;
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
                connect.Close();

            }


            return InsertSuccess;
        }
        #endregion

        //method to check the existence of admin user in the users table
        #region SELECT ADMIN
        public DataTable SelectAdmin(string KeyText)
        {
            //creates the database connection object
            SqlConnection connect = new SqlConnection(Myconstr);

            //creates a data table to store the temporary data
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionalities
            try
            {
                //sql query
                string sql = "SELECT * FROM users WHERE UserType='" + KeyText + "'";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, connect);

                //sql dataadapter to fetch the data from the table
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                connect.Open();

                //fills the data table with the contents of the data adapter
                adapter.Fill(dtbl);

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
                connect.Close();
            }

            //returns the data table 
            return dtbl;
        }
        #endregion
    }
}
