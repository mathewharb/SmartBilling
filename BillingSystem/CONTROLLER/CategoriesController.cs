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
    class CategoriesController
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
        
        //creating the select method
        #region SELECT categories
        public DataTable Select()
        {
            //creates the database connection string
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the datatable to hold the temporary data
            DataTable dt=new DataTable();

            //try, catch and finally block to run the code
            try
            {
                //sql query to select data from the categories table
                string sql = "SELECT * FROM categories";
                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);
                //creates the database adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
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
                //closes the database connection
                conn.Close();
            }


            return dt;

        }
        #endregion

        //creating the insert method
        #region INSERT 
        public bool Insert(CategoryModel cm)
        {
            //sql connection
            SqlConnection conn = new SqlConnection(Myconstr);
            bool insertSucce = false;

            try
            {
                //database query
                string sql = "INSERT INTO categories(name,description,created_by,created_date) VALUES(@name,@description,@created_by,@created_date)";
                //execute the query using the sqlcommand
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters
                cmd.Parameters.AddWithValue("@name", cm.name);
                cmd.Parameters.AddWithValue("description", cm.description);
                cmd.Parameters.AddWithValue("@created_by", cm.created_by);
                cmd.Parameters.AddWithValue("@created_date", cm.created_date);

                conn.Open();

                //create an integer variable to hold the execute non query
                int row = cmd.ExecuteNonQuery();

                //checks wheter the record has been inserted;
                if (row>0)
                {
                    insertSucce = true;
                }
                else
                {
                    insertSucce = false;
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
                //closing the connection
                conn.Close();
            }

            return insertSucce;
        }
        #endregion

        //creating the update method
        #region UPDATE
        public bool Update(CategoryModel cm)
        {
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successUpdate = false;

            try
            {
                //database query
                string sql = "UPDATE categories SET name=@name, description=@description WHERE id=@id";

                //execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //bind the parameters
                cmd.Parameters.AddWithValue("@name", cm.name);
                cmd.Parameters.AddWithValue("@description", cm.description);
                cmd.Parameters.AddWithValue("@id", cm.id);

                conn.Open();

                //execute non query
                int row = cmd.ExecuteNonQuery();

                if (row>0)
                {
                    successUpdate = true;
                }
                else {
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
                 //closes the sql connection
                conn.Close();
            }

            return successUpdate;
                
        }
        #endregion

        //creating the delete method
        #region DELETE
        public bool Delete(CategoryModel cm)
        {
            SqlConnection conn = new SqlConnection(Myconstr);

            bool successDelete = false;

            try
            {
                //database query
                string sql = "DELETE FROM categories WHERE id=@id";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //bind the parameters
                cmd.Parameters.AddWithValue("id", cm.id);

                //opens the connection
                conn.Open();

                //create the integer variable to hold the execute non query 
                int row = cmd.ExecuteNonQuery();

                if (row>0)
                {
                    successDelete = true;
                }
                else
                {
                    successDelete = false;
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
                //closing the connection
                conn.Close();
            }

            return successDelete;

        }
        #endregion

        //creating the search finctionality
        #region SEARCH
        public DataTable SearchCategory(string search)
        {
            //connection string
            SqlConnection conn = new SqlConnection(Myconstr);

            //datatable to hold the temporary data
            DataTable dt = new DataTable();

            //try, catch and finally blocka to run the code
            try
            {
                //database search Query
                string sql = "SELECT id[ID], name[Category Name], description[Description] FROM Categories WHERE id LIKE '%"+search+"%' OR name LIKE '%"+search+"%' ";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
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
                //closes the connection
                conn.Close();
            }

            return dt;

        }

        #endregion

        //method to display categories in the data grid view
        #region SELECT categories FOR DISPLAY IN DATA GRID
        public DataTable AllCategories()
        {
            //creates the database connection string
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the datatable to hold the temporary data
            DataTable dt = new DataTable();

            //try, catch and finally block to run the code
            try
            {
                //sql query to select data from the categories table
                string sql = "SELECT id[ID], name[Category Name], description[Description] FROM categories";
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

        #region SELECT CATEGORY ID BASED ON CATEGORY NAME
        public CategoryModel SelectCategoryID(string keyText)
        {
            //creates an instance(object) of the CategoryModel, assign it to a variable and return it
            CategoryModel cm = new CategoryModel();

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary values
            DataTable dt = new DataTable();

            //try, catchand finally block to implement the search functionality
            try
            {
                //query to search for Category
                string sql = "SELECT id FROM categories WHERE name LIKE '%" + keyText + "%' ";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the CategoryModel
                if (dt.Rows.Count > 0)
                {
                    cm.id = Convert.ToInt32(dt.Rows[0]["id"]);
                    //cm.name= dt.Rows[0]["name"].ToString();
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

            return cm;
        }
        #endregion

        //method to check if the category already exist
        #region CATEGORY ALREADY EXIST
        public DataTable CategoryNameExists(string textKey)
        {
            //creates database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a data table to hold the temporary data 
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query 
                string sql = "SELECT * FROM categories WHERE name='" + textKey + "'";

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

            //returns the data table with the temporary data
            return dtbl;
        }
        #endregion
    }


}
