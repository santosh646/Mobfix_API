using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class CustomerAddressRepository
    {
        MySqlCustomerAddressHelper MySqlCustomerAddressHelper = new MySqlCustomerAddressHelper();


        public Cust_Addr GetCustomerAddress(Cust_Addr customeraddress)
        {
            string fetchCustomerAddress = $"SELECT * FROM Mobifix_DB.CUST_ADDRESS WHERE LOWER (CUST_ADDR_ID) = '{customeraddress.CustAddrID.ToString() }'";
            var dtResult = MySqlCustomerAddressHelper.ExecuteQuery(fetchCustomerAddress);
            var getcustomeraddress = FillCustomerAddressModel(dtResult);
            return getcustomeraddress.FirstOrDefault<Cust_Addr>();

        }

        public IList<Cust_Addr> GetAllCustomerAddresses()
        {
            string fetchCustomerAddress = $"SELECT * FROM Mobifix_DB.CUST_ADDRESS";
            var dtResult = MySqlCustomerAddressHelper.ExecuteQuery(fetchCustomerAddress);
            var customeraddress = FillCustomerAddressModel(dtResult);
            return customeraddress;

        }
        public int UpdateCustomerAddressStatus(Cust_Addr customeraddress)
        {
            string updateCustomerAddressInfo = $"UPDATE Mobifix_DB.CUST_ADDRESS SET ADDR_LINE1 = '{customeraddress.AddressLine1}' WHERE LOWER(CUST_ADDR_ID) = '{customeraddress.CustAddrID.ToString()}' ";
            return MySqlCustomerAddressHelper.ExecuteNonQuery(updateCustomerAddressInfo);
        }
        private IList<Cust_Addr> FillCustomerAddressModel(DataTable dtCustomerAddress)
        {
            var customeraddressList = new List<Cust_Addr>();
            if (null != dtCustomerAddress && dtCustomerAddress.Rows.Count > 0)
            {
                foreach (DataRow row in dtCustomerAddress.Rows)
                {
                    var customeraddress = new Cust_Addr();

                    customeraddress.CustAddrID = Convert.ToInt32(row["CUST_ADDR_ID"]);
                    customeraddress.CustID = Convert.ToInt32(row["FK_CUST_VEND_ADMIN_ID"]);
                    customeraddress.ContactAddrID = Convert.ToInt32(row["FK_CONTACT_TYPE_ID"]);
                    customeraddress.AddressLine1 = Convert.ToString(row["ADDR_LINE1"]);
                    customeraddress.AddressLine2 = Convert.ToString(row["ADDR_LINE2"]);
                    customeraddress.City = Convert.ToString(row["CITY"]);
                    customeraddress.State = Convert.ToString(row["STATE"]);
                    customeraddress.Country = Convert.ToString(row["COUNTRY"]);
                    customeraddress.ZIPCode = Convert.ToString(row["ZIP_CODE"]);
                    customeraddress.ContactStatusCD = Convert.ToString(row["FK_CONTACT_STATUS_CD"]);
                    customeraddress.ChangedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    customeraddress.ChangedByID = Convert.ToInt32(row["CREATED_BY"]);
                //    customeraddress.AddedDate = Convert.ToDateTime(row["LASTMODIFIED_DATE"]);
                   // customeraddress.AddByUserID = Convert.ToInt32(row["LASTMODIFIED_BY"]);
                    

                    customeraddressList.Add(customeraddress);
                }
            }
            return customeraddressList;
        }
        public int DeleteCustomerAddress(Cust_Addr customeraddress)
        {
            string updateCustomerAddressInfo = $"DELETE FROM Mobifix_DB.CUST_ADDRESS  WHERE LOWER(CUST_ADDR_ID) = '{customeraddress.CustAddrID.ToString()}' ";
            return MySqlCustomerAddressHelper.ExecuteNonQuery(updateCustomerAddressInfo);
        }
    }
}