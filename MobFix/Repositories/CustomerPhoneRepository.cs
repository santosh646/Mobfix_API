using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class CustomerPhoneRepository
    {
        MySqlCustomerPhoneHelper MySqlCustomerPhoneHelper = new MySqlCustomerPhoneHelper();


        public Cust_Phone GetCustomerPhone(Cust_Phone customerphone)
        {
            string fetchCustomerPhone = $"SELECT * FROM Mobifix_DB.CUST_PHONE WHERE LOWER (CUST_PHONE_ID) = '{customerphone.CustPhoneID.ToString() }'";
            var dtResult = MySqlCustomerPhoneHelper.ExecuteQuery(fetchCustomerPhone);
            var getcustomerPhone = FillCustomerPhoneModel(dtResult);
            return getcustomerPhone.FirstOrDefault<Cust_Phone>();

        }

        public IList<Cust_Phone> GetAllCustomerPhones()
        {
            string fetchCustomerPhone = $"SELECT * FROM Mobifix_DB.CUST_PHONE";
            var dtResult = MySqlCustomerPhoneHelper.ExecuteQuery(fetchCustomerPhone);
            var customerphone = FillCustomerPhoneModel(dtResult);
            return customerphone;

        }
        public int UpdateCustomerPhoneStatus(Cust_Phone customerphone)
        {
            string updateCustomerPhoneInfo = $"UPDATE Mobifix_DB.CUST_PHONE SET CONTACT_NUMBER = '{customerphone.ContactNumber}' WHERE LOWER(CUST_PHONE_ID) = '{customerphone.CustPhoneID.ToString()}' ";
            return MySqlCustomerPhoneHelper.ExecuteNonQuery(updateCustomerPhoneInfo);
        }

        private IList<Cust_Phone> FillCustomerPhoneModel(DataTable dtCustomerPhone)
        {
            var customerphoneList = new List<Cust_Phone>();
            if (null != dtCustomerPhone && dtCustomerPhone.Rows.Count > 0)
            {
                foreach (DataRow row in dtCustomerPhone.Rows)
                {
                    var customerphone = new Cust_Phone();

                    customerphone.CustPhoneID = Convert.ToInt32(row["CUST_PHONE_ID"]);
                    customerphone.CustID = Convert.ToInt32(row["FK_CUST_VEND_ADMIN_ID"]);
                    customerphone.ContactPhoneID = Convert.ToInt32(row["FK_CONTACT_TYPE_ID"]);
                    customerphone.ContactNumber = Convert.ToString(row["CONTACT_NUMBER"]);
                    customerphone.ContactStatus = Convert.ToString(row["FK_CONTACT_STATUS_CD"]);
                    customerphone.AddedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    customerphone.AddByUserID = Convert.ToInt32(row["CREATED_BY"]);
                    customerphone.ChangedDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                    customerphone.ChangedByID = Convert.ToInt32(row["LASTMODIFIED_BY"]);
                    customerphoneList.Add(customerphone);
                }
            }
            return customerphoneList;
        }


    }
}