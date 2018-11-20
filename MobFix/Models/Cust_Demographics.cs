using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Cust_Demographics


    {

        public int CustDemoID { get; set; }
        public int CustID { get; set; }
        public Char FirstName { get; set; }
        public Char LastName { get; set; }
        public Char FullName  { get; set; }
        public Char Gender { get; set; }
        public DateTime DOB { get; set; }


    }
}
