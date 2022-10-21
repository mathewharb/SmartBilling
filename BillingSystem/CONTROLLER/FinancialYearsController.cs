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
    class FinancialYearsController
    {
        // APPLICATION NAME: SmartBilling
        // AUTHOR:           Mathew Harb
        // SITE:             https://github.com/mathewharb
        // EMAIL:            harbmathew@yahoo.com
        // CONTACT:          +2207425159



        //creates the static connection string for the database connectivity
        static string Myconstr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        //HANDLING THE ERROR LOG FILE CREATION IN THE FOLDER CALLED "Logs"
        string locationPath = "";
        //the path to the Logs folder
        // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
        //given variable i.e "0" the length of "Application.StartupPath.Length-10"
        string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

        //method to see financial years
        #region SELECT
        public DataTable Select()
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //datatable to hold temporary data 
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query
                string sql = "SELECT * FROM financialyears";

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

        //method to insert financial years
        #region INSERT FINANCIAL YEARS
        public bool Insert(FinancialYearModel fym)
        {
            //creates a variable of boolean data type and set its default valu to false;
            bool InsertSuccess = false;

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the insert functionality
            try
            {
                //creates tthe query to insert the data
                string sql = "INSERT INTO financialyears(Year) VALUES(@Year)";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@Year",fym.Year);

                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and assign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks if the query executed successfully or not 
                if (QueryResult > 0)
                {
                    //sets the boolean value of InsertSuccess to true, if the query returns a value-meaning the query is successful
                    InsertSuccess = true;

                }
                else
                {
                    //sets the boolean value of InsertSuccess to false, if the query does not return a value-meaning the query is unsuccessful
                    InsertSuccess = false;
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

            return InsertSuccess;
        }
        #endregion

        //method to update the data
        #region UPDATE
        public bool Update(FinancialYearModel fym)
        {
            //creates a variable of boolean data type and set its defaults to false
            bool UpdateSuccess = false;

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the update functionality
            try
            {
                //sql query to update the data
                string sql = "UPDATE financialyears SET Year=@Year WHERE FinancialYearID=@FinancialYearID";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with the database values
                cmd.Parameters.AddWithValue("@Year", fym.Year);
                cmd.Parameters.AddWithValue("@FinancialYearID", fym.FinancialYearID);

                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and assign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks if the query executed successfully or not 
                if (QueryResult > 0)
                {
                    //sets the boolean value of UpdatetSuccess to true, if the query returns a value-meaning the query is successful
                    UpdateSuccess = true;

                }
                else
                {
                    //sets the boolean value of UpdatetSuccess to false, if the query does not return a value-meaning the query is unsuccessful
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


            return UpdateSuccess;
        }
        #endregion

        //method to delete user types from the database
        #region DELETE
        public bool Delete(FinancialYearModel fym)
        {
            //creates a variable of boolean data type and set its default value to false
            bool DeleteSuccess = false;

            //creates an instance of the databas connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //try,catch and finally block to implement the delete functionality
            try
            {
                //sql query to delete theselected data
                string sql = "DELETE FROM financialyears WHERE FinancialYearID=@FinancialYearID";

                //sqlcommand to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@FinancialYearID", fym.FinancialYearID);

                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and assign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks if the query executed successfully or not 
                if (QueryResult > 0)
                {
                    DeleteSuccess = true;

                }
                else
                {
                    DeleteSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //displays exceptional error messages if any
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

            return DeleteSuccess;
        }
        #endregion

        //method to search Year
        #region SEARCH
        public DataTable Search(string keywords)
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates Data table to store temporary data
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implent the search functionality
            try
            {
                //creates the sql query to search from the database
                string sql = "SELECT FinancialYearID [ID], Year [Year] FROM financialyears WHERE FinancialYearID LIKE '%" + keywords + "%' OR Year LIKE '%" + keywords + "%'";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the data adapter to fetch the records from the database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents of the data adapter
                adapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                //displays exceprional error messages if any
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

            //returns the data table containing the temporary data
            return dtbl;
        }
        #endregion

        //method to check if the year already exist in the database
        #region CHECK IF YEAR ALREADY EXISTS
        public DataTable YearExists(string ChekYear)
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //Data table to store temporary data 
            DataTable dtbl = new DataTable();

            //try, catch and finally to implement the functionality
            try
            {
                //sql query to check the Year
                string sql = "SELECT * FROM financialyears WHERE Year='" + ChekYear + "'";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter to fetch the contents from the database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the datatable with the contents of the data adapter
                adapter.Fill(dtbl);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());
            }
            finally
            {
                //closesthe database connection
                conn.Close();

            }


            return dtbl;

        }
        #endregion

        //method to diaplay all Years
        #region ALL YEARS
        public DataTable SelectAll()
        {
            //creates an object of the database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a dataTable to hold temporary data from the database
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //query to select and display the usertypes from the database
                string sql = "SELECT FinancialYearID [ID], Year [Year] FROM financialyears";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the sql adapter to fetch the data from the database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents from the data adapter
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
                conn.Close();
            }

            //returns the datatable containing the temporary data
            return dtbl;


        }
        #endregion
    }
}
