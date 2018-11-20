using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Order_Tracking
    { 
       public int OrderTrackingID {get; set;}
        public int OrderFKId { get; set; }
        public int ORDERSTATUSID { get; set; }
        public DateTime OrdertrackingDate { get; set; }
        public string Comment { get; set; }
        public DateTime CREATEDDATE { get; set; }
       public int CREATEDBY { get; set; }
       public DateTime LASTMODIFIEDDATE { get; set; }
       public int LASTMODIFIEDBY { get; set; }
       
     
  
    }
}