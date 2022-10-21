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

    class AppSettingsController
    {

        // APPLICATION NAME: SmartBilling
        // AUTHOR:           Mathew Harb
        // SITE:             https://github.com/mathewharb
        // EMAIL:            harbmathew@yahoo.com
        // CONTACT:          +2207425159


        //creating the database configuration
        static string Myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //HANDLING THE ERROR LOG FILE CREATION IN THE FOLDER CALLED "Logs"
        string locationPath = "";
        //the path to the Logs folder
        // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
        //given variable i.e "0" the length of "Application.StartupPath.Length-10"
        string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);


        //method to see the settings
        #region SELECT
        public DataTable Select()
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //datatable to hold temporary data from the users table
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query
                string sql = "SELECT * FROM appsettings";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter to fetch the data from the table
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents of the data adapter
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


        //method to update App Settings
        #region UPDATE APPLICATION SETTINGS
        public bool UpdateAppSettings(AppSettingModel asm)
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a boolean variable and set its defaults to false
            bool UpdateSuccess = false;

            //try, catch and finally block to implement the update functionality
            try
            {
                //sql query to update the settings
                string sql = "UPDATE appsettings SET ApplicationName=@ApplicationName, BackgroundImage=@BackgroundImage,Logo=@Logo, FooterTitle=@FooterTitle, FooterText=@FooterText WHERE AppSettingsID=@AppSettingsID";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@ApplicationName", asm.ApplicationName);
                cmd.Parameters.AddWithValue("@BackgroundImage", asm.BackgroundImage);
                cmd.Parameters.AddWithValue("@Logo", asm.Logo);
                cmd.Parameters.AddWithValue("@FooterTitle", asm.FooterTitle);
                cmd.Parameters.AddWithValue("@FooterText", asm.FooterText);
                cmd.Parameters.AddWithValue("@AppSettingsID", asm.AppSettingsID);

                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and aggign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks whether the query returns a value or not
                //if it returns a value then the query is successful, otherwise it is unsuccessful
                if (QueryResult > 0)
                {
                    //if the query is successfull, then set the value of UpdatetSuccess to true
                    UpdateSuccess = true;
                }
                else
                {
                    //if the query is unsuccessful, then set the value of UpdateSuccess to false
                    UpdateSuccess = false;
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

            //returns the boolean variable
            return UpdateSuccess;
        }
        #endregion

        //method to update Printer Settings
        #region UPDATE PRINTER SETTINGS
        public bool UpdatePrinterSettings(AppSettingModel asm)
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a boolean variable and set its defaults to false
            bool UpdateSuccess = false;

            //try, catch and finally block to implement the update functionality
            try
            {
                //sql query to update the printer settings
                string sql = "UPDATE appsettings SET Printer=@Printer, UnitWidth=@UnitWidth, UnitHeight=@UnitHeight, FontSize=@FontSize WHERE AppSettingsID=@AppSettingsID";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@Printer", asm.Printer);
                cmd.Parameters.AddWithValue("@UnitWidth", asm.UnitWidth);
                cmd.Parameters.AddWithValue("@UnitHeight", asm.UnitHeight);
                cmd.Parameters.AddWithValue("@FontSize", asm.FontSize);
                cmd.Parameters.AddWithValue("@AppSettingsID", asm.AppSettingsID);

                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and aggign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks whether the query returns a value or not
                //if it returns a value then the query is successful, otherwise it is unsuccessful
                if (QueryResult > 0)
                {
                    //if the query is successfull, then set the value of UpdatetSuccess to true
                    UpdateSuccess = true;
                }
                else
                {
                    //if the query is unsuccessful, then set the value of UpdateSuccess to false
                    UpdateSuccess = false;
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

            //returns the boolean variable
            return UpdateSuccess;
        }
        #endregion
    }
}
