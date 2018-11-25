using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class MobileOs
    {
        public int MobileOsID { get; set; }
        public int MobileVersionTypeID { get; set; }
        public int MobileCompanyID { get; set; }
        public string MobileOsDescription { get; set; }
        public int MobileOsTypeInd { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
    }

    
}
