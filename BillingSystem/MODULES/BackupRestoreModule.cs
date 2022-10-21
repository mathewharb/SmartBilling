using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace BillingSystem.MODULES
{
    //this module is used to backup and restore the database
   public class BackupRestoreModule
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

        //CONCEPTS FOR THE BACKUP FUNCTIONALITY
        //1. loop over every table and save it
        //2. loop over every row and save it
        //------inorder to loop over every table and row and save it;------loop over each field and save it
        //---------inorder to save the field;------------------------------first save the field length followed by the field value
        //-------------inorder to save the field length and field value;---store the values as bytes.

        //METHOD TO GET THE LIST OF ALL THE TABLES
        public List<string> GetListOfTables()
        {
            var LS = new List<string>();
           //List<string> LS = new List<string>();

            LS.Add("appsettings");
            LS.Add("categories");
            LS.Add("employees");
            LS.Add("financialyears");
            LS.Add("products");
            LS.Add("stakeholders");
            LS.Add("transaction_details");
            LS.Add("transactions");
            LS.Add("units");
            LS.Add("users");
            LS.Add("userTypes");

            return LS;
        }

        #region BACKUP
        //METHOD TO BE ABLE TO SAVE THE DATABASE
        public bool SaveDatabase(SqlConnection conn, string FileName) 
        {
            bool saveSuccess = false;
           // SqlConnection conn = new SqlConnection(Myconstr);

            try
            {
                //writing to the file
                System.IO.FileStream FS = new System.IO.FileStream(FileName,System.IO.FileMode.Create);

                //1. loops over every table and save it
                int i;
                var TableList = GetListOfTables();
                for (i = 0; i <= TableList.Count - 1; i++)
                {
                    //save the table , passing the tablelist of (i)
                    SaveTable(conn,FS, TableList[i]); 
                }

                return true;

            }
            catch (Exception ex)
            {
                //displays any exceptional error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());

                conn.Close();
                conn.Dispose();
            }

            return saveSuccess;
        }

        public void SaveString(System.IO.FileStream FS, string Val)
        {
            //writes a string into the filestream
            //first convert the string into an array of bytes

            //gets the encodings and call the getbytes method
            var B= System.Text.Encoding.GetEncoding("windows-1256").GetBytes(Val);
            long BytesLength = B.Length;

            int B1;
            int B2;
            int B3;
            int B4;

            byte BytesLength1 = Convert.ToByte(BytesLength);
            B1 = BytesLength1;
            BytesLength1= Convert.ToByte(BytesLength/256);

            byte BytesLength2 = Convert.ToByte(BytesLength);
            B2 = BytesLength2;
            BytesLength2 = Convert.ToByte(BytesLength / 256);

            byte BytesLength3 = Convert.ToByte(BytesLength);
            B3 = BytesLength3;
            BytesLength3 = Convert.ToByte(BytesLength / 256);

            byte BytesLength4 = Convert.ToByte(BytesLength);
            B4 = BytesLength4;
            BytesLength4 = Convert.ToByte(BytesLength / 256);

            //writes the length
            FS.WriteByte(Convert.ToByte(B1));
            FS.WriteByte(Convert.ToByte(B2));
            FS.WriteByte(Convert.ToByte(B3));
            FS.WriteByte(Convert.ToByte(B4));

            //writes the array-helps to write a single value intp the filestream
            FS.Write(B, 0, B.Length);

        }

        public void saveRow(System.IO.FileStream FS, DataTable DT,int index)
        {
            SaveString(FS, DT.Columns.Count.ToString());

            SaveString(FS, DT.Rows.Count.ToString());

            int i;
            for (i = 0; i <= DT.Columns.Count - 1; i++)
            {
                SaveString(FS, DT.Columns[i].ColumnName);
                string ValueObj="";

                if (DT.Columns[i].DataType == GetType())
                {
                    ValueObj = DT.Rows[index].ItemArray[i].ToString();
                }
                else
                { 
                    ValueObj = DT.Rows[index].ItemArray[i] + "";
                }
                //saves the value
                SaveString(FS, ValueObj);

            }

        }
        public void SaveTable(SqlConnection conn, System.IO.FileStream FS, string TableName)
        {
            //SqlConnection conn = new SqlConnection(Myconstr);

            //store table name and then store table rows
            SaveString(FS, TableName);

            //reads the value from the database after saving the table
            DataTable DT = new DataTable();
            string sql = ("select * from " + TableName);
            SqlDataAdapter DB = new SqlDataAdapter(sql, conn);
            DB.Fill(DT);

            //saves the table row by row
            SaveString(FS, DT.Rows.Count.ToString());
            int i;
            for (i = 0; i <=DT.Rows.Count-1; i++)
            {
                //calls a method called sSaveRow()
                saveRow(FS, DT,i);

            }


        }
        #endregion



        #region RESTORE 
        //RESTORE FUNCTIONALITY
        public string LoadString(System.IO.FileStream FS)
        {
            long B1;
            long B2;
            long B3;
            long B4;

            //reads the bytes
            B1= FS.ReadByte();
            B2 = FS.ReadByte();
            B3 = FS.ReadByte();
            B4 = FS.ReadByte();

            //creates the actual length from the four bytes
            long StrLen = B1 + B2 * 256 + B3 * (256 * 256) + B4 * (256 * 256 * 256);

            //creates the byte array
            byte[] B = new byte[StrLen - 1];

            //reads the byte from the file
            int Start = 0;
            do
            {
              Start += FS.Read(B, Start, Convert.ToInt32( StrLen)-Start);

            } while (Start != StrLen);

            //converts the value to string
            string Result = System.Text.Encoding.GetEncoding("windows-1256").GetString(B);

            return Result;
        }

        //METHOD FOR LOADING A SINGLE ROW - FOR THE RESTORE FUNCTIONALITY
        public void LoadRow(System.IO.FileStream FS, SqlConnection conn, string TableName)
        {
            conn = new SqlConnection(Myconstr);

            //first get the number of columns
            int ColCount = int.Parse(LoadString(FS));

            //sql statement
            string SQL = "Insert into" + TableName + " (";

            string PRMStr = "(";
            int I;
            object PRMS=new object[0, ColCount - 1];
            for (I = 0; I <= ColCount - 1; I++)
            {
                string ColName = LoadString(FS);
                string Val = LoadString(FS);

                SQL = SQL + ColName;

                PRMStr = PRMStr + "@" + I.ToString();

                //checks if I is smaller than the last column
                if (I < ColCount-1)
                {
                    SQL = SQL + ",";

                    PRMStr = PRMStr + ",";
                }

             PRMS = Val;
            }

            SQL = SQL + ") values " + PRMStr + ") SELECT @@IDENTITY";

            //finally, execute the sql statement
            SqlCommand cmd = new SqlCommand(SQL, conn);
            //cmd.Parameters.AddWithValue(SQL,TableName);
            //conn.Open();

            // cmd.ExecuteNonQuery();

            cmd.ExecuteScalar();

        }

        //METHOD TO LOAD A SINGLE TABLE - FOR THE RESTORE FUNCTIONALITY
        public void LoadTable(System.IO.FileStream FS, SqlConnection conn, string TableName)
        {
            conn = new SqlConnection(Myconstr);

            //first, get the table name
            string TM = LoadString(FS);

            //checks if TM doesnt equal the table name, which means that a different table is being loaded
            if (TM !=TableName)
            {
                //throws an error if a different table is loaded
                throw new Exception("Wrong Table Name");
            }

            //if all went well, then check how many values are in the table
            int RowCount = int.Parse(LoadString(FS));

            //deletes all the information when loading a table
            string DSQL = "delete from " + TableName;
            SqlCommand cmd = new SqlCommand(DSQL, conn);
            //cmd.Parameters.AddWithValue(DSQL, TableName);
            //conn.Open();
            cmd.ExecuteNonQuery();

            int I;
            for (I=0; I <=RowCount -1; I++)
            {
                LoadRow(FS, conn, TableName);
            }
        }

        //METHOD TO LOAD THE FULL DATABASE - FOR THE RESTORE FUNCTIONALITY
        public bool LoadDatabase(SqlConnection conn, string FileName)
        {
            bool loadSuccess = false;

            try
            {
                //opens the file for reading
                System.IO.FileStream FS = new System.IO.FileStream(FileName, System.IO.FileMode.Open);

                //loops over every table
                int i;
                var TableList = GetListOfTables();
                for (i = 0; i >= TableList.Count - 1; i++)
                {
                    //save the table , passing the tablelist of (i)
                    LoadTable(FS, conn, TableList[i]);
                }
                
                return true;
            }
            catch (Exception ex)
            {
                //displays any exceptional error messages
                MessageBox.Show(ex.Message);

                //gets the path to the folder location
                locationPath = fullPath + "\\Logs\\";

                //prints out the error log details in the file called "Error_Log.txt", located in the "Logs" directory
                System.IO.File.AppendAllText(locationPath + "Error_Log.txt", ex.ToString());

                conn.Close();
                conn.Dispose();
            }

            return loadSuccess;
        }
        #endregion

    }
}
