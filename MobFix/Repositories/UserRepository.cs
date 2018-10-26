using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

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

        private IList<User> FillUserModel(DataTable dtUsers)
        {
            var userList = new List<User>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new User();
                    user.LoginId = row["LOGIN_ID"].ToString();
                    UserType userType;
                    if (Enum.TryParse<UserType>(row["FK_USER_TYPE_ID"].ToString(), out userType))
                    {
                        user.UserType = userType.ToString();
                    }
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
