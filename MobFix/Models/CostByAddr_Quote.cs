using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class CostByAddr_Quote
    {
        public int CostByAddrQuoteID { get; set; }
        public int CustomertoVendorDistance { get; set; }
        public Decimal DistanceQuote { get; set; }
    }
}