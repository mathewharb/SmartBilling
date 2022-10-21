using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    class ProductModel
    {
        public int id { get; set; }
        public int category_id { get; set; }
        public int unit_id { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public string description { get; set; }
        public string unit { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }
        public string updated_by { get; set; }
        public DateTime updated_date { get; set; }

    }
}
