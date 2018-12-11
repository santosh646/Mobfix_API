using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Cust_Info
    {
        public int CustInfoID { get; set; }
        public int CustVendorAdminID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string NamePrefix { get; set; }
        public string Gender { get; set; }
        public DayOfWeek DateOfBirth { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
    }
}