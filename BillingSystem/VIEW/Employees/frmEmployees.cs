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

namespace NGOManagementSystem.Views.Employees
{
    public partial class frmEmployees : Form
    {
        public frmEmployees()
        {
            InitializeComponent();
        }

        //creates Employee Model and Controller Objects
        EmployeeModel em = new EmployeeModel();
        EmployeesController ec = new EmployeesController();

        //creates the image 
        string imageName = "No-Image.png";

        string rowHeaderImage;

        string imagePath = "";
        string locationPath = "";

        //method to clear the text boxes
        private void clearText()
        {

            //clears the text boxes
            textID.Text = "";
           textFullName.Text="";
           textDesignation.Text="";
           textContact.Text="";
           textEmail.Text="";
           textAddress.Text="";
           textTIN.Text="";
           textSSN.Text="";
           textDescription.Text="";
           textSalary.Text="";

            //the path to the images folder
            // the function "Substring(0, Application.StartupPath.Length-10)" selects the length of the string between the 
            //given variable i.e "0" the length of "Application.StartupPath.Length-10"
            string fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            //get the path to the folder location
            string locationPath = fullPath + "\\Images\\No-Image.png";

            // display the image in the picture box
            pictureBoxProfile.Image = new Bitmap(locationPath);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
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
                    pictureBoxProfile.Image = new Bitmap(Fopen.FileName);

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
                           // File.Copy(imagePath, locationPath);

                       // }
                    }
                    catch (Exception)
                    {

                    }


                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string FullName = textFullName.Text.Trim();
            string Email = textEmail.Text.Trim();
            string TIN = textTIN.Text.Trim();
            string SSCN = textSSN.Text.Trim();

            //data atable to check if the user already exists
            DataTable dtblFullName = ec.EmployeeExists(FullName);
            DataTable dtblEmail = ec.EmployeeExists(Email);
           // DataTable dtblTIN = ec.EmployeeExists(TIN);
            // DataTable dtblSSCN = ec.EmployeeExists(SSCN);

