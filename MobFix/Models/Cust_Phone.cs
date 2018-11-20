using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Cust_Phone


    {

        public int CustPhoneID { get; set; }
        public int CustID { get; set; }
        public int ContactPhoneID { get; set; }
        public string ContactNumber { get; set; }
        public string ContactStatus { get; set; }
        public DateTime AddedDate { get; set; }
        public int AddByUserID { get; set; }
        public DateTime ChangedDate { get; set; }
        public int ChangedByID { get; set; }



    }
}
