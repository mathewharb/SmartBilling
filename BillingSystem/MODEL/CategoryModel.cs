using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    class CategoryModel
    {
        //declaring the datatypes
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string  created_by { get; set; }
        public DateTime created_date { get; set; }      

    }
}
