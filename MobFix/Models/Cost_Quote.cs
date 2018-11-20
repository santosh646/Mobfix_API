using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Cost_Quote
    {
        public int CostQuoteID { get; set; }
        public int IssuesTypeID { get; set; }
        public int MobileCompID { get; set; }
        public int MobileVersionTypeID { get; set; }
        //public int MobileOSID { get; set; }
        public int CustVendAdminID { get; set; }
        public Decimal ServiceQuote { get; set; }
        public DayOfWeek EstimatedtimeToResolve { get; set; } 
        public char CostQuoteIND { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
    }
}