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
        
        //public GetUser GetUser(GetUser user)
        //{
        //    //string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = { loginID.ToLower() } AND LOGIN_PWD = { pwd }";
        //    string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = '{user.LoginId.ToLowerInvariant()}' ";
        //    var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
        //    var getuser = FillGetUserModel(dtResult);
        //    return getuser.FirstOrDefault<GetUser>();
        //}
        public GetUser GetUser(GetUser user)
        {
            //string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = { loginID.ToLower() } AND LOGIN_PWD = { pwd }";

            string fetchUser = $"SELECT FIRST_NAME, LAST_NAME,CONTACT_NUMBER,LOGIN_ID,LOGIN_PWD,ADDR_LINE1, ADDR_LINE2,CITY,STATE,COUNTRY, ZIP_CODE from USER_TBL U INNER JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID INNER JOIN CUST_PHONE cp ON cp.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID INNER JOIN CUST_ADDRESS ca ON ca.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID  WHERE LOWER(LOGIN_ID) = '{user.LoginId.ToLowerInvariant()}'  ";

            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var getuser = FillGetUserModel(dtResult);
            return getuser.FirstOrDefault<GetUser>();
        }

        public GetPassword GetPassword(GetPassword password)
        {
            //string fetchUser = $"SELECT * FROM Mobifix_DB.USER_TBL WHERE LOWER(LOGIN_ID) = { loginID.ToLower() } AND LOGIN_PWD = { pwd }";
            string fetchUser = $"SELECT LOGIN_PWD from USER_TBL  WHERE LOWER(LOGIN_ID) = '{password.LoginId.ToLowerInvariant()}'  ";
            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var getpassword = FillGetPasswordModel(dtResult);
            return getpassword.FirstOrDefault<GetPassword>();
        }


        public IList<getAllUsers> GetAllUsers()
        {
            string fetchUser = $"SELECT CUST_VEND_ADMIN_ID, FULL_NAME, LOGIN_ID, FK_USER_STATUS_CD, CONTACT_NUMBER from USER_TBL U INNER JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID INNER JOIN CUST_PHONE cp ON cp.FK_CUST_VEND_ADMIN_ID=U.CUST_VEND_ADMIN_ID";
            var dtResult = mySqlHelper.ExecuteQuery(fetchUser);
            var user = FillgetAllUsersModel(dtResult);
            return user;
        }

        public IList<GetUserDetails> getuserDetails(GetUserDetails userdetail)
        {
            string GetUserDetailsInfo = $"SELECT CUST_VEND_ADMIN_ID, FIRST_NAME, LAST_NAME, CONTACT_NUMBER, LOGIN_ID, LOGIN_PWD, ADDR_LINE1, ADDR_LINE2, CITY, STATE, COUNTRY, ZIP_CODE   from USER_TBL U LEFT JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID = U.CUST_VEND_ADMIN_ID LEFT JOIN CUST_ADDRESS ca ON ca.FK_CUST_INFO_ID = ci.CUST_INFO_ID LEFT JOIN CUST_PHONE cp ON cp.FK_CUST_ADDRESS_ID = ca.CUST_ADDR_ID  WHERE CUST_VEND_ADMIN_ID = '{userdetail.custvendAdminID}'  and FK_USER_TYPE_ID=1";
            var dtResult = mySqlHelper.ExecuteQuery(GetUserDetailsInfo);
            var result = FillGetUserDetailsModel(dtResult);
            return result;
        }

        public int UpdateUserStatus(User user)
       
        {

            string updateUserInfo = $"UPDATE Mobifix_DB.USER_TBL ut INNER JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID=ut.CUST_VEND_ADMIN_ID INNER JOIN CUST_ADDRESS ca ON ci.CUST_INFO_ID=ca.FK_CUST_INFO_ID set ci.FIRST_NAME='{user.FirstName}',ci.LAST_NAME='{user.LastName}',ci.FULL_NAME='{user.FullName}',ca.ADDR_LINE1='{user.AddressLine1}',ca.ADDR_LINE2='{user.AddressLine2}',ca.CITY='{user.City}',ca.STATE='{user.State}',ca.COUNTRY='{user.Country}',ca.ZIP_CODE='{user.ZIPCode}' WHERE CUST_VEND_ADMIN_ID = '{user.custvendAdminID}' ";


            return mySqlHelper.ExecuteNonQuery(updateUserInfo);

            

            // string updateUserInfo = $"UPDATE Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
            //    $" VALUES('{user.UserType}', '{user.LoginId}', {user.NoOfAttempts},  NOW(), '{user.UserStatus}', NOW(), {user.CrearedBy},NOW(), {user.LastUpdateBy} WHERE CUST_VEND_ADMIN_ID = '{user.CustAdminid}');";

            //updateUserInfo += $"UPDATE Mobifix_DB.CUST_INFO(FK_CUST_VEND_ADMIN_ID, FIRST_NAME, LAST_NAME, FULL_NAME, NAMEPREFIX,GENDER,CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
            //     $"VALUES(' {user.CustAdminid},'{user.FirstName}', '{user.LastName}' ,'{user.FullName}','{user.NamePrefix}','{user.Gender}', NOW(), {user.AddByUserID}, NOW(), {user.ChangedByID}); ";

            //updateUserInfo += $"UPDATE Mobifix_DB.CUST_INFO(FK_CUST_INFO_ID, FK_CONTACT_TYPE_ID, ADDR_LINE1,ADDR_LINE2, CITY,STATE,COUNTRY,ZIP_CODE,FK_CONTACT_STATUS_CD,CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
            //     $"Select LAST_INSERT_ID(),{user.ContactPhoneID}, '{user.AddressLine1}' ,'{user.AddressLine2}','{user.City}','{user.State}',{user.ZIPCode},'{user.ContactStatus}', NOW(), {user.AddedByUserID}, NOW(), {user.ChangeByID}";


            //return mySqlHelper.ExecuteNonQuery(updateUserInfo);

        }

       
        public int InsertUserDetails(User user)
        {
           string InsertUserInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                $" VALUES({user.UserType}, '{user.LoginId}', '{user.Password}', {user.NoOfAttempts},  NOW(), '{user.UserStatus}', NOW(), {user.CrearedBy},NOW(), {user.LastUpdateBy});";

            InsertUserInfo += $"INSERT INTO Mobifix_DB.CUST_PHONE(FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, CONTACT_NUMBER, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),{user.ContactPhoneID}, {user.ContactNumber} ,'{user.ContactStatus}', NOW(), {user.AddedByUserID}, NOW(), {user.ChangedByID};";

            InsertUserInfo += $"INSERT INTO Mobifix_DB.CUST_ADDRESS (FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, ADDR_LINE1, ADDR_LINE2, CITY, STATE, COUNTRY, ZIP_CODE, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(), {user.ContactAddrID}, '{user.AddressLine1}','{user.AddressLine2}', '{user.City}','{user.State}','{user.Country}', {user.ZIPCode}, '{user.ContactStatusCD}', NOW(), {user.ChangeByID}, NOW(), {user.AddByUserID}";
            return mySqlHelper.ExecuteNonQuery(InsertUserInfo);
        }

        public int InsertUserRegistrationDetails(User user)
        {
            string InsertUserregistrationInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                $" VALUES({user.UserType}, '{user.LoginId}', '{user.Password}', {user.NoOfAttempts},  NOW(), '{user.UserStatus}', NOW(), {user.CrearedBy},NOW(), {user.LastUpdateBy});";

            InsertUserregistrationInfo += $"INSERT INTO Mobifix_DB.CUST_INFO(FK_CUST_VEND_ADMIN_ID, FIRST_NAME, LAST_NAME, FULL_NAME, NAMEPREFIX,GENDER,CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),'{user.FirstName}', '{user.LastName}' ,'{user.FullName}','{user.NamePrefix}','{user.Gender}', NOW(), {user.AddByUserID}, NOW(), {user.ChangedByID};";

            InsertUserregistrationInfo += $"INSERT INTO Mobifix_DB.CUST_ADDRESS (FK_CUST_INFO_ID, FK_CONTACT_TYPE_ID, ADDR_LINE1, ADDR_LINE2, CITY, STATE, COUNTRY, ZIP_CODE, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(), {user.ContactAddrID}, '{user.AddressLine1}','{user.AddressLine2}', '{user.City}','{user.State}','{user.Country}', {user.ZIPCode}, '{user.ContactStatusCD}', NOW(), {user.ChangeByID}, NOW(), {user.AddByUserID};";

            InsertUserregistrationInfo += $"INSERT INTO Mobifix_DB.CUST_PHONE(FK_CUST_ADDRESS_ID, FK_CONTACT_TYPE_ID, CONTACT_NUMBER, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),{user.CustID}, {user.ContactNumber} ,'{user.ContactStatus}', NOW(), {user.AddByUserID}, NOW(), {user.ChangedByID}";
            return mySqlHelper.ExecuteNonQuery(InsertUserregistrationInfo);
        }

        public int UserStatusDetails(User user)
        {
            string StatusUserInfo = $"SELECT CUST_VEND_ADMIN_ID = '{user.Id}', LOGIN_ID = '{user.LoginId}', LOGIN_PWD = '{user.Password}' FROM Mobifix_DB.USER_TBL WHERE CUST_VEND_ADMIN_ID = '{user.Id}'";

            return mySqlHelper.ExecuteNonQuery(StatusUserInfo);
        }

        public IList<GetUser> UserNameStatus(GetUser getuser)

            {
  
            string UserNameStatusInfo = $"SELECT CUST_VEND_ADMIN_ID, FIRST_NAME, LAST_NAME, CONTACT_NUMBER, LOGIN_ID, LOGIN_PWD, ADDR_LINE1, ADDR_LINE2, CITY, STATE, COUNTRY, ZIP_CODE   from USER_TBL U LEFT JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID = U.CUST_VEND_ADMIN_ID LEFT JOIN CUST_ADDRESS ca ON ca.FK_CUST_INFO_ID = ci.CUST_INFO_ID LEFT JOIN CUST_PHONE cp ON cp.FK_CUST_ADDRESS_ID = ca.CUST_ADDR_ID WHERE LOWER(LOGIN_ID) = '{getuser.LoginId.ToLowerInvariant()}' and LOWER(LOGIN_PWD) ='{getuser.Password}' and FK_USER_TYPE_ID=1";
            var dtResult = mySqlHelper.ExecuteQuery(UserNameStatusInfo);            
            var result = FillGetUserModel(dtResult);
             return result;
        }

        public IList<GetUser> resetPassword(GetUser getuser)

        {
            
            string resetPasswordInfo = $"SELECT CUST_VEND_ADMIN_ID, FIRST_NAME, LAST_NAME, CONTACT_NUMBER, LOGIN_ID, LOGIN_PWD, ADDR_LINE1, ADDR_LINE2, CITY, STATE, COUNTRY, ZIP_CODE   from USER_TBL U LEFT JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID = U.CUST_VEND_ADMIN_ID LEFT JOIN CUST_ADDRESS ca ON ca.FK_CUST_INFO_ID = ci.CUST_INFO_ID LEFT JOIN CUST_PHONE cp ON cp.FK_CUST_ADDRESS_ID = ca.CUST_ADDR_ID WHERE LOWER(LOGIN_ID) = '{getuser.LoginId.ToLowerInvariant()}'  and FK_USER_TYPE_ID=1";
            var dtResult = mySqlHelper.ExecuteQuery(resetPasswordInfo);
            var result = FillGetUserModel(dtResult);
            return result;
        }
        private IList<GetUser> FillGetUserModel(DataTable dtUsers)
        {
            var userList = new List<GetUser>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new GetUser();
                    user.custvendAdminID = Convert.ToInt32(row["CUST_VEND_ADMIN_ID"]);
                    user.FirstName = Convert.ToString(row["FIRST_NAME"]);
                    user.LastName = Convert.ToString(row["LAST_NAME"]);
                    user.ContactNumber = Convert.ToString(row["CONTACT_NUMBER"]);
                    user.LoginId = Convert.ToString(row["LOGIN_ID"]);
                    
                    
                    user.Password = Convert.ToString(row["LOGIN_PWD"]);
                    user.AddressLine1 = Convert.ToString(row["ADDR_LINE1"]);
                    user.AddressLine2 = Convert.ToString(row["ADDR_LINE2"]);
                    user.City = Convert.ToString(row["CITY"]);
                    user.State = Convert.ToString(row["STATE"]);
                    user.Country = Convert.ToString(row["COUNTRY"]);
                    user.ZIPCode = Convert.ToString(row["ZIP_CODE"]);


                    
                    userList.Add(user);
                }
            }
            return userList;
        }

        private IList<GetUserDetails> FillGetUserDetailsModel(DataTable dtUsers)
        {
            var GetUserDetailsList = new List<GetUserDetails>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var UserDetails = new GetUserDetails();
                    UserDetails.custvendAdminID = Convert.ToInt32(row["CUST_VEND_ADMIN_ID"]);
                    UserDetails.FirstName = Convert.ToString(row["FIRST_NAME"]);
                    UserDetails.LastName = Convert.ToString(row["LAST_NAME"]);
                    UserDetails.ContactNumber = Convert.ToString(row["CONTACT_NUMBER"]);
                    UserDetails.LoginId = Convert.ToString(row["LOGIN_ID"]);


                    UserDetails.Password = Convert.ToString(row["LOGIN_PWD"]);
                    UserDetails.AddressLine1 = Convert.ToString(row["ADDR_LINE1"]);
                    UserDetails.AddressLine2 = Convert.ToString(row["ADDR_LINE2"]);
                    UserDetails.City = Convert.ToString(row["CITY"]);
                    UserDetails.State = Convert.ToString(row["STATE"]);
                    UserDetails.Country = Convert.ToString(row["COUNTRY"]);
                    UserDetails.ZIPCode = Convert.ToString(row["ZIP_CODE"]);



                    GetUserDetailsList.Add(UserDetails);
                }
            }
            return GetUserDetailsList;
        }

        private IList<GetPassword> FillGetPasswordModel(DataTable dtUsers)
        {
            var userList = new List<GetPassword>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new GetPassword();    
                    
                     user.Password = Convert.ToString(row["LOGIN_PWD"]);

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
    
