using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class OrderRepository
    {
        MySqlOrderHelper MySqlOrderHelper = new MySqlOrderHelper();


        public Order GetOrder(int OrderID, int CustVendorAdminID)
        {
            string fetchOrder = $"SELECT * FROM Mobifix_DB.ORDER_TABLE WHERE LOWER ORDER_ID() = '{ OrderID.ToString() }'";
            var dtResult = MySqlOrderHelper.ExecuteQuery(fetchOrder);
            var order = FillOrderModel(dtResult);
            return order.FirstOrDefault<Order>();

        }

        public IList<Order> GetAllOrders()
        {
            string fetchOrder = $"SELECT * FROM Mobifix_DB.ORDER_TABLE";
            var dtResult = MySqlOrderHelper.ExecuteQuery(fetchOrder);
            var order = FillOrderModel(dtResult);
            return order;
        }
        public int UpdateOrderStatus(Order order)
        {
            string updateOrderInfo = $"UPDATE Mobifix_DB.ORDER_TABLE SET FK_NOCONS_CUST_PHONE_ID  = '{order.ContactPhoneID}' WHERE LOWER(ORDER_ID) = '{order.OrderID.ToString()}' ";
            return MySqlOrderHelper.ExecuteNonQuery(updateOrderInfo);
        }

        public int InsertOrderDetails(Order order)
        {
            string InsertOrderInfo = $"INSERT INTO Mobifix_DB.USER_TBL(FK_USER_TYPE_ID, LOGIN_ID, LOGIN_PWD, NUM_OF_FAILED_ATTEMPTS, LAST_LOGIN_DT, FK_USER_STATUS_CD, CREATED_DATE, CREATED_BY, LASTMODIFIED_DATE, LASTMODIFIED_BY)" +
                 $" VALUES({order.UserType}, '{order.LoginId}', '{order.Password}', {order.NoOfAttempts},  NOW(), '{order.UserStatus}', NOW(), {order.CrearedBy},NOW(), {order.LastUpdateBy});";

            InsertOrderInfo += $"INSERT INTO Mobifix_DB.ORDER_TABLE(FK_CUST_VEND_ADMIN_ID, ASSIGNED_TO_VENDOR_ID, FK_ISSUE_TYPE_ID, ISSUE_DTLS, IEMI, FK_MOBILE_CMPNY_ID, FK_MOBILE_VER_TYPE_ID, FK_NOCONS_MOBILE_OS_TYPE_ID, FK_CUST_INFO_ID, FK_CUST_ADDR_ID, FK_NOCONS_CUST_PHONE_ID, INITIAL_QUOTE, ESTIMATED_QUOTE, FINAL_COST, ORDER_PLACED_DATE, ESTIMIATED_DATE_OF_DELIVER) " +
                 $"Select LAST_INSERT_ID(), {order.AssignedtoVendorID}, {order.IssuesTypeID},'{order.IssueDetails}', '{order.IEMI}', {order.MobileCompID}, {order.MobileVersionTypeID}, {order.MobileOSID}, {order.CustDemoID}, {order.ContactAddrID}, {order.ContactPhoneID}, {order.InitialQuote}, {order.EstimatedQuote}, {order.FinalCost}, NOW(), NOW()";
             return MySqlOrderHelper.ExecuteNonQuery(InsertOrderInfo);
        }
        private IList<Order> FillOrderModel(DataTable dtOrders)
        {
            var orderList = new List<Order>();
            if (null != dtOrders && dtOrders.Rows.Count > 0)
            {
                foreach (DataRow row in dtOrders.Rows)
                {
                    var order = new Order();
                    order.OrderID = Convert.ToInt32(row["ORDER_ID"]);
                    order.CustVendorAdminID = Convert.ToInt32(row["FK_CUST_VEND_ADMIN_ID"]);
                    order.OrderPlacedDate = Convert.ToDateTime(row["ORDER_PLACED_DATE"]);
                    order.ContactPhoneID = Convert.ToInt32(row["FK_NOCONS_CUST_PHONE_ID"]);
                    orderList.Add(order);
                }
            }
            return orderList;
        }
    }
}