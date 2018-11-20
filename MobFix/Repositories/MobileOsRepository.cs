using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

namespace MobFix.Repositories
{
    public class MobileOsRepository
    {
        MySqlMobileOsHelper MySqlMobileOsHelper = new MySqlMobileOsHelper();


        public MobileOs GetMobileOsType(int MobileOSID, int MobileVersionTypeID)
        {
            string fetchMobileOsType = $"SELECT * FROM Mobifix_DB.MOBILE_OS_TYPE WHERE LOWER MOBILE_OS_TYPE_ID () = '{ MobileOSID.ToString() }'";
            var dtResult = MySqlMobileOsHelper.ExecuteQuery(fetchMobileOsType);
            var mobileostype = FillMobileOsTypesModel(dtResult);
            return mobileostype.FirstOrDefault<MobileOs>();

        }

        public IList<MobileOs> GetAllMobileOsTypes()
        {
            string fetchMobileOsType = $"SELECT * FROM Mobifix_DB.MOBILE_OS_TYPE";
            var dtResult = MySqlMobileOsHelper.ExecuteQuery(fetchMobileOsType);
            var mobileostype = FillMobileOsTypesModel(dtResult);
            return mobileostype;

        }

        private IList<MobileOs> FillMobileOsTypesModel(DataTable dtMobileOsType)
        {
            var mobileostypesList = new List<MobileOs>();
            if (null != dtMobileOsType && dtMobileOsType.Rows.Count > 0)
            {
                foreach (DataRow row in dtMobileOsType.Rows)
                {
                    var mobileostype = new MobileOs();
                    mobileostype.MobileOsID = Convert.ToInt32(row["MOBILE_OS_TYPE_ID"]);
                    mobileostype.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    mobileostype.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);
                    mobileostype.LastModifiedDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                    mobileostypesList.Add(mobileostype);
                }
            }
            return mobileostypesList;
        }

        //public int InsertMobileDetails(MobileOs mobileos)
        //{
        //    string InsertMobileInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
        //        $" VALUES({user.UserType}, '{user.LoginId}', '{user.Password}', {user.NoOfAttempts},  NOW(), '{user.UserStatus}', NOW(), {user.CrearedBy},NOW(), {user.LastUpdateBy}";
        //}

        public int UpdateMobileOs(MobileOs mobileos)
        {
            string updateMobileOs = $"UPDATE Mobifix_DB.MOBILE_OS_TYPE SET MOBILE_OS_TYPE_IND  = '{mobileos.MobileOsTypeInd}' WHERE LOWER(MOBILE_OS_TYPE_ID) = '{mobileos.MobileOsID.ToString()}' ";

            return MySqlMobileOsHelper.ExecuteNonQuery(updateMobileOs);
        }
    }
}
