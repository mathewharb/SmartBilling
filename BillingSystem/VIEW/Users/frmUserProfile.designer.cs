namespace NGOManagementSystem.Views.Users
{
    partial class frmUserProfile
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserProfile));
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageProfileDetails = new System.Windows.Forms.TabPage();
            this.textEmployeeID = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textID = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textSalary = new System.Windows.Forms.TextBox();
            this.textContact = new System.Windows.Forms.TextBox();
            this.textEmail = new System.Windows.Forms.TextBox();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textDescription = new System.Windows.Forms.TextBox();
            this.textDesignation = new System.Windows.Forms.TextBox();
            this.textFullName = new System.Windows.Forms.TextBox();
            this.textSSN = new System.Windows.Forms.TextBox();
            this.textTIN = new System.Windows.Forms.TextBox();
            this.lblSalary = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblSSN = new System.Windows.Forms.Label();
            this.lblTIN = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBoxProfileImage = new System.Windows.Forms.GroupBox();
            this.tabPageEditProfile = new System.Windows.Forms.TabPage();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.textProfileAddress = new System.Windows.Forms.TextBox();
            this.textProfileDescription = new System.Windows.Forms.TextBox();
            this.textProfileSalary = new System.Windows.Forms.TextBox();
            this.textProfileTIN = new System.Windows.Forms.TextBox();
            this.textProfileContact = new System.Windows.Forms.TextBox();
            this.textProfileFullName = new System.Windows.Forms.TextBox();
            this.textProfileSSN = new System.Windows.Forms.TextBox();
            this.textProfileEmail = new System.Windows.Forms.TextBox();
            this.textProfileDesignation = new System.Windows.Forms.TextBox();
            this.lblDescription2 = new System.Windows.Forms.Label();
            this.lblSalary2 = new System.Windows.Forms.Label();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.lblTIN2 = new System.Windows.Forms.Label();
            this.lblContact2 = new System.Windows.Forms.Label();
            this.lblFullName2 = new System.Windows.Forms.Label();
            this.lblSSN2 = new System.Windows.Forms.Label();
            this.lblEmail2 = new System.Windows.Forms.Label();
            this.lblDesignation2 = new System.Windows.Forms.Label();
            this.groupBoxProfileImage2 = new System.Windows.Forms.GroupBox();
            this.btnProfile = new System.Windows.Forms.Button();
            this.pictureBoxProfile = new System.Windows.Forms.PictureBox();
            this.pictureBoxProfile2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageProfileDetails.SuspendLayout();
            this.groupBoxProfileImage.SuspendLayout();
            this.tabPageEditProfile.SuspendLayout();
            this.groupBoxProfileImage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSlateGray;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(329, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "USER PROFILE";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 37);
            this.panel2.TabIndex = 28;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 13);
            this.panel1.TabIndex = 29;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageProfileDetails);
            this.tabControl1.Controls.Add(this.tabPageEditProfile);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 50);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(12, 6);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(759, 576);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPageProfileDetails
            // 
            this.tabPageProfileDetails.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageProfileDetails.Controls.Add(this.textEmployeeID);
            this.tabPageProfileDetails.Controls.Add(this.textUsername);
            this.tabPageProfileDetails.Controls.Add(this.textBox17);
            this.tabPageProfileDetails.Controls.Add(this.textID);
            this.tabPageProfileDetails.Controls.Add(this.panel3);
            this.tabPageProfileDetails.Controls.Add(this.textSalary);
            this.tabPageProfileDetails.Controls.Add(this.textContact);
            this.tabPageProfileDetails.Controls.Add(this.textEmail);
            this.tabPageProfileDetails.Controls.Add(this.textAddress);
            this.tabPageProfileDetails.Controls.Add(this.textDescription);
            this.tabPageProfileDetails.Controls.Add(this.textDesignation);
            this.tabPageProfileDetails.Controls.Add(this.textFullName);
            this.tabPageProfileDetails.Controls.Add(this.textSSN);
            this.tabPageProfileDetails.Controls.Add(this.textTIN);
            this.tabPageProfileDetails.Controls.Add(this.lblSalary);
            this.tabPageProfileDetails.Controls.Add(this.lblDescription);
            this.tabPageProfileDetails.Controls.Add(this.lblSSN);
            this.tabPageProfileDetails.Controls.Add(this.lblTIN);
            this.tabPageProfileDetails.Controls.Add(this.lblAddress);
            this.tabPageProfileDetails.Controls.Add(this.label5);
            this.tabPageProfileDetails.Controls.Add(this.label3);
            this.tabPageProfileDetails.Controls.Add(this.groupBoxProfileImage);
            this.tabPageProfileDetails.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageProfileDetails.Location = new System.Drawing.Point(4, 31);
            this.tabPageProfileDetails.Name = "tabPageProfileDetails";
            this.tabPageProfileDetails.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfileDetails.Size = new System.Drawing.Size(751, 541);
            this.tabPageProfileDetails.TabIndex = 0;
            this.tabPageProfileDetails.Text = "Details";
            this.tabPageProfileDetails.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // textEmployeeID
            // 
            this.textEmployeeID.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textEmployeeID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEmployeeID.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textEmployeeID.Location = new System.Drawing.Point(170, 39);
            this.textEmployeeID.Name = "textEmployeeID";
            this.textEmployeeID.ReadOnly = true;
            this.textEmployeeID.Size = new System.Drawing.Size(110, 22);
            this.textEmployeeID.TabIndex = 58;
            this.textEmployeeID.TabStop = false;
            this.textEmployeeID.Visible = false;
            this.textEmployeeID.TextChanged += new System.EventHandler(this.textEmployeeID_TextChanged);
            // 
            // textUsername
            // 
            this.textUsername.BackColor = System.Drawing.SystemColors.ControlLight;
            this.textUsername.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textUsername.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textUsername.Location = new System.Drawing.Point(19, 163);
            this.textUsername.Name = "textUsername";
            this.textUsername.ReadOnly = true;
            this.textUsername.Size = new System.Drawing.Size(145, 22);
            this.textUsername.TabIndex = 58;
            this.textUsername.TabStop = false;
            this.textUsername.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textUsername.Visible = false;
            // 
            // textBox17
            // 
            this.textBox17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.Location = new System.Drawing.Point(324, -109);
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(135, 22);
            this.textBox17.TabIndex = 57;
            this.textBox17.Visible = false;
            // 
            // textID
            // 
            this.textID.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textID.Location = new System.Drawing.Point(170, 15);
            this.textID.Name = "textID";
            this.textID.ReadOnly = true;
            this.textID.Size = new System.Drawing.Size(110, 22);
            this.textID.TabIndex = 57;
            this.textID.TabStop = false;
            this.textID.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Silver;
            this.panel3.Location = new System.Drawing.Point(3, 266);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(752, 4);
            this.panel3.TabIndex = 56;
            // 
            // textSalary
            // 
            this.textSalary.BackColor = System.Drawing.Color.Gainsboro;
            this.textSalary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSalary.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textSalary.Location = new System.Drawing.Point(241, 500);
            this.textSalary.Name = "textSalary";
            this.textSalary.ReadOnly = true;
            this.textSalary.Size = new System.Drawing.Size(243, 25);
            this.textSalary.TabIndex = 9;
            this.textSalary.TabStop = false;
            this.textSalary.Text = "25000";
            this.textSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textContact
            // 
            this.textContact.BackColor = System.Drawing.Color.Gainsboro;
            this.textContact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textContact.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textContact.Location = new System.Drawing.Point(487, 16);
            this.textContact.Multiline = true;
            this.textContact.Name = "textContact";
            this.textContact.ReadOnly = true;
            this.textContact.Size = new System.Drawing.Size(264, 37);
            this.textContact.TabIndex = 1;
            this.textContact.TabStop = false;
            this.textContact.Text = "7425159";
            this.textContact.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textEmail
            // 
            this.textEmail.BackColor = System.Drawing.Color.Gainsboro;
            this.textEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textEmail.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textEmail.Location = new System.Drawing.Point(487, 53);
            this.textEmail.Multiline = true;
            this.textEmail.Name = "textEmail";
            this.textEmail.ReadOnly = true;
            this.textEmail.Size = new System.Drawing.Size(264, 47);
            this.textEmail.TabIndex = 2;
            this.textEmail.TabStop = false;
            this.textEmail.Text = "test@test.com";
            this.textEmail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textAddress
            // 
            this.textAddress.BackColor = System.Drawing.Color.Gainsboro;
            this.textAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textAddress.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textAddress.Location = new System.Drawing.Point(487, 99);
            this.textAddress.Multiline = true;
            this.textAddress.Name = "textAddress";
            this.textAddress.ReadOnly = true;
            this.textAddress.Size = new System.Drawing.Size(264, 64);
            this.textAddress.TabIndex = 3;
            this.textAddress.TabStop = false;
            this.textAddress.Text = "123699 block";
            this.textAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textDescription
            // 
            this.textDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.textDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDescription.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textDescription.Location = new System.Drawing.Point(53, 367);
            this.textDescription.Multiline = true;
            this.textDescription.Name = "textDescription";
            this.textDescription.ReadOnly = true;
            this.textDescription.Size = new System.Drawing.Size(642, 97);
            this.textDescription.TabIndex = 8;
            this.textDescription.TabStop = false;
            this.textDescription.Text = resources.GetString("textDescription.Text");
            // 
            // textDesignation
            // 
            this.textDesignation.BackColor = System.Drawing.Color.Gainsboro;
            this.textDesignation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textDesignation.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textDesignation.Location = new System.Drawing.Point(0, 212);
            this.textDesignation.Name = "textDesignation";
            this.textDesignation.ReadOnly = true;
            this.textDesignation.Size = new System.Drawing.Size(751, 25);
            this.textDesignation.TabIndex = 5;
            this.textDesignation.TabStop = false;
            this.textDesignation.Text = "Board Member";
            this.textDesignation.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textFullName
            // 
            this.textFullName.BackColor = System.Drawing.Color.Gainsboro;
            this.textFullName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textFullName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.textFullName.Location = new System.Drawing.Point(0, 183);
            this.textFullName.Name = "textFullName";
            this.textFullName.ReadOnly = true;
            this.textFullName.Size = new System.Drawing.Size(751, 33);
            this.textFullName.TabIndex = 4;
            this.textFullName.TabStop = false;
            this.textFullName.Text = "MATHEW HARB";
            this.textFullName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textSSN
            // 
            this.textSSN.BackColor = System.Drawing.Color.Gainsboro;
            this.textSSN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSSN.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textSSN.Location = new System.Drawing.Point(405, 299);
            this.textSSN.Name = "textSSN";
            this.textSSN.ReadOnly = true;
            this.textSSN.Size = new System.Drawing.Size(290, 25);
            this.textSSN.TabIndex = 7;
            this.textSSN.TabStop = false;
            this.textSSN.Text = "2698lport258";
            this.textSSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textTIN
            // 
            this.textTIN.BackColor = System.Drawing.Color.Gainsboro;
            this.textTIN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTIN.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.textTIN.Location = new System.Drawing.Point(82, 299);
            this.textTIN.Name = "textTIN";
            this.textTIN.ReadOnly = true;
            this.textTIN.Size = new System.Drawing.Size(263, 25);
            this.textTIN.TabIndex = 6;
            this.textTIN.TabStop = false;
            this.textTIN.Text = "0123456987725";
            this.textTIN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSalary
            // 
            this.lblSalary.AutoSize = true;
            this.lblSalary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSalary.Location = new System.Drawing.Point(339, 480);
            this.lblSalary.Name = "lblSalary";
            this.lblSalary.Size = new System.Drawing.Size(46, 17);
            this.lblSalary.TabIndex = 51;
            this.lblSalary.Text = "Salary";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDescription.Location = new System.Drawing.Point(339, 347);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 17);
            this.lblDescription.TabIndex = 52;
            this.lblDescription.Text = "Description";
            // 
            // lblSSN
            // 
            this.lblSSN.AutoSize = true;
            this.lblSSN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSN.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSSN.Location = new System.Drawing.Point(371, 302);
            this.lblSSN.Name = "lblSSN";
            this.lblSSN.Size = new System.Drawing.Size(32, 17);
            this.lblSSN.TabIndex = 53;
            this.lblSSN.Text = "SSN";
            // 
            // lblTIN
            // 
            this.lblTIN.AutoSize = true;
            this.lblTIN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIN.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTIN.Location = new System.Drawing.Point(50, 302);
            this.lblTIN.Name = "lblTIN";
            this.lblTIN.Size = new System.Drawing.Size(30, 17);
            this.lblTIN.TabIndex = 54;
            this.lblTIN.Text = "TIN";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblAddress.Location = new System.Drawing.Point(410, 102);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(57, 17);
            this.lblAddress.TabIndex = 46;
            this.lblAddress.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Location = new System.Drawing.Point(410, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 47;
            this.label5.Text = "EMail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(410, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 48;
            this.label3.Text = "Contact No.";
            // 
            // groupBoxProfileImage
            // 
            this.groupBoxProfileImage.BackColor = System.Drawing.Color.LavenderBlush;
            this.groupBoxProfileImage.Controls.Add(this.pictureBoxProfile);
            this.groupBoxProfileImage.Location = new System.Drawing.Point(19, 16);
            this.groupBoxProfileImage.Name = "groupBoxProfileImage";
            this.groupBoxProfileImage.Size = new System.Drawing.Size(145, 147);
            this.groupBoxProfileImage.TabIndex = 44;
            this.groupBoxProfileImage.TabStop = false;
            // 
            // tabPageEditProfile
            // 
            this.tabPageEditProfile.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageEditProfile.Controls.Add(this.btnCancel);
            this.tabPageEditProfile.Controls.Add(this.btnUpdate);
            this.tabPageEditProfile.Controls.Add(this.textProfileAddress);
            this.tabPageEditProfile.Controls.Add(this.textProfileDescription);
            this.tabPageEditProfile.Controls.Add(this.textProfileSalary);
            this.tabPageEditProfile.Controls.Add(this.textProfileTIN);
            this.tabPageEditProfile.Controls.Add(this.textProfileContact);
            this.tabPageEditProfile.Controls.Add(this.textProfileFullName);
            this.tabPageEditProfile.Controls.Add(this.textProfileSSN);
            this.tabPageEditProfile.Controls.Add(this.textProfileEmail);
            this.tabPageEditProfile.Controls.Add(this.textProfileDesignation);
            this.tabPageEditProfile.Controls.Add(this.lblDescription2);
            this.tabPageEditProfile.Controls.Add(this.lblSalary2);
            this.tabPageEditProfile.Controls.Add(this.lblAddress2);
            this.tabPageEditProfile.Controls.Add(this.lblTIN2);
            this.tabPageEditProfile.Controls.Add(this.lblContact2);
            this.tabPageEditProfile.Controls.Add(this.lblFullName2);
            this.tabPageEditProfile.Controls.Add(this.lblSSN2);
            this.tabPageEditProfile.Controls.Add(this.lblEmail2);
            this.tabPageEditProfile.Controls.Add(this.lblDesignation2);
            this.tabPageEditProfile.Controls.Add(this.groupBoxProfileImage2);
            this.tabPageEditProfile.Controls.Add(this.btnProfile);
            this.tabPageEditProfile.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.tabPageEditProfile.Location = new System.Drawing.Point(4, 31);
            this.tabPageEditProfile.Name = "tabPageEditProfile";
            this.tabPageEditProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEditProfile.Size = new System.Drawing.Size(751, 541);
            this.tabPageEditProfile.TabIndex = 1;
            this.tabPageEditProfile.Text = "Edit Profile";
            this.tabPageEditProfile.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnCancel.Location = new System.Drawing.Point(11, 481);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(723, 43);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "View Profile";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.MintCream;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Green;
            this.btnUpdate.Location = new System.Drawing.Point(11, 420);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(723, 48);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update Profile";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // textProfileAddress
            // 
            this.textProfileAddress.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileAddress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileAddress.ForeColor = System.Drawing.Color.Black;
            this.textProfileAddress.Location = new System.Drawing.Point(479, 166);
            this.textProfileAddress.Multiline = true;
            this.textProfileAddress.Name = "textProfileAddress";
            this.textProfileAddress.Size = new System.Drawing.Size(258, 83);
            this.textProfileAddress.TabIndex = 5;
            this.textProfileAddress.Text = "123hy hyy";
            // 
            // textProfileDescription
            // 
            this.textProfileDescription.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileDescription.ForeColor = System.Drawing.Color.Black;
            this.textProfileDescription.Location = new System.Drawing.Point(11, 305);
            this.textProfileDescription.Multiline = true;
            this.textProfileDescription.Name = "textProfileDescription";
            this.textProfileDescription.Size = new System.Drawing.Size(723, 98);
            this.textProfileDescription.TabIndex = 8;
            this.textProfileDescription.TabStop = false;
            this.textProfileDescription.Text = resources.GetString("textProfileDescription.Text");
            // 
            // textProfileSalary
            // 
            this.textProfileSalary.BackColor = System.Drawing.Color.Gainsboro;
            this.textProfileSalary.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileSalary.ForeColor = System.Drawing.Color.DimGray;
            this.textProfileSalary.Location = new System.Drawing.Point(287, 224);
            this.textProfileSalary.Name = "textProfileSalary";
            this.textProfileSalary.ReadOnly = true;
            this.textProfileSalary.Size = new System.Drawing.Size(176, 25);
            this.textProfileSalary.TabIndex = 57;
            this.textProfileSalary.TabStop = false;
            this.textProfileSalary.Text = "25000";
            this.textProfileSalary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textProfileTIN
            // 
            this.textProfileTIN.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileTIN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileTIN.ForeColor = System.Drawing.Color.Black;
            this.textProfileTIN.Location = new System.Drawing.Point(11, 170);
            this.textProfileTIN.Name = "textProfileTIN";
            this.textProfileTIN.Size = new System.Drawing.Size(258, 25);
            this.textProfileTIN.TabIndex = 6;
            this.textProfileTIN.Text = "0123456987725";
            // 
            // textProfileContact
            // 
            this.textProfileContact.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileContact.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileContact.ForeColor = System.Drawing.Color.Black;
            this.textProfileContact.Location = new System.Drawing.Point(11, 107);
            this.textProfileContact.Name = "textProfileContact";
            this.textProfileContact.Size = new System.Drawing.Size(258, 25);
            this.textProfileContact.TabIndex = 3;
            this.textProfileContact.Text = "0123456987725";
            // 
            // textProfileFullName
            // 
            this.textProfileFullName.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileFullName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileFullName.ForeColor = System.Drawing.Color.Black;
            this.textProfileFullName.Location = new System.Drawing.Point(11, 39);
            this.textProfileFullName.Name = "textProfileFullName";
            this.textProfileFullName.Size = new System.Drawing.Size(258, 25);
            this.textProfileFullName.TabIndex = 1;
            this.textProfileFullName.Text = "0123456987725";
            // 
            // textProfileSSN
            // 
            this.textProfileSSN.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileSSN.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileSSN.ForeColor = System.Drawing.Color.Black;
            this.textProfileSSN.Location = new System.Drawing.Point(11, 224);
            this.textProfileSSN.Name = "textProfileSSN";
            this.textProfileSSN.Size = new System.Drawing.Size(257, 25);
            this.textProfileSSN.TabIndex = 7;
            this.textProfileSSN.Text = "0123456987725";
            // 
            // textProfileEmail
            // 
            this.textProfileEmail.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileEmail.ForeColor = System.Drawing.Color.Black;
            this.textProfileEmail.Location = new System.Drawing.Point(479, 107);
            this.textProfileEmail.Name = "textProfileEmail";
            this.textProfileEmail.Size = new System.Drawing.Size(258, 25);
            this.textProfileEmail.TabIndex = 4;
            this.textProfileEmail.Text = "0123456987725";
            // 
            // textProfileDesignation
            // 
            this.textProfileDesignation.BackColor = System.Drawing.SystemColors.Window;
            this.textProfileDesignation.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textProfileDesignation.ForeColor = System.Drawing.Color.Black;
            this.textProfileDesignation.Location = new System.Drawing.Point(479, 39);
            this.textProfileDesignation.Name = "textProfileDesignation";
            this.textProfileDesignation.Size = new System.Drawing.Size(258, 25);
            this.textProfileDesignation.TabIndex = 2;
            this.textProfileDesignation.Text = "0123456987725";
            // 
            // lblDescription2
            // 
            this.lblDescription2.AutoSize = true;
            this.lblDescription2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDescription2.Location = new System.Drawing.Point(326, 285);
            this.lblDescription2.Name = "lblDescription2";
            this.lblDescription2.Size = new System.Drawing.Size(79, 17);
            this.lblDescription2.TabIndex = 56;
            this.lblDescription2.Text = "Description";
            this.lblDescription2.Click += new System.EventHandler(this.label16_Click);
            // 
            // lblSalary2
            // 
            this.lblSalary2.AutoSize = true;
            this.lblSalary2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalary2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSalary2.Location = new System.Drawing.Point(349, 204);
            this.lblSalary2.Name = "lblSalary2";
            this.lblSalary2.Size = new System.Drawing.Size(46, 17);
            this.lblSalary2.TabIndex = 56;
            this.lblSalary2.Text = "Salary";
            this.lblSalary2.Click += new System.EventHandler(this.label13_Click);
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblAddress2.Location = new System.Drawing.Point(476, 146);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(57, 17);
            this.lblAddress2.TabIndex = 56;
            this.lblAddress2.Text = "Address";
            // 
            // lblTIN2
            // 
            this.lblTIN2.AutoSize = true;
            this.lblTIN2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTIN2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblTIN2.Location = new System.Drawing.Point(8, 146);
            this.lblTIN2.Name = "lblTIN2";
            this.lblTIN2.Size = new System.Drawing.Size(30, 17);
            this.lblTIN2.TabIndex = 56;
            this.lblTIN2.Text = "TIN";
            this.lblTIN2.Click += new System.EventHandler(this.label13_Click);
            // 
            // lblContact2
            // 
            this.lblContact2.AutoSize = true;
            this.lblContact2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblContact2.Location = new System.Drawing.Point(8, 83);
            this.lblContact2.Name = "lblContact2";
            this.lblContact2.Size = new System.Drawing.Size(81, 17);
            this.lblContact2.TabIndex = 56;
            this.lblContact2.Text = "Contact No.";
            // 
            // lblFullName2
            // 
            this.lblFullName2.AutoSize = true;
            this.lblFullName2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblFullName2.Location = new System.Drawing.Point(8, 15);
            this.lblFullName2.Name = "lblFullName2";
            this.lblFullName2.Size = new System.Drawing.Size(71, 17);
            this.lblFullName2.TabIndex = 56;
            this.lblFullName2.Text = "Full Name";
            // 
            // lblSSN2
            // 
            this.lblSSN2.AutoSize = true;
            this.lblSSN2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSSN2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblSSN2.Location = new System.Drawing.Point(8, 204);
            this.lblSSN2.Name = "lblSSN2";
            this.lblSSN2.Size = new System.Drawing.Size(32, 17);
            this.lblSSN2.TabIndex = 56;
            this.lblSSN2.Text = "SSN";
            // 
            // lblEmail2
            // 
            this.lblEmail2.AutoSize = true;
            this.lblEmail2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblEmail2.Location = new System.Drawing.Point(476, 83);
            this.lblEmail2.Name = "lblEmail2";
            this.lblEmail2.Size = new System.Drawing.Size(42, 17);
            this.lblEmail2.TabIndex = 56;
            this.lblEmail2.Text = "EMail";
            // 
            // lblDesignation2
            // 
            this.lblDesignation2.AutoSize = true;
            this.lblDesignation2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDesignation2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblDesignation2.Location = new System.Drawing.Point(476, 15);
            this.lblDesignation2.Name = "lblDesignation2";
            this.lblDesignation2.Size = new System.Drawing.Size(83, 17);
            this.lblDesignation2.TabIndex = 56;
            this.lblDesignation2.Text = "Designation";
            // 
            // groupBoxProfileImage2
            // 
            this.groupBoxProfileImage2.BackColor = System.Drawing.Color.LavenderBlush;
            this.groupBoxProfileImage2.Controls.Add(this.pictureBoxProfile2);
            this.groupBoxProfileImage2.Location = new System.Drawing.Point(287, 15);
            this.groupBoxProfileImage2.Name = "groupBoxProfileImage2";
            this.groupBoxProfileImage2.Size = new System.Drawing.Size(176, 139);
            this.groupBoxProfileImage2.TabIndex = 44;
            this.groupBoxProfileImage2.TabStop = false;
            // 
            // btnProfile
            // 
            this.btnProfile.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.SystemColors.GrayText;
            this.btnProfile.Location = new System.Drawing.Point(287, 156);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Size = new System.Drawing.Size(176, 39);
            this.btnProfile.TabIndex = 9;
            this.btnProfile.Text = "Change Picture";
            this.btnProfile.UseVisualStyleBackColor = true;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // pictureBoxProfile
            // 
            this.pictureBoxProfile.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxProfile.Image = global::BillingSystem.Properties.Resources.defualt;
            this.pictureBoxProfile.Location = new System.Drawing.Point(5, 4);
            this.pictureBoxProfile.Name = "pictureBoxProfile";
            this.pictureBoxProfile.Size = new System.Drawing.Size(135, 137);
            this.pictureBoxProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile.TabIndex = 5;
            this.pictureBoxProfile.TabStop = false;
            // 
            // pictureBoxProfile2
            // 
            this.pictureBoxProfile2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pictureBoxProfile2.Image = global::BillingSystem.Properties.Resources.defualt;
            this.pictureBoxProfile2.Location = new System.Drawing.Point(5, 4);
            this.pictureBoxProfile2.Name = "pictureBoxProfile2";
            this.pictureBoxProfile2.Size = new System.Drawing.Size(166, 129);
            this.pictureBoxProfile2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxProfile2.TabIndex = 5;
            this.pictureBoxProfile2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BillingSystem.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(728, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(23, 22);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(1194, 6);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 22);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // frmUserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(759, 626);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUserProfile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmUserProfile";
            this.Activated += new System.EventHandler(this.frmUserProfile_Activated);
            this.Load += new System.EventHandler(this.frmUserProfile_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPageProfileDetails.ResumeLayout(false);
            this.tabPageProfileDetails.PerformLayout();
            this.groupBoxProfileImage.ResumeLayout(false);
            this.tabPageEditProfile.ResumeLayout(false);
            this.tabPageEditProfile.PerformLayout();
            this.groupBoxProfileImage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxProfile2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageProfileDetails;
        private System.Windows.Forms.TabPage tabPageEditProfile;
        private System.Windows.Forms.GroupBox groupBoxProfileImage;
        private System.Windows.Forms.PictureBox pictureBoxProfile;
        private System.Windows.Forms.GroupBox groupBoxProfileImage2;
        private System.Windows.Forms.PictureBox pictureBoxProfile2;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblSSN;
        private System.Windows.Forms.Label lblTIN;
        private System.Windows.Forms.Label lblSalary;
        private System.Windows.Forms.TextBox textSSN;
        private System.Windows.Forms.TextBox textTIN;
        private System.Windows.Forms.TextBox textSalary;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textDescription;
        private System.Windows.Forms.TextBox textFullName;
        private System.Windows.Forms.TextBox textDesignation;
        private System.Windows.Forms.TextBox textEmail;
        private System.Windows.Forms.TextBox textContact;
        private System.Windows.Forms.TextBox textProfileFullName;
        private System.Windows.Forms.TextBox textProfileDesignation;
        private System.Windows.Forms.Label lblFullName2;
        private System.Windows.Forms.Label lblDesignation2;
        private System.Windows.Forms.TextBox textProfileContact;
        private System.Windows.Forms.TextBox textProfileEmail;
        private System.Windows.Forms.Label lblContact2;
        private System.Windows.Forms.Label lblEmail2;
        private System.Windows.Forms.TextBox textProfileTIN;
        private System.Windows.Forms.TextBox textProfileSSN;
        private System.Windows.Forms.Label lblTIN2;
        private System.Windows.Forms.Label lblSSN2;
        private System.Windows.Forms.TextBox textProfileDescription;
        private System.Windows.Forms.Label lblAddress2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox textID;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textEmployeeID;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.TextBox textProfileAddress;
        private System.Windows.Forms.Label lblDescription2;
        private System.Windows.Forms.TextBox textProfileSalary;
        private System.Windows.Forms.Label lblSalary2;
    }
}