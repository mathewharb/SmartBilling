using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem.MODEL
{
    class EmployeeModel
    {
        //defines the getters and setters
        public int EmployeeID { get; set; }
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Address { get; set; }
        public string TIN { get; set; }
        public string SSCN { get; set; }
        public string Description { get; set; }
        public decimal MonthlySalary { get; set; }
        public string Created_By { get; set; }
        public DateTime Created_Date { get; set; }
        public string Updated_By { get; set; }
        public DateTime Updated_Date { get; set; }
    }
}
