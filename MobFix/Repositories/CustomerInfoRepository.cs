using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class CustomerInfoRepository
    {
        MySqlCustomerInfoHelper MySqlCustomerInfoHelper = new MySqlCustomerInfoHelper();

        public Cust_Info GetCustomerInfo(Cust_Info customerInfo)
        {
            string fetchCustomerInfo = $"SELECT * FROM Mobifix_DB.CUST_INFO WHERE LOWER (CUST_INFO_ID) = '{customerInfo.CustInfoID.ToString() }'";
            var dtResult = MySqlCustomerInfoHelper.ExecuteQuery(fetchCustomerInfo);
            var getcustomerinfo = FillCustomerInfoModel(dtResult);
            return getcustomerinfo.FirstOrDefault<Cust_Info>();

        }

        public IList<Cust_Info> GetAllCustomerInfos()
        {
            string fetchCustomerInfo = $"SELECT * FROM Mobifix_DB.CUST_INFO";
            var dtResult = MySqlCustomerInfoHelper.ExecuteQuery(fetchCustomerInfo);
            var customerinfo = FillCustomerInfoModel(dtResult);
            return customerinfo;
        }

        public int UpdateCustomerInfoStatus(Cust_Info customerinfo)
        {
            string updateCustomerInfo = $"UPDATE Mobifix_DB.CUST_INFO SET LAST_NAME = '{customerinfo.LastName}' WHERE LOWER(CUST_INFO_ID) = '{customerinfo.CustInfoID.ToString()}' ";
            return MySqlCustomerInfoHelper.ExecuteNonQuery(updateCustomerInfo);
        }

        private IList<Cust_Info> FillCustomerInfoModel(DataTable dtCustomerInfo)
        {
            var customerinfoList = new List<Cust_Info>();
            if (null != dtCustomerInfo && dtCustomerInfo.Rows.Count > 0)
            {
                foreach (DataRow row in dtCustomerInfo.Rows)
                {
                    var customerinfo = new Cust_Info();

                    customerinfo.CustInfoID = Convert.ToInt32(row["CUST_INFO_ID"]);
                    customerinfo.CustVendorAdminID = Convert.ToInt32(row["FK_CUST_VEND_ADMIN_ID"]);
                    customerinfo.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);

                    customerinfoList.Add(customerinfo);
                }
            }
            return customerinfoList;
        }
        public int DeleteCustomerInfo(Cust_Info customerinfo)
        {
            string updateCustomerInfo = $"DELETE FROM Mobifix_DB.CUST_INFO  WHERE LOWER(CUST_INFO_ID) = '{customerinfo.CustInfoID.ToString()}' ";
            return MySqlCustomerInfoHelper.ExecuteNonQuery(updateCustomerInfo);
        }
    }
}