
using BillingSystem.CONTROLLER;
using BillingSystem.MODEL;
using BillingSystem.VIEW;
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

namespace NGOManagementSystem.Views.Users
{
    public partial class frmUserProfile : Form
    {
        public frmUserProfile()
        {
            InitializeComponent();
        }
        //create an instance of UsersController and UserModel class
        UsersController uc = new UsersController();
        UserModel um = new UserModel();

        //creates Employee Model and Controller Objects
        EmployeesController ec = new EmployeesController();
        EmployeeModel em = new EmployeeModel();

        //creates Profile Model and Controller Objects
        ProfileModel pm = new ProfileModel();
        ProfilesController pc = new ProfilesController();


        //creates the image 
        string imageName = "No-Image.png";

        string rowHeaderImage;

        string imagePath = "";
        string locationPath = "";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmUserProfile_Load(object sender, EventArgs e)
        {
            //displays the logged in username
            textUsername.Text = frmLogin.loggedInUser;

            string username = textUsername.Text;
            if (username !="")
            {
                UserModel umdl = uc.SearchProfile(username);
                 textID.Text = umdl.UserID.ToString();
                // textEmployeeID.Text = umdl.Employee_ID.ToString();
                textEmployeeID.Text = umdl.Employee_ID.ToString();

                return;
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEmployeeID_TextChanged(object sender, EventArgs e)
        {
            //creates a string variable for the search text box
            string textSearch = textEmployeeID.Text;

            //checks whether the employee id returns any value or not 
            if (!textSearch.Equals(string.Empty))
            {
                //loads the search results and assign the values to their corresponding text boxes
                EmployeeModel emdl = ec.EmployeeProfileDetails(textSearch);

                //transfers the contents of the search results to their respective text boxes
                //textEmployeeID.Text = emdl.EmployeeID.ToString();
                textContact.Text = emdl.Contact;
                textEmail.Text = emdl.Email;
                textAddress.Text = emdl.Address;
                textFullName.Text = emdl.FullName;
                textDesignation.Text = emdl.Designation;
                textTIN.Text = emdl.TIN;
                textSSN.Text = emdl.SSCN;
                textDescription.Text = emdl.Description;
                textSalary.Text = emdl.MonthlySalary.ToString();
                imageName = emdl.Image;

                textProfileContact.Text = emdl.Contact;
                textProfileEmail.Text = emdl.Email;
                textProfileAddress.Text = emdl.Address;
                textProfileFullName.Text = emdl.FullName;
                textProfileDesignation.Text = emdl.Designation;
                textProfileTIN.Text = emdl.TIN;
                textProfileSSN.Text = emdl.SSCN;
                textProfileDescription.Text = emdl.Description;
                textProfileSalary.Text = emdl.MonthlySalary.ToString();
                imageName = emdl.Image;

                //textID.Text = emdl.EmployeeID.ToString();

                //sets the value of the global rowHeaderImage variable;
                rowHeaderImage = imageName;

                //DISPLAY THE IMAGE OF THE USER

                //gets the path to the image
                // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
                //given variable i.e "0" the length of "Application.StartupPath.Length-10"
                string fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                if (imageName != "No-Image.png")
                {

                    try
                    {
                        //gets the path to the folder location
                        string locationPath = fullPath + "\\Images\\" + imageName;

                        // displays the image in the picture box
                        pictureBoxProfile.Image = new Bitmap(locationPath);
                        pictureBoxProfile2.Image = new Bitmap(locationPath);
                    }
                    catch (Exception)
                    {

                    }


                }
                else
                {
                    //gets the path to the folder location
                    string locationPath = fullPath + "\\Images\\No-Image.png";

                    // displays the image in the picture box
                    pictureBoxProfile.Image = new Bitmap(locationPath);
                    pictureBoxProfile2.Image = new Bitmap(locationPath);
                }
            }
            else
            {
                //creates a string variable for the search text box
                string textSearchUser = textUsername.Text;

                UserModel umdl = uc.SearchProfile(textSearchUser);

                textUsername.Text = umdl.UserName;
                textFullName.Text = umdl.FullName;
                textEmail.Text = umdl.Email;
                textContact.Text = umdl.Contact;

                textEmployeeID.Text = "";
                textAddress.Text = "";
                textDesignation.Text = "";
                textTIN.Text = "";
                textSSN.Text = "";
                textDescription.Text = "";
                textSalary.Text = "";

                textProfileDesignation.Text = "";
                textProfileDesignation.ReadOnly = true;
                textProfileAddress.Text = "";
                textProfileAddress.ReadOnly = true;
                textProfileTIN.Text = "";
                textProfileTIN.ReadOnly = true;
                textProfileSSN.Text = "";
                textProfileSSN.ReadOnly = true;
                textProfileSalary.Text = "";
                textProfileDescription.Text = "";
                textProfileDescription.ReadOnly = true;

                //the path to the images folder
                // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
                //given variable i.e "0" the length of "Application.StartupPath.Length-10"
                string fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                //get the path to the folder location
                string locationPath = fullPath + "\\Images\\No-Image.png";

                // display the image in the picture box
                pictureBoxProfile.Image = new Bitmap(locationPath);
                pictureBoxProfile2.Image = new Bitmap(locationPath);


            }

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

            frmUserProfile profileForm = new frmUserProfile();
            profileForm.ShowDialog();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //vlidating the input 
            if (textProfileFullName.Text.Equals(string.Empty))
            {
                textProfileFullName.Focus();
                return;

            }
             if (textProfileDesignation.Text.Equals(string.Empty))
            {
               
                textProfileDesignation.Focus();
                return;
            }
            if (textProfileContact.Text.Equals(string.Empty))
            {
                
                textProfileContact.Focus();
                return;
            }
            if (textProfileEmail.Text.Equals(string.Empty))
            {
                
                textProfileEmail.Focus();
                return;

            }
            if (textProfileAddress.Text.Equals(string.Empty))
            {
                
                textProfileAddress.Focus();
                return;
            }


            //perform the update operation if the logged in username and employee id is not empty
            if (!textEmployeeID.Text.Equals(string.Empty))
            {
                try
                {
                    pm.EmployeeID = Convert.ToInt32(textEmployeeID.Text);
                    pm.FullName = textProfileFullName.Text.Trim();
                    pm.Designation = textProfileDesignation.Text.Trim();
                    pm.Contact = textProfileContact.Text;
                    pm.Email = textProfileEmail.Text.Trim();
                    pm.Image = imageName;
                    pm.Address = textProfileAddress.Text;
                    pm.TIN = textProfileTIN.Text.Trim();
                    pm.SSCN = textProfileSSN.Text.Trim();
                    pm.Description = textProfileDescription.Text;
                    pm.Updated_By = textUsername.Text;
                    pm.Updated_Date = DateTime.Now;

                    //assigns the instance of the update method to a boolean variable
                    //updates the employees table with the employee details
                    bool SuccessUpdate = pc.UpdateEmployeeProfile(pm);

                    //updates the users table with the employee details
                    um.Employee_ID= Convert.ToInt32(textEmployeeID.Text);
                    um.FullName = textProfileFullName.Text.Trim();
                    um.Contact= textProfileContact.Text;
                    um.Email= textProfileEmail.Text.Trim();

                     pc.UpdateUserEmployeeProfile(um);


                    //checks if the record is updated or not
                    if (SuccessUpdate == true)
                    {
                        MessageBox.Show("Profile Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();

                        frmUserProfile profileForm = new frmUserProfile();
                        profileForm.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Could Not Update Profile", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }



                }
                catch (Exception)
                {

                }
            }
            else
            {
                try
                {
                    //updates the users table when the user is not an eployee
                   // um.Employee_ID = Convert.ToInt32(textEmployeeID.Text);
                   um.FullName = textProfileFullName.Text.Trim();
                   um.Contact = textProfileContact.Text;
                   um.Email = textProfileEmail.Text.Trim();

                    bool successUserUpdate = pc.UpdateUserOwnProfile(um);


                    //checks if the record is updated or not
                    if (successUserUpdate == true)
                   {
                       MessageBox.Show("Profile Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                   }
                   else
                   {
                      MessageBox.Show("Could Not Update Profile", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                   }
                }
                catch (Exception)
                {

                }
            }

        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            //UPLOADING THE PROFILE IMAGE

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
                    pictureBoxProfile2.Image = new Bitmap(Fopen.FileName);

                    //RENAMING THE SELECTED IMAGE
                    //6. get the file extension of the image
                    string imgExt = Path.GetExtension(Fopen.FileName);

                    //7. generate random value for the file name
                    Random rand = new Random();
                    int randValue = rand.Next(0, 1000);

                    //8. generate a unique name for the image
                    imageName = "Harbs_Billing_System_" + randValue + imgExt;

                    //UPLOAD THE IMAGE TO THE IMAGES FOLDER
                    //9. get the path of the selected image
                    imagePath = Fopen.FileName;

                    //10. the path to the images folder
                    // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
                    //given variable i.e "0" the length of "Application.StartupPath.Length-10"
                    string fullPath = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);

                    //11. get the path to the folder location
                    locationPath = fullPath + "\\Images\\" + imageName;

                    //12. Finally Move the image to the images folder
                    //File.Copy(imagePath, locationPath);


                    //HANDLING IMAGE UPDATE AND DELETION OF OLD IMAGE
                    try
                    {
                        //uploads the image to be updated
                        if (imageName != "No-Image.png")
                        {
                            //12. Finally Move the image to the images folder
                            File.Copy(imagePath, locationPath);

                        }
                        //then delete the old image
                        if (rowHeaderImage != "No-Image.png")
                        {
                            //full path to the image folder
                            fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                            //gets the path to the image location
                            string locationPath = fullPath + "\\Images\\" + rowHeaderImage;



                            //calls the garbage collection function
                            GC.Collect();
                            GC.WaitForPendingFinalizers();

                            //finally delete the user profile image from storage
                            File.Delete(locationPath);
                        }

                        //uploads the image to be updated
                       // if (imageName != "No-Image.png")
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

        private void frmUserProfile_Activated(object sender, EventArgs e)
        {
            //we use the form "Activated" event to:
            //update the user employee view each time a user updates their own profile

            string textSearch = textEmployeeID.Text;
            //loads the search results and assign the values to their corresponding text boxes
            EmployeeModel emdl = ec.EmployeeProfileDetails(textSearch);

            //transfers the contents of the search results to their respective text boxes
            //textEmployeeID.Text = emdl.EmployeeID.ToString();
            textContact.Text = emdl.Contact;
            textEmail.Text = emdl.Email;
            textAddress.Text = emdl.Address;
            textFullName.Text = emdl.FullName;
            textDesignation.Text = emdl.Designation;
            textTIN.Text = emdl.TIN;
            textSSN.Text = emdl.SSCN;
            textDescription.Text = emdl.Description;
            textSalary.Text = emdl.MonthlySalary.ToString();
            imageName = emdl.Image;

            textProfileContact.Text = emdl.Contact;
            textProfileEmail.Text = emdl.Email;
            textProfileAddress.Text = emdl.Address;
            textProfileFullName.Text = emdl.FullName;
            textProfileDesignation.Text = emdl.Designation;
            textProfileTIN.Text = emdl.TIN;
            textProfileSSN.Text = emdl.SSCN;
            textProfileDescription.Text = emdl.Description;
            textProfileSalary.Text = emdl.MonthlySalary.ToString();
            imageName = emdl.Image;

            //textID.Text = emdl.EmployeeID.ToString();

            //sets the value of the global rowHeaderImage variable;
            rowHeaderImage = imageName;

            //DISPLAY THE IMAGE OF THE USER

            //gets the path to the image
            // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
            //given variable i.e "0" the length of "Application.StartupPath.Length-10"
            string fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            if (imageName != "No-Image.png")
            {

                try
                {
                    //gets the path to the folder location
                    string locationPath = fullPath + "\\Images\\" + imageName;

                    // displays the image in the picture box
                    pictureBoxProfile.Image = new Bitmap(locationPath);
                    pictureBoxProfile2.Image = new Bitmap(locationPath);
                }
                catch (Exception)
                {

                }


            }
            else
            {
                //gets the path to the folder location
                string locationPath = fullPath + "\\Images\\No-Image.png";

                // displays the image in the picture box
                pictureBoxProfile.Image = new Bitmap(locationPath);
                pictureBoxProfile2.Image = new Bitmap(locationPath);
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
