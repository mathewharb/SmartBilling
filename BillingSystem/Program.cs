using BillingSystem.VIEW;
using SmartRestaurantManagementSystem.Views.Auth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // APPLICATION NAME: SmartBilling
            // AUTHOR:           Mathew Harb
            // SITE:             https://github.com/mathewharb
            // EMAIL:            harbmathew@yahoo.com
            // CONTACT:          +2207425159



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //HANDLING THE SetupFile CREATION IN THE FOLDER CALLED "AppSettings"
            string locationPath = "";

            //the path to the Logs folder
            // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
            //given variable i.e "0" the length of "Application.StartupPath.Length-10"
            string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

            //gets the path to the folder location
            locationPath = fullPath + "\\AppSettings\\";
            string strFileName = locationPath + "SetupFile.txt";
            string fileText = File.ReadAllText(strFileName);

            if (fileText.ToString() != "complete")
            {

                Application.Run(new frmSettings());

            }
            else
            {
                Application.Run(new frmLogin());

            }
          
        }
    }
}
