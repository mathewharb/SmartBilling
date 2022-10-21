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
    class UnitsController
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

        //select functionality
        #region SELECT
        public DataTable Select()
        {
            //connection string
            SqlConnection conn = new SqlConnection(Myconstr);

            //datatable to hold the temporary data
            DataTable dt = new DataTable();

            //try, catch, finally block to implement the functionality
            try
            {
                //database query
                string sql = "SELECT * FROM units";

                //command to execute the sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the database adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fills the data table with the contents of the data adapter
                adapter.Fill(dt);



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
                //closes the cnnection
                conn.Close();
            }
            return dt;

        }
        #endregion

        //Insert functionality
        #region INSERT
        public bool Insert(UnitModel um)
        {
            //connection
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successInsert = false;

            //try, catch and finally block to implement the functionality
            try
            {
                //database query
                string sql = "INSERT INTO units (name, description, created_by, created_date) VALUES(@name, @description, @created_by, @created_date)";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters
                cmd.Parameters.AddWithValue("@name", um.name);
                cmd.Parameters.AddWithValue("@description", um.description);
                cmd.Parameters.AddWithValue("@created_by", um.created_by);
                cmd.Parameters.AddWithValue("@created_date", um.created_date);

                //opens the connection
                conn.Open();

                //execute non query 
                int row = cmd.ExecuteNonQuery();

                //checks if the data is successfully inserted, 
                if (row>0)
                {
                    successInsert = true;
                }
                else {
                    successInsert = false;
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

            return successInsert;
        }
        #endregion

        //Update functionality
        #region UPDATE
        public bool Update(UnitModel um)
        {
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successUpdate = false;

            try
            {
                //update query
                string sql = "UPDATE units SET name=@name, description=@description WHERE id=@id";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //bind parameters
                cmd.Parameters.AddWithValue("@name", um.name);
                cmd.Parameters.AddWithValue("@description", um.description);
                cmd.Parameters.AddWithValue("@id", um.id);

                //open the connection
                conn.Open();

                //execute non query
                int row = cmd.ExecuteNonQuery();

                if (row>0)
                {
                    successUpdate = true;
                }
                else
                {
                    successUpdate = false;
                }
            }
            catch(Exception ex)
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
                conn.Close();
            }

            return successUpdate;
        }

        #endregion

        #region DELETE
        public bool Delete(UnitModel um)
        {
            //connection
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successDelete = false;

            try
            {
                //delete query
                string sql = "DELETE FROM units WHERE id=@id";
                //executes the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id", um.id);
                //opens the connection
                conn.Open();

                int row = cmd.ExecuteNonQuery();

                if (row>0) {

                    successDelete = true;
                }
                else
                {
                    successDelete = false;
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
                conn.Close();
            }

            return successDelete;
        }

        #endregion

        //search functionality
        #region SEARCH
        public DataTable SearchUnit(string search)
        {
            //connection string
            SqlConnection conn = new SqlConnection(Myconstr);

            DataTable dt = new DataTable();

            try
            {
                //Search Query
                string sql = "SELECT id[ID], name[Unit Name], description[Description] FROM units WHERE id LIKE '%" + search+"%' OR name LIKE '%"+search+"%' OR description LIKE '%"+search+"%' ";

                //sqlcommand to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //slq data adapter 
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //open the connection
                conn.Open();

                //fill the data table with the contents of the adapter
                adapter.Fill(dt);


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
                //colses the connection
                conn.Close();
            }

            return dt;
        }
        #endregion

        //method to display units in the data grid view
        #region SELECT UNITS FOR DISPLAY IN DATA GRID
        public DataTable AllUnits()
        {
            //creates the database connection string
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the datatable to hold the temporary data
            DataTable dt = new DataTable();

            //try, catch and finally block to run the code
            try
            {
                //sql query to select data from the units table
                string sql = "SELECT id[ID], name[Unit Name], description[Description] FROM units";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //creates the database adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

                //fill the data table with the contents of the adapter
                adapter.Fill(dt);

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


            return dt;

        }
        #endregion

        #region SELECT UNIT ID BASED ON UNIT NAME
        public UnitModel SelectUnitID(string keyText)
        {
            //creates an instance(object) of the UnitModel, assign it to a variable and return it
            UnitModel um = new UnitModel();

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary values
            DataTable dt = new DataTable();

            //try, catchand finally block to implement the search functionality
            try
            {
                //query to search for Unit
                string sql = "SELECT id FROM units WHERE name LIKE '%" + keyText + "%' ";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the UnitModel
                if (dt.Rows.Count > 0)
                {
                    um.id = Convert.ToInt32(dt.Rows[0]["id"]);
                    //um.name= dt.Rows[0]["name"].ToString();
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
                //colses the database connection
                conn.Close();
            }

            return um;
        }
        #endregion


    }
}
