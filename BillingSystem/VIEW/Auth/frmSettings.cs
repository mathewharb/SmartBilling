using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Xml;
using System.IO;
using BillingSystem.VIEW.Auth;
using BillingSystem.VIEW;

namespace SmartRestaurantManagementSystem.Views.Auth
{
    public partial class frmSettings : frmAuthTemplate
    {
        public frmSettings()
        {
            InitializeComponent();
        }
        
        static string strCharencode = "utf-8";
        static string strVersion = "1.0";
        static string topVar1 ="<?xml version=" + '"' + strVersion + '"' + " "  + "encoding="+'"'+ strCharencode+'"' + " " +  "?>";

        static string topVar2 = "<configuration>";
        static string topVar3 = " " + " " + " " + " " + "<startup>";

        static string RTVersion= "v4.0";
        static string NTFVersion = "v4.5.2";
        static string topVar4 = " " + " " + " " + " " + " " + " " + " " + " " + "<supportedRuntime" + " " + "version=" + '"' + RTVersion + '"' + " " + "sku=" + '"' + ".NETFramework,Version=" + NTFVersion + '"' + " " + "/" + ">";

        static string topVar5 = " " + " " + " " + " " + "</startup>";


        static string Disp1 = " " + " " + " " + " " + "<connectionStrings>";

        static string connection;
        static string AddCon = "constr";
        static string Disp2 = " " + " " + " " + " " + " " + " " + "<add name=" + '"' + AddCon + '"' + " " + "connectionString=" + '"' ;

        static string Disp3 ='"' + "/" + ">";

        static string Disp4 = " " + " " + " " + " " + "</connectionStrings>";

        static string Disp5= "</configuration>";

        string locationPath = "";

        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


        //HANDLING THE SetupFile CREATION IN THE FOLDER CALLED "AppSettings"
        string locationPath2 = "";
       
        //the path to the AppSettings folder
        // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
        //given variable i.e "0" the length of "Application.StartupPath.Length-10"
        string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

        private void frmSettings_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void checkIntegratedSecurity_CheckedChanged(object sender, EventArgs e)
        {
            if (checkIntegratedSecurity.Checked) {

                //disables the user id and password text boxes when integrated security is checked
                textUserID.Enabled = false;
                textPassword.Enabled = false;
                textUserID.Text = "";
                textPassword.Text = "";
            }
            else
           {
                //enables the  user id and password text boxes when integrated security is unchecked
                textUserID.Enabled = true;
                textPassword.Enabled = true;
           }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (checkIntegratedSecurity.Checked)
            {
                if (textServer.Text == "")
                {
                    errorProvider1.SetError(textServer, "Server Name Cannot Be Empty");
                    return;
                }
                if (textDatabase.Text == "")
                {
                    errorProvider1.SetError(textDatabase, "Database Name Cannot Be Empty");
                    return;
                }

                connection = "Data Source=" + textServer.Text + ";Initial Catalog=" + textDatabase.Text + ";Integrated Security=True" + " ";

                string conVar = Disp2 + connection + Disp3;

                //gets the path to the folder location
                locationPath = path;

                string[] arr = { topVar1, topVar2, topVar3, topVar4, topVar5, Disp1, conVar, Disp4, Disp5 };

                System.IO.File.WriteAllLines(locationPath + "\\Harb_setup.txt", arr);


                //gets the path to the folder location
                locationPath2 = fullPath + "\\AppSettings\\" + "SetupFile.txt";

                System.IO.File.WriteAllText(locationPath2, "complete".ToString());

                MessageBox.Show("The Database Settings File Named Harb_setup.txt Has Been Successsfully Created and Saved on Your Desktop", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }
            else
            {
                if (textServer.Text == "")
                {
                    errorProvider1.SetError(textServer, "Server Name Cannot Be Empty");
                    return;
                }
                if (textDatabase.Text == "")
                {
                    errorProvider1.SetError(textDatabase, "Database Name Cannot Be Empty");
                    return;
                }
                if (textUserID.Text == "")
                {
                    errorProvider1.SetError(textUserID, "Database User Name Cannot Be Empty");
                    return;
                }
                if (textPassword.Text == "")
                {
                    errorProvider1.SetError(textPassword, "Password Cannot Be Empty");
                    return;
                }

                   connection = "Data Source=" + textServer.Text + ";Initial Catalog=" + textDatabase.Text + ";Persist Security Info=True;User ID=" + textUserID.Text + ";Password=" + textPassword.Text + " ";

                   string conVar = Disp2 + connection + Disp3 ;

                    //gets the path to the folder location
                    locationPath = path;

                    string[] arr = {topVar1, topVar2, topVar3, topVar4, topVar5, Disp1, conVar,  Disp4, Disp5};

                    System.IO.File.WriteAllLines(locationPath + "\\Harb_setup.txt", arr);


       

                //gets the path to the folder location
                locationPath2 = fullPath + "\\AppSettings\\" + "SetupFile.txt";

                System.IO.File.WriteAllText(locationPath2, "complete".ToString());


                MessageBox.Show("The Database Settings File Named Harb_setup.txt Has Been Successsfully Created and Saved on Your Desktop", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Application.Exit();
            }
        }
    }
}
