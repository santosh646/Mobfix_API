using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Cust_Addr


    {

        public int CustAddrID { get; set; }
        public int CustID { get; set; }
        public int ContactAddrID { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZIPCode { get; set; }
       // public int PostalCode { get; set; }
        public string ContactStatusCD { get; set; }
        public DateTime ChangedDate { get; set; }
        public int ChangedByID { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddByUserID { get; set; }



    }
}
