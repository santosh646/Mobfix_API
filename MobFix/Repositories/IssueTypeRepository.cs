using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class IssueTypeRepository
    {
        MySqlIssueTypeHelper MySqlIssueTypeHelper = new MySqlIssueTypeHelper();


        public IssueType GetIssueType(IssueType issuetype)
        {
            string fetchIssueType = $"SELECT * FROM Mobifix_DB.ISSUE_TYPE WHERE LOWER (ISSUE_TYPE_ID) = '{ issuetype.IssueTypeID.ToString() }'";
            var dtResult = MySqlIssueTypeHelper.ExecuteQuery(fetchIssueType);
            var getissuetype = FillIssueTypesModel(dtResult);
            return getissuetype.FirstOrDefault<IssueType>();

        }

        public IList<IssueType> GetAllIssueTypes()
        {
            string fetchIssueType = $"SELECT * FROM Mobifix_DB.ISSUE_TYPE";
            var dtResult = MySqlIssueTypeHelper.ExecuteQuery(fetchIssueType);
            var issuetype = FillIssueTypesModel(dtResult);
            return issuetype;

        }

        public int UpdateIssueTypeStatus(IssueType issuetype)
        {
            string updateIssueTypeInfo = $"UPDATE Mobifix_DB.ISSUE_TYPE SET ISSUE_TYPE_IND = '{issuetype.IssuesTypeInd}' WHERE LOWER(ISSUE_TYPE_ID) = '{issuetype.IssueTypeID.ToString()}' ";
            return MySqlIssueTypeHelper.ExecuteNonQuery(updateIssueTypeInfo);
        }

        private IList<IssueType> FillIssueTypesModel(DataTable dtIssueType)
        {
            var issuetypesList = new List<IssueType>();
            if (null != dtIssueType && dtIssueType.Rows.Count > 0)
            {
                foreach (DataRow row in dtIssueType.Rows)
                {
                    var issuetype = new IssueType();
                    issuetype.IssueTypeID = Convert.ToInt32(row["ISSUE_TYPE_ID"]);
                    issuetype.IssuesTypeDescription = Convert.ToString(row["ISSUE_TYPE_DESC"]);
                    issuetype.IssuesTypeInd= Convert.ToString(row["ISSUE_TYPE_IND"]);

                    issuetype.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    issuetype.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);

                    issuetype.LastModifiedDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                    issuetype.LastModifiedBy = Convert.ToInt32(row["LASTMODIFIED_BY"]);

                    issuetypesList.Add(issuetype);
                }
            }
            return issuetypesList;
        }
    }
}