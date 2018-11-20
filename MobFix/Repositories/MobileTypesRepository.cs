using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class MobileTypesRepository
    {
        MySqlMobileTypesHelper MySqlMobileTypesHelper = new MySqlMobileTypesHelper();


        public MobileTypes GetMobileType(int MobileCompanyID, string MobileCompDesc)
        {
            string fetchMobileType = $"SELECT * FROM Mobifix_DB.MOBILE_TYPE WHERE LOWER MOBILE_CMPNY_ID () = '{ MobileCompanyID.ToString() }'";
            var dtResult = MySqlMobileTypesHelper.ExecuteQuery(fetchMobileType);
            var mobiletype = FillMobileTypesModel(dtResult);
            return mobiletype.FirstOrDefault<MobileTypes>();

        }

        public IList<MobileTypes> GetAllMobileTypes()
        {
            string fetchMobileType = $"SELECT * FROM Mobifix_DB.MOBILE_TYPE";
            var dtResult = MySqlMobileTypesHelper.ExecuteQuery(fetchMobileType);
            var mobiletype = FillMobileTypesModel(dtResult);
            return mobiletype;

        }

        private IList<MobileTypes> FillMobileTypesModel(DataTable dtMobileType)
        {
            var mobiletypesList = new List<MobileTypes>();
            if (null != dtMobileType && dtMobileType.Rows.Count > 0)
            {
                foreach (DataRow row in dtMobileType.Rows)
                {
                    var mobiletype = new MobileTypes();
                    mobiletype.MobileCompanyID = Convert.ToInt32(row["MOBILE_CMPNY_ID"]);
                    mobiletype.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    mobiletype.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);
                    mobiletypesList.Add(mobiletype);
                }
            }
            return mobiletypesList;
        }
        public int UpdateMobileTypes(MobileTypes mobiletypes)
        {
            string updateMobileTypes = $"UPDATE Mobifix_DB.MOBILE_TYPE SET MOBILE_CMPNY_DESC  = '{mobiletypes.MobileCompany}' WHERE LOWER(MOBILE_CMPNY_ID) = '{mobiletypes.MobileCompanyID.ToString()}' ";

            return MySqlMobileTypesHelper.ExecuteNonQuery(updateMobileTypes);
        }
    }
}
