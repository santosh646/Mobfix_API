using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public int OrderID { get; set; }
        public string Orderstatus { get; set; }
        public string OderStausInd { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
    }
    public class OrderStatus1
    {
        
        public int OrderID { get; set; }
        public DateTime OrderDate { set; get; }

        public string OrderstatusDesc { get; set; }
        public DateTime ExpectedDate { get; set; }
        
    }

}