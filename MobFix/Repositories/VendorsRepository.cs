﻿using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class VendorsRepository
    {
        MySqlHelper mySqlHelper = new MySqlHelper();

        public int InsertVendorDetails(Vendors vendor)
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