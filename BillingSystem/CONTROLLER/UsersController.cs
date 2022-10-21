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
    class UsersController
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

        //method to see all users
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
                string sql = "SELECT UserID[ID], FullName[Full Name], Contact[Contact No.], Email[Email], UserName[Username], Password[Password], UserType[User Type], Role[Role], IsActive[Active] FROM users";

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

        //method to insert user  into the database
        #region INSERT USER 
        public bool Insert(UserModel um)
        {
            //creates a variable of boolean data type and set its default valu to false;
            bool InsertSuccess = false;

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the insert functionality
            try
            {
                //creates tthe query to insert the data
                string sql = "INSERT INTO users(UserType, Employee_ID, FullName, Contact, Email, UserName, Password, Role, IsActive) VALUES(@UserType, @Employee_ID, @FullName, @Contact, @Email, @UserName, @Password, @Role, @IsActive)";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@UserType", um.UserType);
                cmd.Parameters.AddWithValue("@Employee_ID", um.Employee_ID);
                cmd.Parameters.AddWithValue("@FullName", um.FullName);
                cmd.Parameters.AddWithValue("@Contact", um.Contact);
                cmd.Parameters.AddWithValue("@Email", um.Email);
                cmd.Parameters.AddWithValue("@UserName", um.UserName);
                cmd.Parameters.AddWithValue("@Password", um.Password);
                cmd.Parameters.AddWithValue("@Role", um.Role);
                cmd.Parameters.AddWithValue("@IsActive", um.IsActive);

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

        //method to update user 
        #region UPDATE USER 
        public bool Update(UserModel um)
        {
            //creates a variable of boolean data type and set its default valu to false;
            bool UpdateSuccess = false;

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //try, catch and finally block to implement the insert functionality
            try
            {
                //creates tthe query to update data
                string sql = "UPDATE users SET UserType=@UserType, UserName=@UserName, Password=@Password, Role=@Role, IsActive=@IsActive WHERE UserID=@UserID";

                //creates the sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@UserType", um.UserType);
                // cmd.Parameters.AddWithValue("@Employee_ID", um.Employee_ID);
                //cmd.Parameters.AddWithValue("@FullName", um.FullName);
                // cmd.Parameters.AddWithValue("@Contact", um.Contact);
                //  cmd.Parameters.AddWithValue("@Email", um.Email);
                cmd.Parameters.AddWithValue("@UserName", um.UserName);
                cmd.Parameters.AddWithValue("@Password", um.Password);
                cmd.Parameters.AddWithValue("@Role", um.Role);
                cmd.Parameters.AddWithValue("@IsActive", um.IsActive);
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

        //method to search users from search bar
        #region SEARCH USER
        public DataTable SearchAllUsers(string keyText)
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //datatable to hold temporary data from the users table
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query
                string sql = "SELECT UserID[ID], FullName[Full Name], Contact[Contact No.], Email[Email], UserName[Username], Password[Password], UserType[User Type], Role[Role], IsActive[Active] FROM users WHERE UserID LIKE '%" + keyText + "%' OR FullName LIKE '%" + keyText + "%' OR Email LIKE '%" + keyText + "%' OR UserType LIKE '%" + keyText + "%' OR UserName LIKE '%" + keyText + "%' OR IsActive LIKE '%" + keyText + "%'";

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

        //method to check if the username already exist
        #region USERNAME ALREADY EXIST
        public DataTable UserNameExists(string textKey)
        {
            //creates database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a data table to hold the temporary data 
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query 
                string sql = "SELECT * FROM users WHERE UserName='" + textKey + "'";

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

        //method to check if the email already exist
        #region EMAIL ALREADY EXIST
        public DataTable UserExists(string textKey)
        {
            //creates database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a data table to hold the temporary data 
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query 
                string sql = "SELECT UserName, Password FROM users WHERE FullName='" + textKey + "'";

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

        //method to count the users and display the count results on the dashboard
        #region COUNT NUMBER OF USERS
        public string UserCount()
        {
            //creates an instance of the database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a variable of string data type and set its defaults to 0, inorder to count the users
            string setUsers = "0";

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query to count the number of users
                string sql = "SELECT * FROM Users";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //adapter to fetch the data from the database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //creates a data table to hold the temporal data fetched from the database
                DataTable dtbl = new DataTable();

                //opens the database connection
                conn.Open();

                //fills the datatable with the contents of the data adapter
                adapter.Fill(dtbl);

                //fetches the number of users
                setUsers = dtbl.Rows.Count.ToString();

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

            return setUsers;
        }
        #endregion

        //method to check wheter user is Active or Not
        #region CHECK ACTIVE OR INACTIVE USER
        public DataTable CheckActive(string UName, string Upass)
        {

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //database query
                string sql = "SELECT IsActive FROM users WHERE UserName='" + UName + "' AND Password='" + Upass + "' ";

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

        #region SEARCH FOR USER TO CHANGE OWN PASSWORD
        public UserModel SearchUser(string search)
        {
            //creates an instance(object) of the UserModel, assign it to a variable and return it
            UserModel um = new UserModel();

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary values
            DataTable dt = new DataTable();

            //try, catchand finally block to implement the search functionality
            try
            {
                //query to search for Employee
                string sql = "SELECT UserID, UserName FROM users WHERE UserName LIKE '%" + search + "%' ";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the UserModel
                if (dt.Rows.Count > 0)
                {
                    um.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    um.UserName = dt.Rows[0]["UserName"].ToString();
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

        //method to get the details of the user to display and update own profile
        #region SEARCH FOR USER TO CHANGE, DISPLAY AND UPDATE OWN PROFILE
        public UserModel SearchProfile(string search)
        {
            //creates an instance(object) of the UserModel, assign it to a variable and return it
            UserModel um = new UserModel();

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary values
            DataTable dt = new DataTable();

            //try, catchand finally block to implement the search functionality
            try
            {
                //query to search for user
                string sql = "SELECT UserID, UserName, Employee_ID FROM users WHERE UserName LIKE '%" + search + "%' ";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the UserModel
                if (dt.Rows.Count > 0)
                {
                    um.UserID = Convert.ToInt32(dt.Rows[0]["UserID"]);
                    um.Employee_ID = Convert.ToInt32(dt.Rows[0]["Employee_ID"]);
                    um.UserName = dt.Rows[0]["UserName"].ToString();
                }

            }
            catch (Exception)
            {
                //displays any exceptional error messages
                MessageBox.Show("Only Employees Can View And Update Their Profiles", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //gets the path to the folder location
                // locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                //System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());

            }
            finally
            {
                //colses the database connection
                conn.Close();
            }

            return um;
        }
        #endregion

        //method to check wheter user is Admin or Not to show general settings
        #region CHECK IF USER IS ADMIN, MANAGER OR CASHIER
        public DataTable CheckAdmin(string Username)
        {

            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //database query
                string sql = "SELECT UserType, Role FROM users WHERE UserName='" + Username + "'";

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
