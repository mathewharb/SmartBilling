using BillingSystem.CONTROLLER;
using BillingSystem.MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.VIEW.FrontendSetup
{
    public partial class frmAppSettings : Form
    {
        public frmAppSettings()
        {
            InitializeComponent();
        }

        //creates appsettings Model and Controller Objects
        AppSettingModel asm = new AppSettingModel();
        AppSettingsController asc = new AppSettingsController();

        public static string TextPrinterSetings;

        public static string TextUnitWidth;
        public static string TextUnitHeight;
        public static string TextFontSize;



        //creates the image 
        string BGimageName = "BG-Image.jpg";

        string LogoimageName = "Logo-Image.jpg";

        string rowHeaderBGImage;
        string rowHeaderLogoImage;

        string imagePath = "";
        string locationPath = "";

        private void tabPageEditProfile_Click(object sender, EventArgs e)
        {

        }

        private void textID_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnLogo_Click(object sender, EventArgs e)
        {
            //UPLOADING THE LOGO

            //1. opens the dialogue box to select the image
            OpenFileDialog Fopen = new OpenFileDialog();

            //2. check the type of file to upload eg(.jpg, .pn. etc)
            Fopen.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.PNG; *.gif;)|*.jpg; *.jpeg; *.png; *.PNG; *.gif;";

            //3. checks whether the file is selected or not
            if (Fopen.ShowDialog() == DialogResult.OK)
            {
                //4. checks whether such file exists
                if (Fopen.CheckFileExists)
                {
                    //5. if the file exists, then display it in the picture box
                    pictureBoxEditLogo.Image = new Bitmap(Fopen.FileName);

                    //RENAMING THE SELECTED IMAGE
                    //6. get the file extension of the image
                    string imgExt = Path.GetExtension(Fopen.FileName);

                    //7. generate random value for the file name
                    Random rand = new Random();
                    int randValue = rand.Next(0, 1000);

                    //8. generate a unique name for the image
                    LogoimageName = "Harbs_Billing_Sys_Logo_" + imgExt;

                    //UPLOAD THE IMAGE TO THE IMAGES FOLDER
                    //9. get the path of the selected image
                    imagePath = Fopen.FileName;

                    //10. the path to the images folder
                    // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
                    //given variable i.e "0" the length of "Application.StartupPath.Length-10"
                    string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

                    //11. get the path to the folder location
                    locationPath = fullPath + "\\Images\\" + LogoimageName;

                    //12. Finally Move the image to the images folder
                    //File.Copy(imagePath, locationPath);


                    //HANDLING IMAGE UPDATE AND DELETION OF OLD IMAGE
                    try
                    {
                        //uploads the image to be updated
                        if (LogoimageName != "Logo-Image.jpg")
                        {
                            //12. Finally Move the image to the images folder
                            File.Copy(imagePath, locationPath);

                        }
                        //then delete the old image
                        if (rowHeaderLogoImage != "Logo-Image.jpg")
                        {
                            //full path to the image folder
                            fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                            //gets the path to the image location
                            string locationPath = fullPath + "\\Images\\" + rowHeaderLogoImage;

                            //calls the garbage collection function
                            GC.Collect();
                            GC.WaitForPendingFinalizers();


                            //finally delete the user profile image from storage
                            File.Delete(locationPath);

                        }

                    }
                    catch (Exception)
                    {

                    }


                }
            }
        }

        private void btnBGImage_Click(object sender, EventArgs e)
        {
            //UPLOADING THE LOGO

            //1. opens the dialogue box to select the image
            OpenFileDialog Fopen = new OpenFileDialog();

            //2. check the type of file to upload eg(.jpg, .pn. etc)
            Fopen.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.PNG; *.gif;)|*.jpg; *.jpeg; *.png; *.PNG; *.gif;";

            //3. checks whether the file is selected or not
            if (Fopen.ShowDialog() == DialogResult.OK)
            {
                //4. checks whether such file exists
                if (Fopen.CheckFileExists)
                {
                    //5. if the file exists, then display it in the picture box
                    pictureBoxEditBGImage.Image = new Bitmap(Fopen.FileName);

                    //RENAMING THE SELECTED IMAGE
                    //6. get the file extension of the image
                    string imgExt = Path.GetExtension(Fopen.FileName);

                    //7. generate random value for the file name
                    Random rand = new Random();
                    int randValue = rand.Next(0, 1000);

                    //8. generate a unique name for the image
                    BGimageName = "Harbs_Billing_Sys_BGImage_" + imgExt;

                    //UPLOAD THE IMAGE TO THE IMAGES FOLDER
                    //9. get the path of the selected image
                    imagePath = Fopen.FileName;

                    //10. the path to the images folder
                    // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
                    //given variable i.e "0" the length of "Application.StartupPath.Length-10"
                    string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

                    //11. get the path to the folder location
                    locationPath = fullPath + "\\Images\\" + BGimageName;

                    //12. Finally Move the image to the images folder
                    //File.Copy(imagePath, locationPath);


                    //HANDLING IMAGE UPDATE AND DELETION OF OLD IMAGE
                    try
                    {
                        //uploads the image to be updated
                        if (BGimageName != "BG-Image.jpg")
                        {
                            //12. Finally Move the image to the images folder
                            File.Copy(imagePath, locationPath);

                        }
                        //then delete the old image
                        if (rowHeaderBGImage != "BG-Image.jpg")
                        {
                            //full path to the image folder
                            fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                            //gets the path to the image location
                            string locationPath = fullPath + "\\Images\\" + rowHeaderBGImage;



                            //calls the garbage collection function
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            //finally delete the user profile image from storage
                            File.Delete(locationPath);
                        }

                        //uploads the image to be updated
                        // if (imageName != "BG-Image.jpg")
                        // {
                        //12. Finally Move the image to the images folder
                        //  File.Copy(imagePath, locationPath);

                        // }
                    }
                    catch (Exception)
                    {

                    }


                }
            }
        }

        //creates a the data table to insert the parameters into the data grid view
        DataTable dtbl = new DataTable();

        private void frmAppSettings_Load(object sender, EventArgs e)
        {
            //creates the columns for the data grid view when the form loads
            dtbl.Columns.Add("Product");
            dtbl.Columns.Add("Quantity");
            dtbl.Columns.Add("Unit");
            dtbl.Columns.Add("Price");

            dtbl.Columns.Add("Total");


            //adds the parameters to the data grid view
            dtbl.Rows.Add("Flour", 50, "kg", 25, 50*25);
            dtbl.Rows.Add("Milk", 5, "tin", 30, 5 * 30);
            dtbl.Rows.Add("Pen", 20, "pkt", 5, 20 * 5);
            dtbl.Rows.Add("Book", 50, "kg", 5, 50 * 5);

            //int UnitWidth = int.Parse(textUnitWidth.Text);
           // int UnitHeight = int.Parse(textUnitHeight.Text);
           // int FontSize = int.Parse(textFontSize.Text);

            //displays the parameters in the data grid view
            dataGridReceiptData.DataSource = dtbl;

            //DRAWS A RECEIPT AND PLACES IT IN THE PICTURE BOX FOR PREVIEW
            PB.Image = frmSales.DrawReceipt(dataGridReceiptData.Rows, " HB2233092022", " 2022-09-10", 2400);

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridReceiptData.Columns[0].Width = 200;
            dataGridReceiptData.Columns[1].Width = 70;
            dataGridReceiptData.Columns[2].Width = 50;
            dataGridReceiptData.Columns[3].Width = 100;
            //dataGridAddedProducts.Columns[4].Width = 100;
            // dataGridAddedProducts.Columns[5].Width = 0;
            //dataGridAddedProducts.Columns[5].Visible = false;
            dataGridReceiptData.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataTable dtblSelect = asc.Select();
            
                textID.Text = dtblSelect.Rows[0][0].ToString();

                textApplicationName.Text = dtblSelect.Rows[0][1].ToString();
                BGimageName = dtblSelect.Rows[0][2].ToString();
                LogoimageName = dtblSelect.Rows[0][3].ToString();
                textFooterTitle.Text = dtblSelect.Rows[0][4].ToString();
                textFooterText.Text = dtblSelect.Rows[0][5].ToString();

                textPrinterDetails.Text=dtblSelect.Rows[0][6].ToString();
                textDetailsUnitWidth.Text= dtblSelect.Rows[0][7].ToString();
                textDetailsUnitHeight.Text = dtblSelect.Rows[0][8].ToString();
                textdetailsFontSize.Text = dtblSelect.Rows[0][9].ToString();

                textEditApplicationName.Text = dtblSelect.Rows[0][1].ToString();
                BGimageName = dtblSelect.Rows[0][2].ToString();
                LogoimageName = dtblSelect.Rows[0][3].ToString();
                textEditFooterTitle.Text = dtblSelect.Rows[0][4].ToString();
                textEditFooterText.Text = dtblSelect.Rows[0][5].ToString();

                textPrinterName.Text = dtblSelect.Rows[0][6].ToString();
                textUnitWidth.Text = dtblSelect.Rows[0][7].ToString();
                textUnitHeight.Text = dtblSelect.Rows[0][8].ToString();
                textFontSize.Text = dtblSelect.Rows[0][9].ToString();

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
                        pictureBoxBGImage.Image = new Bitmap(locationPath);
                        pictureBoxEditBGImage.Image = new Bitmap(locationPath);
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
                    pictureBoxBGImage.Image = new Bitmap(locationPath);
                    pictureBoxEditBGImage.Image = new Bitmap(locationPath);

               }

            if (LogoimageName != "Logo-Image.jpg")
            {

                try
                {
                    //gets the path to the folder location
                    string locationPath = fullPath + "\\Images\\" + LogoimageName;

                    // displays the image in the picture box
                    pictureBoxLogo.Image = new Bitmap(locationPath);
                    pictureBoxEditLogo.Image = new Bitmap(locationPath);
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
                pictureBoxEditLogo.Image = new Bitmap(locationPath);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //vlidating the input 
            if (textEditApplicationName.Text.Equals(string.Empty))
            {
                textEditApplicationName.Focus();
                return;

            }
            if (textEditFooterTitle.Text.Equals(string.Empty))
            {

                textEditFooterTitle.Focus();
                return;
            }
            if (textEditFooterText.Text.Equals(string.Empty))
            {

                textEditFooterText.Focus();
                return;
            }

            //perform the update operation if the id is not empty
            if (!textID.Text.Equals(string.Empty))
            {
                try
                {
                    asm.AppSettingsID = Convert.ToInt32(textID.Text);
                    asm.ApplicationName= textEditApplicationName.Text.ToUpper();
                    asm.BackgroundImage= BGimageName;
                    asm.Logo= LogoimageName;
                    asm.FooterTitle= textEditFooterTitle.Text;
                    asm.FooterText= textEditFooterText.Text;

                    //assigns the instance of the update method to a boolean variable
                    bool SuccessUpdate = asc.UpdateAppSettings(asm);

                    //checks if the record is updated or not
                    if (SuccessUpdate == true)
                    {
                        MessageBox.Show("Settings Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();

                        frmAppSettings AppsetupForm = new frmAppSettings();
                        AppsetupForm.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Could Not Update Settings", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception)
                {

                }

                return;
            }
         
        }

        private void tabPageEditPrinter_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectPrinter_Click(object sender, EventArgs e)
        {
            //selecting the printer
            System.Windows.Forms.PrintDialog PrintDLG = frmSales.printDLG2;
            if (PrintDLG.ShowDialog()==System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }
            
            //stores only the printr name
            textPrinterName.Text = PrintDLG.PrinterSettings.PrinterName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //vlidating the input 
            if (textPrinterName.Text.Equals(string.Empty))
            {
                return;
            }

            //perform the printer update operation if the id is not empty
            if (!textID.Text.Equals(string.Empty))
            {
                try
                {
                    asm.AppSettingsID = Convert.ToInt32(textID.Text);
                    asm.UnitWidth = Convert.ToInt32(textUnitWidth.Text);
                    asm.UnitHeight = Convert.ToInt32(textUnitHeight.Text);
                    asm.FontSize = Convert.ToInt32(textFontSize.Text);
                    asm.Printer = textPrinterName.Text;

                    //assigns the instance of the update method to a boolean variable
                    bool SuccessUpdate = asc.UpdatePrinterSettings(asm);

                    //checks if the record is updated or not
                    if (SuccessUpdate == true)
                    {
                        MessageBox.Show("Printer Settings Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        TextPrinterSetings = textPrinterName.Text;
                        TextUnitWidth = textUnitWidth.Text;
                        TextUnitHeight = textUnitHeight.Text;
                        TextFontSize = textFontSize.Text;

                        this.Close();

                        frmAppSettings AppsetupForm = new frmAppSettings();
                        AppsetupForm.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Could Not Update Printer Settings", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                catch (Exception)
                {

                }

                return;
            }
        }

        private void textdetailsFontSize_TextChanged(object sender, EventArgs e)
        {

        }

        private void textUnitWidth_TextChanged(object sender, EventArgs e)
        {
            int i = int.Parse(textUnitWidth.Text);
            if (i < 0)
            {
                return;
            }
            try
            {

                //DRAWS A RECEIPT AND PLACES IT IN THE PICTURE BOX FOR PREVIEW
                PB.Image = frmSales.DrawReceipt(dataGridReceiptData.Rows, " HB2233092022", " 2022-09-10", 2400);
            }
            catch (Exception)
            {
                MessageBox.Show("You Need To Enter A Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
