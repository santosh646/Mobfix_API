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

        public GetUser GetUser(GetUser user)
        {
            //string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = { loginID.ToLower() } AND LOGIN_PWD = { pwd }";
            string fetchUser = $"SELECT CUST_VEND_ADMIN_ID, FIRST_NAME, LAST_NAME,  LOGIN_ID, FK_USER_TYPE_ID, FK_USER_STATUS_CD, CONTACT_NUMBER, ADDR_LINE1, ADDR_LINE2, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD from USER_TBL U INNER JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID INNER JOIN CUST_PHONE cp ON cp.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID INNER JOIN CUST_ADDRESS ca ON ca.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID WHERE LOWER(LOGIN_ID) = '{user.LoginId.ToLowerInvariant()}' ";
            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var getuser = FillGetUserModel(dtResult);
            return getuser.FirstOrDefault<GetUser>();
        }

        public IList<getAllUsers> GetAllUsers()
        {
            string fetchUser = $"SELECT CUST_VEND_ADMIN_ID, FULL_NAME, LOGIN_ID, FK_USER_STATUS_CD, CONTACT_NUMBER from USER_TBL U INNER JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID INNER JOIN CUST_PHONE cp ON cp.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID";
            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var user = FillgetAllUsersModel(dtResult);
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

        public int InsertUserRegistrationDetails(User user)
        {
            string InsertUserregistrationInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                $" VALUES({user.UserType}, '{user.LoginId}', '{user.Password}', {user.NoOfAttempts},  NOW(), '{user.UserStatus}', NOW(), {user.CrearedBy},NOW(), {user.LastUpdateBy});";

            InsertUserregistrationInfo += $"INSERT INTO Mobifix_DB.CUST_PHONE(FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, CONTACT_NUMBER, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),{user.ContactPhoneID}, {user.ContactNumber} ,'{user.ContactStatus}', NOW(), {user.AddByUserID}, NOW(), {user.ChangedByID}";
            return mySqlHelper.ExecuteNonQuery(InsertUserregistrationInfo);
        }

        public int UserStatusDetails(User user)
        {
            string StatusUserInfo = $"SELECT CUST_VEND_ADMIN_ID = '{user.Id}', LOGIN_ID = '{user.LoginId}', LOGIN_PWD = '{user.Password}' FROM Mobifix_DB.USER_TBL WHERE CUST_VEND_ADMIN_ID = '{user.Id}'";

            return mySqlHelper.ExecuteNonQuery(StatusUserInfo);
        }

        private IList<GetUser> FillGetUserModel(DataTable dtUsers)
        {
            var userList = new List<GetUser>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new GetUser();
                    user.Id = Convert.ToString(row["CUST_VEND_ADMIN_ID"]);
                    user.FirstName = row["FIRST_NAME"].ToString();
                    user.LastName = row["LAST_NAME"].ToString();
                    user.LoginId = row["LOGIN_ID"].ToString();
                    user.UserType = Convert.ToString(row["FK_USER_TYPE_ID"]);
                    user.ContactNumber = Convert.ToString(row["CONTACT_NUMBER"]);
                    user.AddressLine1 = row["ADDR_LINE1"].ToString();
                    user.AddressLine2 = row["ADDR_LINE2"].ToString();
                    user.NoOfAttempts = Convert.ToInt32(row["NUM_OF_FAILED_ATTEMPTS"]);
                    user.LastLoginDate = Convert.ToDateTime(row["LAST_LOGIN_DT"]);
                    UserStatus userStatus;
                    if (Enum.TryParse<UserStatus>(row["FK_USER_STATUS_CD"].ToString(), out userStatus))
                    {
                        //need to fix
                        user.UserStatus = row["FK_USER_STATUS_CD"].ToString();
                    }
                    //user.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"].ToString());
                    //user.CrearedBy = row["CREATED_BY"].ToString();
                    //user.LastUpdateDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                    //user.LastUpdateBy = row["LASTMODIFIED_BY"].ToString();
                    userList.Add(user);
                }
            }
            return userList;
        }

        private IList<User> FillUserModel(DataTable dtUsers)
        {
            var userList = new List<User>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new User();
                    user.Id = Convert.ToString(row["CUST_VEND_ADMIN_ID"]);
                    user.UserType = row["FK_USER_TYPE_ID"].ToString();
                    user.LoginId = row["LOGIN_ID"].ToString();
                    user.NoOfAttempts = Convert.ToInt32(row["NUM_OF_FAILED_ATTEMPTS"]);
                    user.LastLoginDate = Convert.ToDateTime(row["LAST_LOGIN_DT"]);
                    UserStatus userStatus;
                    if (Enum.TryParse<UserStatus>(row["FK_USER_STATUS_CD"].ToString(), out userStatus))
                    {
                        //need to fix
                        user.UserStatus = row["FK_USER_STATUS_CD"].ToString();
                    }
                    user.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"].ToString());
                    user.CrearedBy = row["CREATED_BY"].ToString();
                    user.LastUpdateDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                    user.LastUpdateBy = row["LASTMODIFIED_BY"].ToString();
                    user.ContactPhoneID = Convert.ToInt32(row["FK_NOCONS_CUST_PHONE_ID"]);
                    user.ContactNumber = row["CONTACT_NUMBER"].ToString();
                    userList.Add(user);
                }
            }
            return userList;
        }

        private IList<getAllUsers> FillgetAllUsersModel(DataTable dtUsers)
        {
            var userList = new List<getAllUsers>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new getAllUsers();
                    user.customeradminid = Convert.ToInt32(row["CUST_VEND_ADMIN_ID"]);
                    user.fullname = Convert.ToString(row["FULL_NAME"]);
                    user.LoginId = row["LOGIN_ID"].ToString();
                    user.ContactNumber = Convert.ToString(row["CONTACT_NUMBER"]);
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

