using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Configuration;

namespace MobFix.Repositories
{
    public class VendorRepository
    {
        MySqlHelper mySqlHelper = new MySqlHelper();

        public int InsertVendorRegistrationDetails(Vendor vendor)
        {
            string InsertVendorregistrationInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                $" VALUES({vendor.UserType}, '{vendor.LoginId}', '{vendor.Password}', {vendor.NoOfAttempts},  NOW(), '{vendor.UserStatus}', NOW(), {vendor.CrearedBy},NOW(), {vendor.LastUpdateBy});";

            InsertVendorregistrationInfo += $"INSERT INTO Mobifix_DB.CUST_PHONE(FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, CONTACT_NUMBER, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),{vendor.ContactPhoneID}, {vendor.ContactNumber} ,'{vendor.ContactStatus}', NOW(), {vendor.AddByUserID}, NOW(), {vendor.ChangedByID}";
            return mySqlHelper.ExecuteNonQuery(InsertVendorregistrationInfo);
        }


        public GetVendorPassword GetVendorPassword(GetVendorPassword getpassword)
        {
            //string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = { loginID.ToLower() } AND LOGIN_PWD = { pwd }";
            string fetchUser = $"SELECT LOGIN_PWD from USER_TBL  WHERE LOWER(LOGIN_ID) = '{getpassword.LoginId.ToLowerInvariant()}'  ";
            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var getvendorpassword = FillGetVendorPasswordModel(dtResult);
            return getvendorpassword.FirstOrDefault<GetVendorPassword>();
            
        }
        private IList<GetVendorPassword> FillGetVendorPasswordModel(DataTable dtUsers)
        {
            var userList = new List<GetVendorPassword>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new GetVendorPassword();

                    user.Password = Convert.ToString(row["LOGIN_PWD"]);
                    userList.Add(user);
                }
            }
            return userList;
        }
        public int InsertVendorDetails(Vendor vendor)
        {
            string InsertVendorInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                 $" VALUES({vendor.UserType}, '{vendor.LoginId}', '{vendor.Password}', {vendor.NoOfAttempts},  NOW(), '{vendor.UserStatus}', NOW(), {vendor.CrearedBy},NOW(), {vendor.LastUpdateBy});";

            InsertVendorInfo += $"INSERT INTO Mobifix_DB.CUST_PHONE(FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, CONTACT_NUMBER, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),{vendor.ContactPhoneID}, {vendor.ContactNumber} ,'{vendor.ContactStatus}', NOW(), {vendor.AddByUserID}, NOW(), {vendor.ChangedByID};";

            InsertVendorInfo += $"INSERT INTO Mobifix_DB.CUST_ADDRESS (FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, ADDR_LINE1, ADDR_LINE2, CITY, STATE, COUNTRY, ZIP_CODE, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(), {vendor.ContactAddrID}, '{vendor.AddressLine1}','{vendor.AddressLine2}', '{vendor.City}','{vendor.State}','{vendor.Country}', {vendor.ZIPCode}, '{vendor.ContactStatusCD}', NOW(), {vendor.ChangeByID}, NOW(), {vendor.AddByUserID}";
            return mySqlHelper.ExecuteNonQuery(InsertVendorInfo);

        }
    }

}