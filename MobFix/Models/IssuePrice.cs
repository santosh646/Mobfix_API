using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class IssuePrice
    {
        public int MobileIssuePriceID { get; set; }
        public int MobileVerTypeID { get; set; }
        public string MobileIssue { get; set; }
        public Decimal InitialQuote { get; set; }
        public Decimal EstimatedQuote { get; set; }
        public Decimal FinalCost { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }

    }
}