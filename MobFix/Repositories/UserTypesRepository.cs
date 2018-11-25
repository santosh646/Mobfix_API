using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class UserTypesRepository
    {
        MySqlUserTypesHelper MySqlUserTypesHelper = new MySqlUserTypesHelper();


        public UserTypes GetUserType(UserTypes usertype)
        {
            string fetchUserType = $"SELECT * FROM Mobifix_DB.USER_TYPE WHERE LOWER (USER_TYPE_ID) = '{usertype.UserTypeID.ToString() }'";
            var dtResult = MySqlUserTypesHelper.ExecuteQuery(fetchUserType);
            var getusertype = FillUserTypesModel(dtResult);
            return getusertype.FirstOrDefault<UserTypes>();

        }

        public IList<UserTypes> GetAllUserTypes()
        {
            string fetchUserType = $"SELECT * FROM Mobifix_DB.USER_TYPE";
            var dtResult = MySqlUserTypesHelper.ExecuteQuery(fetchUserType);
            var usertype = FillUserTypesModel(dtResult);
            return usertype;

        }

        public int InsertUserRegistrationDetails(UserTypes usertype)
        {
            string InsertUserregistrationInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                $" VALUES({usertype.UserType}, '{usertype.LoginId}', '{usertype.Password}', {usertype.NoOfAttempts},  NOW(), '{usertype.UserStatus}', NOW(), {usertype.CrearedBy},NOW(), {usertype.LastUpdateBy});";

            InsertUserregistrationInfo += $"INSERT INTO Mobifix_DB.CUST_PHONE(FK_CUST_VEND_ADMIN_ID, FK_CONTACT_TYPE_ID, CONTACT_NUMBER, FK_CONTACT_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY) " +
                 $"Select LAST_INSERT_ID(),{usertype.ContactPhoneID}, {usertype.ContactNumber} ,'{usertype.ContactStatus}', NOW(), {usertype.AddByUserID}, NOW(), {usertype.ChangedByID}";
            return MySqlUserTypesHelper.ExecuteNonQuery(InsertUserregistrationInfo);
        }

        public int UpdateUserTypeStatus(UserTypes usertype)
        {
            string updateUserTypeInfo = $"UPDATE Mobifix_DB.USER_TYPE SET USER_ROLE = '{usertype.UserRole}' WHERE LOWER(USER_TYPE_ID) = '{usertype.UserTypeID.ToString()}' ";
            return MySqlUserTypesHelper.ExecuteNonQuery(updateUserTypeInfo);
        }


        private IList<UserTypes> FillUserTypesModel(DataTable dtUserType)
        {
            var usertypesList = new List<UserTypes>();
            if (null != dtUserType && dtUserType.Rows.Count > 0)
            {
                foreach (DataRow row in dtUserType.Rows)
                {
                    var usertype = new UserTypes();
                    usertype.UserTypeID = Convert.ToInt32(row["USER_TYPE_ID"]);
                   
                    usertype.MaxLoginattempts = Convert.ToInt32(row["MAX_LOGIN_ATTEMPTS"]);

                    usertypesList.Add(usertype);
                }
            }
            return usertypesList;
        }
    }

    internal class UserRole
    {
    }
}