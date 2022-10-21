using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    class StakeholderModel
    {
        //defining the getters and setters properties
        public int id { get; set; }
        public string type { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string tel { get; set; }
        public string address { get; set; }
        public string created_by { get; set; }
        public DateTime created_date { get; set; }

    }
}
