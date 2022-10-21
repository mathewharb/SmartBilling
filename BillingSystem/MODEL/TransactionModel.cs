using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    class TransactionModel
    {
        public int id { get; set; }
        public int stakeholder_id { get; set; }
        public string stakeholder_name { get; set; }
        public string type { get; set; }
        public string transaction_date { get; set; }
        public decimal total { get; set; }
        public decimal tax { get; set; }
        public decimal discount { get; set; }
        public string created_by { get; set; }
        public string transaction_month { get; set; }
        public string transaction_year { get; set; }
        public string receipt_number { get; set; }
        public decimal paid_amount { get; set; }
        public decimal return_amount { get; set; }

        //FOR INSERTING THE TRANSACTION DETAILS
        public DataTable transactionDetails { get; set; }

    }
}
