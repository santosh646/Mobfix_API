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
    public class UserRepository
    {
        MySqlHelper mySqlHelper = new MySqlHelper();
       
        public User GetUser(string loginID, string pwd)
        {
            //string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = { loginID.ToLower() } AND LOGIN_PWD = { pwd }";
            string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = '{ loginID.ToLower() }'";
            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var user = FillUserModel(dtResult);
            return user.FirstOrDefault<User>();
        }

        public IList<User> GetAllUsers()
        {
            string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL";
            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var user = FillUserModel(dtResult);
            return user;
        }

        public int UpdateUserStatus(User user)
        {
            string updateUserInfo = $"UPDATE Mobifix_DB.USER_TBL SET FK_USER_STATUS_CD = '{user.UserStatus}' WHERE LOWER(LOGIN_ID) = '{user.LoginId.ToLowerInvariant()}' ";
            return mySqlHelper.ExecuteNonQuery(updateUserInfo);
        }

        public int InsertUserDetails(User user)
        {
           string InsertUserInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                $" VALUES({user.UserType}, '{user.LoginId}', '{user.Password}', {user.NoOfAttempts},  NOW(), '{user.UserStatus}', NOW(), {user.CrearedBy},NOW(), {user.LastUpdateBy});";

            InsertUserInfo += $"INSERT INTO Mobifix_DB.CUST_PHONE(FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, CONTACT_NUMBER, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),{user.ContactPhoneID}, {user.ContactNumber} ,'{user.ContactStatus}', NOW(), {user.AddByUserID}, NOW(), {user.ChangedByID};";

            InsertUserInfo += $"INSERT INTO Mobifix_DB.CUST_ADDRESS (FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, ADDR_LINE1, ADDR_LINE2, CITY, STATE, COUNTRY, ZIP_CODE, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(), {user.ContactAddrID}, '{user.AddressLine1}','{user.AddressLine2}', '{user.City}','{user.State}','{user.Country}', {user.ZIPCode}, '{user.ContactStatusCD}', NOW(), {user.ChangeByID}, NOW(), {user.AddByUserID}";
            return mySqlHelper.ExecuteNonQuery(InsertUserInfo);
        }

      private IList<User> FillUserModel(DataTable dtUsers)
        {
            var userList = new List<User>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new User();
                    user.LoginId = row["LOGIN_ID"].ToString();
                    user.UserType = row["FK_USER_TYPE_ID"].ToString();
                    user.NoOfAttempts = Convert.ToInt32(row["NUM_OF_FAILED_ATTEMPTS"]);
                    user.LastLoginDate = Convert.ToDateTime(row["LAST_LOGIN_DT"]);
                    UserStatus userStatus;
                    if (Enum.TryParse<UserStatus>(row["FK_USER_STATUS_CD"].ToString(), out userStatus))
                    {
                        //need to fix
                        user.UserStatus = row["FK_USER_STATUS_CD"].ToString();
                    }
                     userList.Add(user);
                }
            }
            return userList;
        }
    }
}