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

namespace BillingSystem.VIEW.Reports
{
    public partial class frmProfitLoss : Form
    {
        public frmProfitLoss()
        {
            InitializeComponent();
        }

        TransactionsController tc = new TransactionsController();

        FinancialYearsController fyc = new FinancialYearsController();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void frmProfitLoss_Load(object sender, EventArgs e)
        {
            //displays the year in the combo box
            comboSelectYear.DataSource = fyc.Select();
            comboSelectYear.DisplayMember = "Year";
            comboSelectYear.ValueMember = "Year";
            comboSelectYear.Text = "";

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
            lblRevenueAmount.Text = SalesAmount.ToString();

            for (int i = 0; i < dtblTotalPurchase.Rows.Count; i++)
            {
                PurchaseAmount += Math.Round(Convert.ToDecimal(dtblTotalPurchase.Rows[i][0].ToString()), 2);
            }
            //displays the total purchases
            lblPurchaseAmount.Text = PurchaseAmount.ToString();

            decimal ProfitLoss = SalesAmount - PurchaseAmount;
            lblProfit.Text = ProfitLoss.ToString();

            if (ProfitLoss <0)
            {
                lblGrossProfitLoss.Text = "Gross Loss";
            }
            else
            {
                lblGrossProfitLoss.Text = "Gross Profit";
            }
        }

        private void comboSelectYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectYear = comboSelectYear.Text;
            if (comboSelectYear.Text !="")
            {
                //displays the total sales

                string salesText = "Sales";
               string purchaseText = "Purchase";

                string YearSelect = comboSelectYear.Text;

                DataTable dtblSelectYearSales = tc.YearlyProfitLoss(YearSelect,salesText);
                DataTable dtblSelectYearPurchase = tc.YearlyProfitLoss(YearSelect, purchaseText);

                decimal SalesAmount = 0;
                decimal PurchaseAmount = 0;
              
                for (int i = 0; i < dtblSelectYearSales.Rows.Count; i++)
                {
                    SalesAmount += Math.Round(Convert.ToDecimal(dtblSelectYearSales.Rows[i][0].ToString()), 2);
                }
                //displays the total sales
                lblRevenueAmount.Text = SalesAmount.ToString();

                for (int i = 0; i < dtblSelectYearPurchase.Rows.Count; i++)
                {
                    PurchaseAmount += Math.Round(Convert.ToDecimal(dtblSelectYearPurchase.Rows[i][0].ToString()), 2);
                }
                //displays the total purchases
                lblPurchaseAmount.Text = PurchaseAmount.ToString();

                decimal ProfitLoss = SalesAmount - PurchaseAmount;
                lblProfit.Text = ProfitLoss.ToString();

                if (ProfitLoss < 0)
                {
                    lblGrossProfitLoss.Text = "Gross Loss";
                }
                else
                {
                    lblGrossProfitLoss.Text = "Gross Profit";
                }
            }
            else
            {
                comboSelectYear.Text = "";

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
                lblRevenueAmount.Text = SalesAmount.ToString();

                for (int i = 0; i < dtblTotalPurchase.Rows.Count; i++)
                {
                    PurchaseAmount += Math.Round(Convert.ToDecimal(dtblTotalPurchase.Rows[i][0].ToString()), 2);
                }
                //displays the total purchases
                lblPurchaseAmount.Text = PurchaseAmount.ToString();

                decimal ProfitLoss = SalesAmount - PurchaseAmount;
                lblProfit.Text = ProfitLoss.ToString();

                if (ProfitLoss < 0)
                {
                    lblGrossProfitLoss.Text = "Gross Loss";
                }
                else
                {
                    lblGrossProfitLoss.Text = "Gross Profit";
                }
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            frmProfitLoss pnl = new frmProfitLoss();
            pnl.ShowDialog();
        }
    }
   
}
