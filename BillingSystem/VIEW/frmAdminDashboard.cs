using BillingSystem.CONTROLLER;
using BillingSystem.MODEL;
using BillingSystem.VIEW;
using BillingSystem.VIEW.Accounts;
using BillingSystem.VIEW.FrontendSetup;
using BillingSystem.VIEW.Help;
using BillingSystem.VIEW.Reports;
using NGOManagementSystem.Views;
using NGOManagementSystem.Views.Employees;
using NGOManagementSystem.Views.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.VIEW
{
    public partial class frmAdminDashboard : Form
    {
        public frmAdminDashboard()
        {
            //starts a thread for the splash screen
            Thread t = new Thread(new ThreadStart(splashScreenstart));
            //starts the thread-splash screen
            frmLogin loginForm = new frmLogin();
            loginForm.Hide();
            t.Start();

            //sets the thread interval so that the progress bar can load completely
            Thread.Sleep(5000);

            InitializeComponent();

            //aborts the thread
            t.Abort();
        }

        //splash screen functionality
        public void splashScreenstart()
        {
            Application.Run(new splashScreen());

        }

        //creates the usersController Object
        UsersController uc = new UsersController();

        AppSettingsController asc = new AppSettingsController();

        TransactionsController tc = new TransactionsController();

        StakeholdersController sc = new StakeholdersController();

        //creates the image 
        string BGimageName = "BG-Image.jpg";

        string LogoimageName = "Logo-Image.jpg";

        string rowHeaderBGImage;
        string rowHeaderLogoImage;

       // string imagePath = "";
        //string locationPath = "";

        //method to disable all the menu buttons
        private void DisableAllMenuItems()
        {
            lblProducts.Enabled = false;
            lblManageProducts.Enabled = false;
           lblCategories.Enabled = false;
           // lblCategories.Visible = false;
            //   toolStripCategories.Visible = false;
           // lblUnits.Visible = false;
            //    toolStripManageProducts.Visible = false;
            lblUnits.Enabled = false;
            btnMenuSupplier.Enabled = false;
            btnMenuCustomer.Enabled = false;
            lblTransactions.Enabled = false;
            lblPurchase.Enabled = false;
            lblSales.Enabled = false;
            lblHRM.Enabled = false;
            lblEmployees.Enabled = false;
            lblReports.Enabled = false;
            lblInventory.Enabled = false;
            lblTransactionsReport.Enabled = false;
        }
        //method to disable selected menu buttons
        private void UserMenuDisable()
        {
                   lblProducts.Enabled = true;
                   lblManageProducts.Enabled = true;
                  // lblCategories.Enabled = false;
                   lblCategories.Visible = false;
                   toolStripCategories.Visible = false;
                   lblUnits.Visible = false;
                   toolStripManageProducts.Visible = false;
                   //lblUnits.Enabled = false;
                  // btnMenuSupplier.Enabled = false;
                   btnMenuCustomer.Enabled = true;
                   lblTransactions.Enabled = true;
                   lblPurchase.Enabled = true;
                   lblSales.Enabled = true;
                  //lblHRM.Enabled = false;
                   lblHRM.Visible = false;
                  //lblEmployees.Enabled = false;
                  lblReports.Enabled = true;
                  lblInventory.Enabled = true;
                 lblTransactionsReport.Enabled = true;
        }

        //method to show the count results of the widgets on the dashboard
        private void DashBoardWidgetDisplay()
        {
            //displays the number of users
            lblUserCount.Text = uc.UserCount();

            lblCustomersCount.Text = sc.CustomersCount();

            //displays the total sales
            string salesText = "Sales";
            string purchaseText = "Purchase";                          
            DataTable dtblTotalSales = tc.TransactionsAmount(salesText);
            DataTable dtblTotalPurchase = tc.TransactionsAmount(purchaseText);
            decimal SalesAmount = 0;
            decimal PurchaseAmount = 0;
            for (int i = 0; i < dtblTotalSales.Rows.Count; i++)
            {
                SalesAmount += Math.Round(Convert.ToDecimal(dtblTotalSales.Rows[i][0].ToString()), 2);
            }
            //displays the total sales
            lblSalesCount.Text = SalesAmount.ToString();

            for (int i = 0; i < dtblTotalPurchase.Rows.Count; i++)
            {
                PurchaseAmount += Math.Round(Convert.ToDecimal(dtblTotalPurchase.Rows[i][0].ToString()), 2);
            }
            //displays the total purchases
            lblPurchaseCount.Text = PurchaseAmount.ToString();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            //Displays the Details of The application Settings
            DataTable dtblAppSetup = asc.Select();
            lblApplicationName.Text = dtblAppSetup.Rows[0][1].ToString();
            BGimageName = dtblAppSetup.Rows[0][2].ToString();
            LogoimageName = dtblAppSetup.Rows[0][3].ToString();
            lblFooterTitle.Text = dtblAppSetup.Rows[0][4].ToString();
            lblFooterText.Text = dtblAppSetup.Rows[0][5].ToString();
            //sets the value of the global rowHeaderImage variable;
            rowHeaderBGImage = BGimageName;
            rowHeaderLogoImage = LogoimageName;

            //shows the count results of the widgets on the dashboard
            DashBoardWidgetDisplay();

            //DISPLAY TTHE BG IMAGE
            //gets the path to the image
            // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
            //given variable i.e "0" the length of "Application.StartupPath.Length-10"
            string fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            if (BGimageName != "BG-Image.jpg")
            {

                try
                {
                    //gets the path to the folder location
                    string locationPath = fullPath + "\\Images\\" + BGimageName;

                    // displays the image in the picture box
                    pictureBoxDashboardBG.Image = new Bitmap(locationPath);

                }
                catch (Exception)
                {

                }


            }
            else
            {
                //gets the path to the folder location
                string locationPath = fullPath + "\\Images\\BG-Image.jpg";

                // displays the image in the picture box
                pictureBoxDashboardBG.Image = new Bitmap(locationPath);

            }

            if (LogoimageName != "Logo-Image.jpg")
            {

                try
                {
                    //gets the path to the folder location
                    string locationPath = fullPath + "\\Images\\" + LogoimageName;

                    // displays the image in the picture box
                    pictureBoxLogo.Image = new Bitmap(locationPath);
                   
                }
                catch (Exception)
                {

                }
            }
            else
            {
                //gets the path to the folder location
                string locationPath = fullPath + "\\Images\\Logo-Image.jpg";

                // displays the image in the picture box
                pictureBoxLogo.Image = new Bitmap(locationPath);
              

            }

            //displays the logged in username
            lblLoggedInUser.Text = frmLogin.loggedInUser;

            //checks if the logged in user is Admin or Not, to enable or disable General settings
            string usernametxt = frmLogin.loggedInUser;
            DataTable dtblAdminCheck = uc.CheckAdmin(usernametxt);
            if (dtblAdminCheck != null && dtblAdminCheck.Rows.Count > 0)
            {
                string checkUserType = dtblAdminCheck.Rows[0]["UserType"].ToString();
                string checkRole = dtblAdminCheck.Rows[0]["Role"].ToString();

                //checks if the user type is admin or not
                if (checkUserType=="Admin" && checkRole=="Admin")
                {
                    //enables the General settings menu when the user is admin
                    lblGeneralSettings.Visible = true;
                    lblGeneralSettings.Enabled = true;

                    lblBackuprestore.Visible = true;
                    lblBackuprestore.Enabled = true;
                }
                else if (checkUserType == "User" && checkRole == "Manager")
                {
                    //disables the General settings menu when the user is not admin
                    lblGeneralSettings.Visible = false;
                    lblGeneralSettings.Enabled = false;

                    lblBackuprestore.Visible = false;
                    lblBackuprestore.Enabled = false;

                }
                else if (checkUserType == "User" && checkRole == "User")
                {
                    //disables the General settings menu when the user is not admin
                    lblGeneralSettings.Visible = false;
                    lblGeneralSettings.Enabled = false;

                    lblBackuprestore.Visible = false;
                    lblBackuprestore.Enabled = false;

                    UserMenuDisable();
                }
                else
                {
                    //disables the General settings menu when the user is not admin
                    lblGeneralSettings.Visible = false;
                    lblGeneralSettings.Enabled = false;

                    lblBackuprestore.Visible = false;
                    lblBackuprestore.Enabled = false;

                    DisableAllMenuItems();
                }

               return;
            }
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void donorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void frmAdminDashboard_Activated(object sender, EventArgs e)
        {
            //Displays the Details of The application Settings
            DataTable dtblAppSetup = asc.Select();
            lblApplicationName.Text = dtblAppSetup.Rows[0][1].ToString();
            BGimageName = dtblAppSetup.Rows[0][2].ToString();
            LogoimageName = dtblAppSetup.Rows[0][3].ToString();
            lblFooterTitle.Text = dtblAppSetup.Rows[0][4].ToString();
            lblFooterText.Text = dtblAppSetup.Rows[0][5].ToString();
            //sets the value of the global rowHeaderImage variable;
            rowHeaderBGImage = BGimageName;
            rowHeaderLogoImage = LogoimageName;

            //DISPLAY THE IMAGE OF THE USER

            //gets the path to the image
            // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
            //given variable i.e "0" the length of "Application.StartupPath.Length-10"
            string fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            if (BGimageName != "BG-Image.jpg")
            {

                try
                {
                    //gets the path to the folder location
                    string locationPath = fullPath + "\\Images\\" + BGimageName;

                    // displays the image in the picture box
                    pictureBoxDashboardBG.Image = new Bitmap(locationPath);

                }
                catch (Exception)
                {

                }


            }
            else
            {
                //gets the path to the folder location
                string locationPath = fullPath + "\\Images\\BG-Image.jpg";

                // displays the image in the picture box
                pictureBoxDashboardBG.Image = new Bitmap(locationPath);

            }

            if (LogoimageName != "Logo-Image.jpg")
            {

                try
                {
                    //gets the path to the folder location
                    string locationPath = fullPath + "\\Images\\" + LogoimageName;

                    // displays the image in the picture box
                    pictureBoxLogo.Image = new Bitmap(locationPath);

                }
                catch (Exception)
                {

                }
            }
            else
            {
                //gets the path to the folder location
                string locationPath = fullPath + "\\Images\\Logo-Image.jpg";

                // displays the image in the picture box
                pictureBoxLogo.Image = new Bitmap(locationPath);


            }

            //shows the count results of the widgets on the dashboard
            DashBoardWidgetDisplay();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();

            frmLogin loginForm = new frmLogin();
            loginForm.ShowDialog();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void userProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens the logged in users profile
            frmUserProfile profile = new frmUserProfile();
            profile.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //opens the change password window for the logged in user
            frmChangePassword changePass = new frmChangePassword();
            changePass.ShowDialog();
        }

        private void lblManageProducts_Click(object sender, EventArgs e)
        {
            //opens the manage products window
            frmProducts productsForm = new frmProducts();
            productsForm.ShowDialog();
        }

        private void lblCategories_Click(object sender, EventArgs e)
        {
            //opens the categories window
            frmCategories categoriseForm = new frmCategories();
            categoriseForm.ShowDialog();
        }

        private void lblUnits_Click(object sender, EventArgs e)
        {
            //opens the units window
            frmUnits unitsForm = new frmUnits();
            unitsForm.ShowDialog();
        }

        private void lblAllUsers_Click(object sender, EventArgs e)
        {
            //opens the users window
            frmAllUsers usersForm = new frmAllUsers();
            usersForm.ShowDialog();
        }

        private void lblAddUser_Click(object sender, EventArgs e)
        {
            //opens the add user window
            frmAddUser addUsers = new frmAddUser();
            addUsers.ShowDialog();
        }

        private void lblUserTypes_Click(object sender, EventArgs e)
        {
            //opens the user types window
            frmUserTypes userTypesForm = new frmUserTypes();
            userTypesForm.ShowDialog();

        }

        private void lblEmployees_Click(object sender, EventArgs e)
        {
            //opens the employees window
            frmEmployees employeesForm = new frmEmployees();
            employeesForm.ShowDialog();
        }

        private void lblPurchase_Click(object sender, EventArgs e)
        {
            //opens the purchases window
            frmPurchase purchase = new frmPurchase();
            purchase.ShowDialog();

        }

        private void lblSales_Click(object sender, EventArgs e)
        {
            //opens the sales window
            frmSales salesForm = new frmSales();
            salesForm.ShowDialog();
        }

        private void lblInventory_Click(object sender, EventArgs e)
        {
            //opens the Inventory Report window
            frmInventory InventoryForm = new frmInventory();
            InventoryForm.ShowDialog();
        }

        private void lblTransactionsReport_Click(object sender, EventArgs e)
        {
            //opens the Transactions Report window
            frmTransactionsReport TransactReport = new frmTransactionsReport();
            TransactReport.ShowDialog();
        }

        private void btnMenuSupplier_Click(object sender, EventArgs e)
        {

            frmStakeholders StakeForm = new frmStakeholders();

            //changes the form title based on the clicked menu
            frmStakeholders.lblStakeholderTitle = "SUPPLIERS";

            //changes the value of the combo box based on the clicked menu
            frmStakeholders.comboCustomerSupplier = "Supplier";

            //opens the stakeholders window
            StakeForm.ShowDialog();
        }

        private void btnMenuCustomer_Click(object sender, EventArgs e)
        {
            frmStakeholders StakeForm = new frmStakeholders();

            //changes the form title based on the clicked menu
            frmStakeholders.lblStakeholderTitle = "CUSTOMERS";

            //changes the value of the combo box based on the clicked menu
            frmStakeholders.comboCustomerSupplier = "Customer";

            //opens the stakeholders window
            StakeForm.ShowDialog();

        }

        private void lblApplicationSettings_Click(object sender, EventArgs e)
        {
            //opens the Application Settings window
            frmAppSettings appSettingsForm = new frmAppSettings();

            appSettingsForm.ShowDialog();
        }

        private void profitLossStatementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProfitLoss PnL = new frmProfitLoss();
            PnL.ShowDialog();
        }

        private void lblBackuprestore_Click(object sender, EventArgs e)
        {
            frmBackuprestore backuprestore = new frmBackuprestore();
            backuprestore.ShowDialog();
        }

        private void financialYearsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFinancialYears FinalYear = new frmFinancialYears();
            FinalYear.ShowDialog();
        }

        private void lblSupport_Click(object sender, EventArgs e)
        {
            frmSupport supportForm = new frmSupport();
            supportForm.ShowDialog();
        }
    }
}
