using MobFix.Controllers;
using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class CostQuoteRepository
    {
        MySqlCostQuoteHelper MySqlCostQuoteHelper = new MySqlCostQuoteHelper();


        public Cost_Quote GetCostQuote(Cost_Quote costquote)
        {
            string fetchCostQuote = $"SELECT * FROM Mobifix_DB.COST_QUOTE WHERE LOWER (COST_QUOTE_ID) = '{ costquote.CostQuoteID.ToString() }'";
            var dtResult = MySqlCostQuoteHelper.ExecuteQuery(fetchCostQuote);
            var getcostquote = FillCostQuoteModel(dtResult);
            return getcostquote.FirstOrDefault<Cost_Quote>();

        }

        public IList<Cost_Quote> GetAllCostQuotes()
        {
            string fetchCostQuote = $"SELECT * FROM Mobifix_DB.COST_QUOTE";
            var dtResult = MySqlCostQuoteHelper.ExecuteQuery(fetchCostQuote);
            var costquote = FillCostQuoteModel(dtResult);
            return costquote;

        }

        private IList<Cost_Quote> FillCostQuoteModel(DataTable dtCostQuote)
        {
            var costquoteList = new List<Cost_Quote>();
            if (null != dtCostQuote && dtCostQuote.Rows.Count > 0)
            {
                foreach (DataRow row in dtCostQuote.Rows)
                {
                    var costquote = new Cost_Quote();

                    costquote.CostQuoteID= Convert.ToInt32(row["COST_QUOTE_ID"]);
                    costquote.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    costquote.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);
                    costquote.LastModifiedDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                    costquote.CostQuoteIND = Convert.ToChar(row["COST_QUOTE_IND"]);

                    costquoteList.Add(costquote);
                }
            }
            return costquoteList;
        }
        public int UpdateCostQuote(Cost_Quote costquote)
        {
            string updateOrderInfo = $"UPDATE Mobifix_DB.COST_QUOTE SET COST_QUOTE_IND  = '{costquote.CostQuoteIND}' WHERE LOWER(COST_QUOTE_ID) = '{costquote.CostQuoteID.ToString()}' ";
            return MySqlCostQuoteHelper.ExecuteNonQuery(updateOrderInfo);
        }
        public int DeleteCostQuote(Cost_Quote costquote)
        {
            string updateCostQuoteInfo = $"DELETE FROM Mobifix_DB.COST_QUOTE  WHERE LOWER(COST_QUOTE_ID) = '{costquote.CostQuoteID.ToString()}' ";
            return MySqlCostQuoteHelper.ExecuteNonQuery(updateCostQuoteInfo);
        }
    }
}