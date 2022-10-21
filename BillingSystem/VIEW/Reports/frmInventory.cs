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
    public partial class frmInventory : Form
    {
        public frmInventory()
        {
            InitializeComponent();
        }
        //products and categories controller instances
        CategoriesController cc = new CategoriesController();
        ProductsController pc = new ProductsController();

        private void LoadData()
        {
            //loads the contents of the table in to the datagrid 
            DataTable dt = pc.Select();
            dataGridInventory.DataSource = dt;

            //datagrid column settings: stretches the columns to fit the entire datagrid
            dataGridInventory.Columns[0].Width = 0;
            dataGridInventory.Columns[0].Visible=false;
            dataGridInventory.Columns[1].Width = 170;
            dataGridInventory.Columns[2].Width = 250;
            dataGridInventory.Columns[3].Width = 265;
            dataGridInventory.Columns[4].Width = 150;
            dataGridInventory.Columns[5].Width = 75;
            dataGridInventory.Columns[6].Width = 100;
            dataGridInventory.Columns[7].Width = 120;
            dataGridInventory.Columns[8].Width = 120;
            dataGridInventory.Columns[9].Width = 120;
           // dataGridInventory.Columns[10].Width = 120;
            dataGridInventory.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            //displays all the categories when the form loads
            DataTable cdtbl = cc.Select();

            comboSearch.DataSource = cdtbl;

            //indicates the display member and value member for the drop down
            comboSearch.DisplayMember = "name";
            comboSearch.ValueMember = "name";

            //shows all the products when the form loads
            LoadData();
        }

        private void comboSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //displays products from category selection
            string categorySelect = comboSearch.Text;

            DataTable dtbl = pc.ProductFromCategory(categorySelect);

            dataGridInventory.DataSource = dtbl;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            //shows all the products
            LoadData();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
