using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class IssueType
    {
        public int IssueTypeID { get; set; }
        public string IssuesTypeDescription {get; set;}
        public string IssuesTypeInd { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int LastModifiedBy { get; set; }
    }
}