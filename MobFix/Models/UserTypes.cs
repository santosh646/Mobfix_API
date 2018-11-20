using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class UserTypes
    {
        public int UserTypeID { get; set; }
        public string UserRole  { get; set; }
        public int MaxLoginattempts  { get; set; }

    }
}