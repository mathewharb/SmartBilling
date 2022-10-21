using BillingSystem.CONTROLLER;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BillingSystem.VIEW
{
    public partial class frmTransactionsReport : Form
    {
        public frmTransactionsReport()
        {
            InitializeComponent();
        }

        //transactions controller instance
        TransactionsController tc = new TransactionsController();


        private void LoadData()
        {
            //loads the contents of the table in to the datagrid 
            DataTable dtbl = tc.AllTransactions();
            dataGridTransactionsReport.DataSource = dtbl;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridTransactionsReport.Columns[0].Width = 100;
            dataGridTransactionsReport.Columns[1].Width = 300;
            dataGridTransactionsReport.Columns[2].Width = 120;
            dataGridTransactionsReport.Columns[3].Width = 210;
            dataGridTransactionsReport.Columns[4].Width = 150;
            dataGridTransactionsReport.Columns[5].Width = 100;
            dataGridTransactionsReport.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //gets the value from selection
            string selectedType = comboSearch.Text;

            DataTable dtbl = tc.TransactionFromType(selectedType);
            dataGridTransactionsReport.DataSource = dtbl;
        }

        private void labelSearch_Click(object sender, EventArgs e)
        {

        }

        private void frmTransactionsReport_Load(object sender, EventArgs e)
        {
            //displays all the transactions when the form loads
            LoadData();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //shows ll the transactions
            LoadData();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
