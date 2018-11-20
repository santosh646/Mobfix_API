using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class MobileTypes


    {

        public int MobileCompanyID { get; set; }
        public string MobileCompany { get; set; }
        public string MobileTypeInd { get; set; }
        public DateTime CreatedDate { get; set;}
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
    }
}
