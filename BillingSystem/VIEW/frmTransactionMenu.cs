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
    public partial class frmTransactionMenu : Form
    {
        public frmTransactionMenu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPurchase Purchasefrm = new frmPurchase();
            Purchasefrm.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmSales Salesfrm = new frmSales();
            Salesfrm.ShowDialog();
        }
    }
}
