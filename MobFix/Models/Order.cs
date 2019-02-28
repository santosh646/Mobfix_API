using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Models
{
    public class Order
    {
        public int OrderID;
        public DateTime OrderPlacedDate;
        public string OrderstatusDesc;
        public Decimal FinalCost;
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

        public int CustVendorAdminID;
        public int AssignedtoVendorID;
        public int IssuesTypeID;
        public string IssueDetails;
        public string IEMI;
        public int MobileCompID;
        public int MobileVersionTypeID;
        public int MobileOSID;
        public int CustDemoID;
        public int ContactAddrID;
        public int ContactPhoneID;
        public Decimal InitialQuote;
        public Decimal EstimatedQuote;
        public DateTime EstimatedTimetoDeliver;

        public int orderstatusID;
        public string orderstatusdescription;
        public string orderstatusIND;
        public DateTime createdDate;
        public int createdBy;
       public DateTime lastmodifiedDate;
        public int lastmodifiedBy;
        public string orderID;
        public int custvendadminID;

        public int mobileCompanyID;
        public string mobileCompanyDesc;
        public string mobileTypeIND;
        public DateTime Date;
        public int By;
        public DateTime dDate;
        public int dBy;

         public int mobileversionTypeID;
        public string mobileversionDesc;
        public string mobileversionTypeIND;
        public DateTime mobDate;
        public int mobBy;
        public DateTime mobbDate;
        public int mobbBy;
        public int MobileCompanyID;


    }
    public class getAllorders
    {

        public int customeradminid;
        public int OrderID;
        public DateTime OrderPlacedDate;
        public string OrderstatusDesc;
        public string LoginId;
        public string IssueDetails;
        public string mobileCompany;
        public string mobileversion;
        public Decimal FinalCost;
    }

    public class getorder
    {
        public string Id;
        public int OrderID;
        public int CustVendorAdminID;
        public int AssignedtoVendorID;
        public int IssuesTypeID;
        public string IssueDetails;
        public string IEMI;
        public int MobileCompID;
        public int MobileVersionTypeID;
        public Decimal InitialQuote;
        public Decimal EstimatedQuote;
        public Decimal FinalCost;
        public DateTime OrderPlacedDate;
        public DateTime EstimatedTimetoDeliver;

    }
    public class Order1
    {
        public int CustVendorAdminID;
        public int OrderID;
        public DateTime OrderPlacedDate;
        public string OrderstatusDesc;
        public string IssueDetails;
        public string mobileCompany;
        public string mobileversion;
        public Decimal FinalCost;
        public string LoginId;
    }
    public class userOrder
    {
        public int OrderID;
        
        public string IssueDetails;
        public string mobileCompany;
        public string mobileversion;
        public Decimal FinalCost;
        public string LoginId;
    }
}
