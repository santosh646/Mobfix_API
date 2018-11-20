using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class MobileVersionRepository
    {

        MySqlMobileVersionHelper MySqlMobileVersionHelper = new MySqlMobileVersionHelper();


        public MobileVersion GetMobileVersion(int MobileVersionID, int MobileCompanyID )
        {
            string fetchMobileVersionType = $"SELECT * FROM Mobifix_DB.MOBILE_VER_TYPE WHERE LOWER MOBILE_VER_TYPE_ID () = '{ MobileVersionID.ToString() }'";
            var dtResult = MySqlMobileVersionHelper.ExecuteQuery(fetchMobileVersionType);
            var mobileversiontype = FillMobileVersionTypesModel(dtResult);
            return mobileversiontype.FirstOrDefault<MobileVersion>();

        }

        public IList<MobileVersion> GetAllMobileVersions()
        {
            string fetchMobileVersionType = $"SELECT * FROM Mobifix_DB.MOBILE_VER_TYPE";
            var dtResult = MySqlMobileVersionHelper.ExecuteQuery(fetchMobileVersionType);
            var mobileversiontype = FillMobileVersionTypesModel(dtResult);
            return mobileversiontype;

        }

        private IList<MobileVersion> FillMobileVersionTypesModel(DataTable dtMobileVersion)
        {
            var mobileversiontypesList = new List<MobileVersion>();
            if (null != dtMobileVersion && dtMobileVersion.Rows.Count > 0)
            {
                foreach (DataRow row in dtMobileVersion.Rows)
                {
                    var mobileversiontype = new MobileVersion();
                    mobileversiontype.MobileVersionTypeID = Convert.ToInt32(row["MOBILE_VER_TYPE_ID"]);
                    mobileversiontype.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    mobileversiontype.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);
                    
                    mobileversiontypesList.Add(mobileversiontype);
                }
            }
            return mobileversiontypesList;
        }
        public int UpdateMobileVersion(MobileVersion mobileversion)
        {
            string updateMobileVersion = $"UPDATE Mobifix_DB.MOBILE_VER_TYPE SET MOBILE_VER_DESC  = '{mobileversion.MobileVersionDescription}' WHERE LOWER(MOBILE_VER_TYPE_ID) = '{mobileversion.MobileVersionTypeID.ToString()}' ";

            return MySqlMobileVersionHelper.ExecuteNonQuery(updateMobileVersion);
        }

    }
}