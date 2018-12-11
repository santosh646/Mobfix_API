using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Vendor
    {
        public string Id;
        public string UserType;
        public string LoginId;
        public string Password;
        public int NoOfAttempts;
        public DateTime LastLoginDate;
        public string UserStatus;
        public DateTime CreatedDate;
        public string CrearedBy;
        public DateTime LastUpdateDate;
        public string LastUpdateBy;
        public int CustPhoneID;
        public int CustID;
        public int ContactPhoneID;
        public string ContactNumber;
        public string ContactStatus;
        public DateTime AddedDate;
        public int AddByUserID;
        public DateTime ChangedDate;
        public int ChangedByID;

    }
    public class GetVendorPassword
    {
        public string LoginId;
        public string Password;
    }
    public class GetVendorPassword
    {
        public string LoginId;
        public string Password;
    }
}