            //vlidating the input 
            if (textFullName.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textFullName, "Full Name Cannot Be Empty");
                textFullName.Focus();

            }else if (textDesignation.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textDesignation, "Designation Cannot Be Empty");
                textDesignation.Focus();
            }
            else if (textContact.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textContact, "Contact Number Cannot Be Empty");
                textContact.Focus();
            }
            else if (textEmail.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textEmail, "Email Cannot Be Empty");
                textEmail.Focus();

            }
            else if (textAddress.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textAddress, "Address Cannot Be Empty");
                textAddress.Focus();
            }
            else if (textSalary.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textSalary, "Salary Cannot Be Empty");
                textSalary.Focus();
            }
            else if (!dtblFullName.Rows.Equals(null) && dtblFullName.Rows.Count > 0)
            {
                MessageBox.Show("There Is Another Employee With The Same Full Names", "Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textFullName.Focus();
            }
            else if (!dtblEmail.Rows.Equals(null) && dtblEmail.Rows.Count > 0)
            {
                MessageBox.Show("There Is Another Employee With The Same EMail Address", "Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                textEmail.Focus();
            }
           // else if (!dtblTIN.Rows.Equals(null) && dtblTIN.Rows.Count > 0)
           // {
               // MessageBox.Show("This TIN Number is Already Being used By Another Employee", "Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                //textTIN.Focus();
           // }
           // else if (!dtblSSCN.Rows.Equals(null) && dtblSSCN.Rows.Count > 0)
            //{
               // MessageBox.Show("There Is Another Employee With The same Social Security Number", "Already Taken", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               // textSSN.Focus();
            //}
            else
            {
                //insert functionality

                try
                {
                    //gets the logged in user who created the record
                    //this will be inserted in the created_by table field
                    string creator;
                    creator = frmLogin.loggedInUser;

                    //gets the user input values to be inserted into thedatabase
                    em.FullName = textFullName.Text.Trim();
                    em.Designation = textDesignation.Text.Trim();
                    em.Contact = textContact.Text.Trim();
                    em.Email = textEmail.Text.Trim();
                    em.Image = imageName;
                    em.Address = textAddress.Text;
                    em.TIN = textTIN.Text.Trim();
                    em.SSCN = textSSN.Text.Trim();
                    em.Description = textDescription.Text;
                    em.MonthlySalary = Math.Round(decimal.Parse(textSalary.Text),2);
                    em.Created_By = creator;
                    em.Created_Date = DateTime.Now;

                    decimal salary = decimal.Parse(textSalary.Text);
                   
                    if (salary <0)
                    {
                        MessageBox.Show("Salary Can Only Be A Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        //assigns the instance of the insert method to a boolean variable
                        bool SuccessInsert = ec.Insert(em);

                        //checks if the record is inserted or not
                        if (SuccessInsert == true)
                        {
                            MessageBox.Show("Employee Created Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //clears the text boxes
                            clearText();

                            //disables the Update and delete Buttons
                            btnUpdate.Enabled = false;
                            btnDelete.Enabled = false;

                            //loads the contents of the data grid view
                            DataTable dtbl = ec.Select();
                            dataGridEmployee.DataSource = dtbl;
                        }
                        else
                        {
                            MessageBox.Show("Could Not Create Employee", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                //UPLOADING THE IMAGE
                try
                {
                    //only uploads the image when it is selected
                    if (imageName != "No-Image.png")
                    {
                        //12. Finally Move the image to the images folder
                        File.Copy(imagePath, locationPath);
                    }
                }
                catch (Exception)
                {

                }
            }

        }

        private void frmEmployees_Load(object sender, EventArgs e)
        {
            clearText();
            //loads the contents of the data grid view
            DataTable dtbl = ec.Select();
            dataGridEmployee.DataSource = dtbl;
        }

        private void dataGridEmployee_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //checks if only one row is selected or not
            if (dataGridEmployee.SelectedRows.Count == 1)
            {
                //creates the variable to store the row header index
                int rowIndex = e.RowIndex;

                //displays the contents of the selected row in their respective text boxes
                textID.Text = dataGridEmployee.Rows[rowIndex].Cells[0].Value.ToString();
                textFullName.Text = dataGridEmployee.Rows[rowIndex].Cells[1].Value.ToString();
                textDesignation.Text = dataGridEmployee.Rows[rowIndex].Cells[2].Value.ToString();
                textContact.Text = dataGridEmployee.Rows[rowIndex].Cells[3].Value.ToString();
                textEmail.Text = dataGridEmployee.Rows[rowIndex].Cells[4].Value.ToString();
                imageName = dataGridEmployee.Rows[rowIndex].Cells[5].Value.ToString();
                textAddress.Text = dataGridEmployee.Rows[rowIndex].Cells[6].Value.ToString();
                textTIN.Text = dataGridEmployee.Rows[rowIndex].Cells[7].Value.ToString();
                textSSN.Text = dataGridEmployee.Rows[rowIndex].Cells[8].Value.ToString();
                textDescription.Text = dataGridEmployee.Rows[rowIndex].Cells[9].Value.ToString();
                textSalary.Text = dataGridEmployee.Rows[rowIndex].Cells[10].Value.ToString();

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
                }

                //enables the update and delete buttons
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

                //disables the save button
                btnSave.Enabled = false;
            }
            else
            {
                //displays this error message when more than one row is selected
                MessageBox.Show("Please Select One Row To Edit Or Delete a Record", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
 
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //vlidating the input 
            if (textFullName.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textFullName, "Full Name Cannot Be Empty");
                textFullName.Focus();

            }
            else if (textDesignation.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textDesignation, "Designation Cannot Be Empty");
                textDesignation.Focus();
            }
            else if (textContact.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textContact, "Contact Number Cannot Be Empty");
                textContact.Focus();
            }
            else if (textEmail.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textEmail, "Email Cannot Be Empty");
                textEmail.Focus();

            }
            else if (textAddress.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textAddress, "Address Cannot Be Empty");
                textAddress.Focus();
            }
            else if (textSalary.Text.Equals(string.Empty))
            {
                errorProvider1.SetError(textSalary, "Salary Cannot Be Empty");
                textSalary.Focus();
            }
            else
            {
                try
                {
                    //gets the logged in user who updated the record
                    //this will be inserted in the updated_by table field
                    string creator;
                    creator = frmLogin.loggedInUser;

                    //gets the values from the text boxes and pass it to the model
                    em.EmployeeID = Convert.ToInt32(textID.Text);
                    em.FullName = textFullName.Text.Trim();
                    em.Designation = textDesignation.Text.Trim();
                    em.Contact = textContact.Text.Trim();
                    em.Email = textEmail.Text.Trim();
                    em.Image = imageName;
                    em.Address = textAddress.Text;
                    em.TIN = textTIN.Text.Trim();
                    em.SSCN = textSSN.Text.Trim();
                    em.Description = textDescription.Text;
                    em.MonthlySalary = Math.Round(decimal.Parse(textSalary.Text),2);
                    em.Updated_By = creator;
                    em.Updated_Date = DateTime.Now;

                    decimal salary = decimal.Parse(textSalary.Text);

                    if (salary < 0)
                    {
                        MessageBox.Show("Salary Can Only Be A Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    else
                    {
                        //assigns the instance of the update method to a boolean variable
                        bool SuccessUpdate = ec.Update(em);

                        //checks if the record is updated or not
                        if (SuccessUpdate == true)
                        {
                            MessageBox.Show("Employee Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //clears the text boxes
                            clearText();

                            //loads the contents of the data grid view
                            DataTable dtbl = ec.Select();
                            dataGridEmployee.DataSource = dtbl;
                        }
                        else
                        {
                            MessageBox.Show("Could Not Update Employee", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                }
                catch (Exception)
                {

                }

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //disables the delete and update buttons
            btnDelete.Enabled = false;
            btnUpdate.Enabled = false;

            //enables the save button
            btnSave.Enabled = true;

            try
            {
                if (DialogResult.Yes == MessageBox.Show("Do You Want To Delete This Employee ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                {
                    //gets the Employee id from the text boxe and pass it to the model

                    em.EmployeeID = Convert.ToInt32(textID.Text);

                    //creates a variable of boolean data type to perform the delete functionality
                    bool SuccessDelete = ec.Delete(em);

                    //checks if the employee is deleted or not
                    if (SuccessDelete == true)
                    {
                        MessageBox.Show("Employee Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        //displays the employees in the data grid view
                        DataTable DisplayEmployees = ec.Select();

                        dataGridEmployee.DataSource = DisplayEmployees;

                        //clears the contents of the text boxes
                        clearText();
                    }
                    else
                    {
                        MessageBox.Show("Could Not Delete Employee", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    //removes the user profile image
                    if (imageName != "No-Image.png")
                    {
                        //full path to the image folder
                        string fullPath = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

                        //gets the path to the image location
                        string locationPath = fullPath + "\\images\\" + imageName;

                        //clears the contents of the text boxes
                       // clearText();

                        //calls the garbage collection function
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        //finally delete the donor profile image from storage
                        File.Delete(locationPath);
                    }

                    return;
                }
            }
            catch (Exception)
            {

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //clears the text boxes
            clearText();

            //loads the contents of the data grid view
            DataTable dtbl = ec.Select();
            dataGridEmployee.DataSource = dtbl;

            //disables the Update and delete Buttons
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;

            //enables the Save Buttton
            btnSave.Enabled = true;
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            //checks whether the user types any search text in the search text box or not

            string searchText = textSearch.Text;

            if (!textSearch.Text.Equals(string.Empty))
            {
                //loads the search result if the user searches for something
                DataTable dtbl = ec.Search(searchText);

                dataGridEmployee.DataSource = dtbl;
            }
            else
            {
                DataTable dtbl = ec.Select();
                dataGridEmployee.DataSource = dtbl;

            }

        }

        private void textSalary_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
