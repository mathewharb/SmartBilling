using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    class TransactionDetailModel
    {
        public int id { get; set; }
        public int product_id { get; set; }
        public decimal quantity { get; set; }
        public string unit { get; set; }
        public decimal price { get; set; }
        public decimal total { get; set; }
        public int stakeholder_id { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }

    }
}
