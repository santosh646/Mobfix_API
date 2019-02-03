using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
namespace MobFix.Repositories
{
    public class IssuePriceRepository
    {
        MySqlIssueTypeHelper MySqlIssueTypeHelper = new MySqlIssueTypeHelper();


        public IList<IssuePrice>  GetIssuePrice(IssuePrice issueprice)
        {
            string fetchIssuePriceType = $"SELECT * FROM Mobifix_DB.MOBILE_ISSUE_PRICE WHERE LOWER (FK_MOBILE_VER_TYPE_ID) = '{ issueprice.MobileVerTypeID}'";
            var dtResult = MySqlIssueTypeHelper.ExecuteQuery(fetchIssuePriceType);
            var issuepricetype = FillIssuePriceModel(dtResult);
            return issuepricetype;

        }




        private IList<IssuePrice> FillIssuePriceModel(DataTable dtIssuePrice)
        {
            var issuepriceList = new List<IssuePrice>();
            if (null != dtIssuePrice && dtIssuePrice.Rows.Count > 0)
            {
                foreach (DataRow row in dtIssuePrice.Rows)
                {
                    var issueprice = new IssuePrice();
                    issueprice.MobileIssuePriceID = Convert.ToInt32(row["MOBILE_ISSUE_PRICE_ID"]);
                    issueprice.MobileVerTypeID = Convert.ToInt32(row["FK_MOBILE_VER_TYPE_ID"]);
                    issueprice.MobileIssue = Convert.ToString(row["MOBILE_ISSUE"]);
                    issueprice.InitialQuote = Convert.ToInt32(row["INITIAL_QUOTE"]);
                    issueprice.EstimatedQuote = Convert.ToInt32(row["ESTIMATED_QUOTE"]);
                    issueprice.FinalCost = Convert.ToInt32(row["FINAL_COST"]);
                   
                    issueprice.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    issueprice.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);

                    issueprice.LastModifiedDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                    issueprice.LastModifiedBy = Convert.ToInt32(row["LASTMODIFIED_BY"]);

                    issuepriceList.Add(issueprice);
                }
            }
            return issuepriceList;
        }
    }
}