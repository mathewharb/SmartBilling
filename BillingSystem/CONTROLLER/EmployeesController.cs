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
    class EmployeesController
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

        //method to display the Employees from the Employees Table
        #region ALL EMPLOYEES
        public DataTable Select()
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a dataTable to hold temporary data from the database
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query to select records from the database table
                string sql = "SELECT EmployeeID[ID], FullName[Full Name], Designation[Designation], Contact[Contact No.], Email[EMail], Image[Profile Image], Address[Address], TIN[Tax No], SSCN[Social Security No.], Description[Description], MonthlySalary[Salary], Created_By[Created By], Created_Date[Created Date], Updated_By[Updated By], Updated_Date[Updated Date] FROM employees";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //data adapter to fetch the records from the database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

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
                conn.Close();

            }

            //returns the datatable containing the temporary data
            return dtbl;

        }
        #endregion

        //method to insert records into the database
        #region INSERT EMPLOYEE
        public bool Insert(EmployeeModel em)
        {
            //creates the database connection object 
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a variable of boolean data type and set its default value to false
            bool InsertSuccess = false;

            //try, catch and finally block to implement the insert functionality
            try
            {
                //sql query to insert the record into the database table
                string sql = "INSERT INTO employees(FullName, Designation, Contact, Email, Image, Address, TIN, SSCN, Description, MonthlySalary, Created_By, Created_Date) VALUES(@FullName, @Designation, @Contact, @Email, @Image, @Address, @TIN, @SSCN, @Description, @MonthlySalary, @Created_By, @Created_Date)";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@FullName", em.FullName);
                cmd.Parameters.AddWithValue("@Designation", em.Designation);
                cmd.Parameters.AddWithValue("@Contact", em.Contact);
                cmd.Parameters.AddWithValue("@Email", em.Email);
                cmd.Parameters.AddWithValue("@Image", em.Image);
                cmd.Parameters.AddWithValue("@Address", em.Address);
                cmd.Parameters.AddWithValue("@TIN", em.TIN);
                cmd.Parameters.AddWithValue("@SSCN", em.SSCN);
                cmd.Parameters.AddWithValue("@Description", em.Description);
                cmd.Parameters.AddWithValue("@MonthlySalary", em.MonthlySalary);
                cmd.Parameters.AddWithValue("@Created_By", em.Created_By);
                cmd.Parameters.AddWithValue("@Created_Date", em.Created_Date);

                //opens the database connection
                conn.Open();

                //creates a variable of integer data type and aggign the result of the executed query to it
                int QueryResult = cmd.ExecuteNonQuery();

                //checks whether the query returns a value or not
                //if it returns a value then the query is successful, otherwise it is unsuccessful
                if (QueryResult > 0)
                {
                    //if the query is successfull, then set the value of InsertSuccess to true
                    InsertSuccess = true;
                }
                else
                {
                    //if the query is unsuccessful, then set the value of InsertSuccess to false
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
                conn.Close();
            }

            return InsertSuccess;
        }
        #endregion

        //method to update the records
        #region UPDATE EMPLOYEE
        public bool Update(EmployeeModel em)
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a boolean variable and set its defaults to false
            bool UpdateSuccess = false;

            //try, catch and finally block to implement the update functionality
            try
            {
                //sql query to update the record
                string sql = "UPDATE employees SET FullName=@FullName, Designation=@Designation, Contact=@Contact, Email=@Email, Image=@Image, Address=@Address, TIN=@TIN, SSCN=@SSCN, Description=@Description, MonthlySalary=@MonthlySalary, Updated_By=@Updated_By, Updated_Date=@Updated_Date WHERE EmployeeID=@EmployeeID";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters with db values
                cmd.Parameters.AddWithValue("@FullName", em.FullName);
                cmd.Parameters.AddWithValue("@Designation", em.Designation);
                cmd.Parameters.AddWithValue("@Contact", em.Contact);
                cmd.Parameters.AddWithValue("@Email", em.Email);
                cmd.Parameters.AddWithValue("@Image", em.Image);
                cmd.Parameters.AddWithValue("@Address", em.Address);
                cmd.Parameters.AddWithValue("@TIN", em.TIN);
                cmd.Parameters.AddWithValue("@SSCN", em.SSCN);
                cmd.Parameters.AddWithValue("@Description", em.Description);
                cmd.Parameters.AddWithValue("@MonthlySalary", em.MonthlySalary);
                cmd.Parameters.AddWithValue("@Updated_By", em.Updated_By);
                cmd.Parameters.AddWithValue("@Updated_Date", em.Updated_Date);
                cmd.Parameters.AddWithValue("@EmployeeID", em.EmployeeID);

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

        //method to delete employee from the database
        #region DELETE EMPLOYEE
        public bool Delete(EmployeeModel em)
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a boolean variable and set its defaults to false
            bool DeleteSuccess = false;

            //try, catch and finally block to implement the delete functionality
            try
            {
                //query to delete record from the database
                string sql = "DELETE FROM employees WHERE EmployeeID=@EmployeeID";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //binds the parameters to the db values
                cmd.Parameters.AddWithValue("@EmployeeID", em.EmployeeID);

                //opens the database connection 
                conn.Open();

                //creates an integer variable and assign the result of the Executed query to it
                int Queryresult = cmd.ExecuteNonQuery();

                //checks whether the query is executed successfully or not
                if (Queryresult > 0)
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

            return DeleteSuccess;
        }
        #endregion

        //method to check if the Employee already exist in the database
        #region CHECK IF USER TYPE ALREADY EXISTS
        public DataTable EmployeeExists(string CheckEmployee)
        {
            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //Data table to store temporary data 
            DataTable dtbl = new DataTable();

            //try, catch and finally to implement the functionality
            try
            {
                //sql query to check the Employee
                string sql = "SELECT * FROM employees WHERE FullName='" + CheckEmployee + "' OR Email='" + CheckEmployee + "' OR TIN='" + CheckEmployee + "' OR SSCN='" + CheckEmployee + "'";

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

        //method to search Employees from the Employees Table
        #region SEARCH EMPLOYEES
        public DataTable Search(string searchKey)
        {
            //creates the database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a dataTable to hold temporary data from the database
            DataTable dtbl = new DataTable();

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query to select records from the database table
                string sql = "SELECT EmployeeID[ID], FullName[Full Name], Designation[Designation], Contact[Contact No.], Email[EMail], Image[Profile Image], Address[Address], TIN[Tax No], SSCN[Social Security No.], Description[Description], MonthlySalary[Salary], Created_By[Created By], Created_Date[Created Date], Updated_By[Updated By], Updated_Date[Updated Date] FROM employees WHERE EmployeeID LIKE '%" + searchKey + "%' OR FullName LIKE '%" + searchKey + "%' OR Email LIKE '%" + searchKey + "%' OR TIN LIKE '%" + searchKey + "%' OR SSCN LIKE '%" + searchKey + "%'  ";

                //sql command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //data adapter to fetch the records from the database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the database connection
                conn.Open();

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
                conn.Close();

            }

            //returns the datatable containing the temporary data
            return dtbl;

        }
        #endregion

        //method to search forEmployee when adding user login details 
        #region SEARCH FOR EMPLOYEE FOR LOGIN CREDENTIALS
        public EmployeeModel SearchEmployee(string search)
        {
            //creates an instance(object) of the EmployeeModel, assign it to a variable and return it
            EmployeeModel em = new EmployeeModel();

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary values
            DataTable dt = new DataTable();

            //try, catchand finally block to implement the search functionality
            try
            {
                //query to search for Employee
                string sql = "SELECT EmployeeID, FullName, Email, Contact FROM employees WHERE EmployeeID LIKE '%" + search + "%' OR FullName LIKE '%" + search + "%' ";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the EmployeeModel
                if (dt.Rows.Count > 0)
                {
                    em.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                    em.FullName = dt.Rows[0]["FullName"].ToString();
                    em.Email = dt.Rows[0]["Email"].ToString();
                    em.Contact = dt.Rows[0]["Contact"].ToString();
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

            return em;
        }
        #endregion

        //method to get the ID of the Employee based on their names
        #region GETS THE ID OF EMPLOYEE TO SAVE USER CREATION
        public EmployeeModel getEmployeeId(string getEmployeeName)
        {
            //creates an object of the EmployeeModel
            EmployeeModel emdl = new EmployeeModel();

            //creates the database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the Data Table to hold the Temporary Data
            DataTable dt = new DataTable();

            //try, catch and finally block to implement the  functionality
            try
            {
                //sql query to get the id(getting the Name of the Employee based on the Id)
                string sql = "SELECT EmployeeID FROM employees WHERE FullName='" + getEmployeeName + "' ";

                //creates the sql adapter to execute the query
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //opens the database connection
                conn.Open();

                //fills the Data Table with the contents of the Data Adapter
                adapter.Fill(dt);

                //if the data table returns a value, then the values will be passed to the EmployeeModel
                if (dt.Rows.Count > 0)
                {
                    emdl.EmployeeID = int.Parse(dt.Rows[0]["EmployeeID"].ToString());

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
            //returns the EmployeeModel variable
            return emdl;
        }
        #endregion

        //method to count the employees and display the count results on the dashboard
        #region COUNT NUMBER OF EMPLOYEES
        public string EmployeeCount()
        {
            //creates an instance of the database connection
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates a variable of string data type and set its defaults to 0, inorder to count the employees
            string setEmployees = "0";

            //try, catch and finally block to implement the functionality
            try
            {
                //sql query to count the number of employees
                string sql = "SELECT * FROM employees";

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

                //fetches the number of employees 
                setEmployees = dtbl.Rows.Count.ToString();

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

            return setEmployees;
        }
        #endregion

        //method to get Employee details based on id when displaying and updating own user profile
        #region SEARCH FOR EMPLOYEE FOR LOGIN CREDENTIALS
        public EmployeeModel EmployeeProfileDetails(string search)
        {
            //creates an instance(object) of the EmployeeModel, assign it to a variable and return it
            EmployeeModel em = new EmployeeModel();

            //database connection object
            SqlConnection conn = new SqlConnection(Myconstr);

            //creates the data table to store the temporary values
            DataTable dt = new DataTable();

            //try, catchand finally block to implement the search functionality
            try
            {
                //query to search for Employee
                string sql = "SELECT EmployeeID, FullName, Email, Contact, Designation, Address, TIN, SSCN, Image, Description, MonthlySalary FROM employees WHERE EmployeeID LIKE '%" + search + "%'";

                //sql command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //sql data adapter
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //opens the connection
                conn.Open();

                //fill the data table with the contents of the data adapter
                adapter.Fill(dt);

                //checks if the data table rows return any value, then save it to the EmployeeModel
                if (dt.Rows.Count > 0)
                {
                    em.EmployeeID = Convert.ToInt32(dt.Rows[0]["EmployeeID"]);
                    em.FullName = dt.Rows[0]["FullName"].ToString();
                    em.Email = dt.Rows[0]["Email"].ToString();
                    em.Contact = dt.Rows[0]["Contact"].ToString();
                    em.Designation = dt.Rows[0]["Designation"].ToString();
                    em.Address = dt.Rows[0]["Address"].ToString();
                    em.TIN = dt.Rows[0]["TIN"].ToString();
                    em.SSCN = dt.Rows[0]["SSCN"].ToString();
                    em.Image = dt.Rows[0]["Image"].ToString();
                    em.Description = dt.Rows[0]["Description"].ToString();
                    em.MonthlySalary = Math.Round(decimal.Parse(dt.Rows[0]["MonthlySalary"].ToString()), 2);


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

            return em;
        }
        #endregion
    }
}
