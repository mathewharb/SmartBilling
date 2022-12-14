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
    class ProfilesController
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

        //method to update EMPLOYEE Profile
        #region UPDATE EMPLOYEE PROFILE
        public bool UpdateEmployeeProfile(ProfileModel pm)
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a boolean variable and set its defaults to false
            bool UpdateSuccess = false;

            //try, catch and finally block to implement the update functionality
            try
            {
                //sql query to update the record
                string sql = "UPDATE employees SET FullName=@FullName, Designation=@Designation, Contact=@Contact, Email=@Email, Image=@Image, Address=@Address, TIN=@TIN, SSCN=@SSCN, Description=@Description, Updated_By=@Updated_By, Updated_Date=@Updated_Date WHERE EmployeeID=@EmployeeID";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@FullName", pm.FullName);
                cmd.Parameters.AddWithValue("@Designation", pm.Designation);
                cmd.Parameters.AddWithValue("@Contact", pm.Contact);
                cmd.Parameters.AddWithValue("@Email", pm.Email);
                cmd.Parameters.AddWithValue("@Image", pm.Image);
                cmd.Parameters.AddWithValue("@Address", pm.Address);
                cmd.Parameters.AddWithValue("@TIN", pm.TIN);
                cmd.Parameters.AddWithValue("@SSCN", pm.SSCN);
                cmd.Parameters.AddWithValue("@Description", pm.Description);
                cmd.Parameters.AddWithValue("@Updated_By", pm.Updated_By);
                cmd.Parameters.AddWithValue("@Updated_Date", pm.Updated_Date);
                cmd.Parameters.AddWithValue("@EmployeeID", pm.EmployeeID);

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

        //method to update user employee profile
        #region UPDATE USER EMPLOYEE PROFILE 
        public bool UpdateUserEmployeeProfile(UserModel um)
        {
            //creates a variable of boolean data type and set its default valu to false;
            bool UpdateSuccess = false;

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the insert functionality
            try
            {
                //creates tthe query to update data
                string sql = "UPDATE users SET Employee_ID=@Employee_ID, FullName=@FullName, Contact=@Contact, Email=@Email WHERE Employee_ID=@Employee_ID";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@Employee_ID", um.Employee_ID);
                cmd.Parameters.AddWithValue("@FullName", um.FullName);
                cmd.Parameters.AddWithValue("@Contact", um.Contact);
                cmd.Parameters.AddWithValue("@Email", um.Email);
                cmd.Parameters.AddWithValue("@UserID", um.UserID);


                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and assign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks if the query executed successfully or not 
                if (QueryResult > 0)
                {
                    //sets the boolean value of UpdateSuccess to true, if the query returns a value-meaning the query is successful
                    UpdateSuccess = true;

                }
                else
                {
                    //sets the boolean value of UpdateSuccess to false, if the query does not return a value-meaning the query is unsuccessful
                    UpdateSuccess = false;
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
                //closes the database connection
                conn.Close();
            }


            return UpdateSuccess;
        }
        #endregion

        //method to update user profile
        #region UPDATE USER PROFILE 
        public bool UpdateUserOwnProfile(UserModel um)
        {
            //creates a variable of boolean data type and set its default valu to false;
            bool UpdateSuccess = false;

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the insert functionality
            try
            {
                //creates tthe query to update data
                string sql = "UPDATE users SET FullName=@FullName, Contact=@Contact, Email=@Email WHERE UserID=@UserID";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@FullName", um.FullName);
                cmd.Parameters.AddWithValue("@Contact", um.Contact);
                cmd.Parameters.AddWithValue("@Email", um.Email);
                cmd.Parameters.AddWithValue("@UserID", um.UserID);


                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and assign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks if the query executed successfully or not 
                if (QueryResult > 0)
                {
                    //sets the boolean value of UpdateSuccess to true, if the query returns a value-meaning the query is successful
                    UpdateSuccess = true;

                }
                else
                {
                    //sets the boolean value of UpdateSuccess to false, if the query does not return a value-meaning the query is unsuccessful
                    UpdateSuccess = false;
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
                //closes the database connection
                conn.Close();
            }


            return UpdateSuccess;
        }
        #endregion
    }
}
