using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class UserStatusRepository
    {
        MySqlUserStatusHelper MySqlUserStatusHelper = new MySqlUserStatusHelper();

        public User_Status GetUserStatus(User_Status userstatus)
        {
            string fetchUserStatus = $"SELECT * FROM Mobifix_DB.USER_STATUS WHERE LOWER (USER_STATUS_CD) = '{userstatus.UserStatus.ToString() }'";
            var dtResult = MySqlUserStatusHelper.ExecuteQuery(fetchUserStatus);
            var getuserstatus = FillUserStatusModel(dtResult);
            return getuserstatus.FirstOrDefault<User_Status>();
        }

        public IList<User_Status> GetAllUserStatus()
        {
            string fetchUserStatus = $"SELECT * FROM Mobifix_DB.USER_STATUS";
            var dtResult = MySqlUserStatusHelper.ExecuteQuery(fetchUserStatus);
            var userstatus = FillUserStatusModel(dtResult);
            return userstatus;
        }
        
        public int UpdateUserStatus(User_Status userstatus)
        {
            string updateUserStatusInfo = $"UPDATE Mobifix_DB.USER_STATUS SET USER_STATUS_DESC = '{userstatus.UserStatusDescription}' WHERE LOWER(USER_STATUS_CD) = '{userstatus.UserStatus.ToString()}' ";
            return MySqlUserStatusHelper.ExecuteNonQuery(updateUserStatusInfo);
        }

        private IList<User_Status> FillUserStatusModel(DataTable dtUserStatus)
        {
            var userstatusList = new List<User_Status>();
            if (null != dtUserStatus && dtUserStatus.Rows.Count > 0)
            {
                foreach (DataRow row in dtUserStatus.Rows)
                {
                    var userstatus = new User_Status();

                    userstatus.UserStatus = Convert.ToString(row["USER_STATUS_CD"]);
                    userstatus.UserStatusDescription = Convert.ToString(row["USER_STATUS_DESC"]);

                    userstatusList.Add(userstatus);
                }
            }
            return userstatusList;
        }
    }
}
