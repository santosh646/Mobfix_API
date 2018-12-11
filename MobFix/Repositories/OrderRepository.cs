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
       // private object user;

        public getorder GetOrder(getorder getorder)
        {
           // string fetchOrder = $"SELECT * FROM Mobifix_DB.ORDER_TABLE WHERE LOWER ORDER_ID() = '{ OrderID.ToString() }'";
           string fetchOrder = $"SELECT * FROM Mobifix_DB.ORDER_TABLE WHERE LOWER (ORDER_ID) = '{ getorder.OrderID.ToString()}'";

            var dtResult = MySqlOrderHelper.ExecuteQuery(fetchOrder);
            var getorders = FillgetorderModel(dtResult);
            return getorders.FirstOrDefault<getorder>();
            
        }
        public Order getemailOrder(Order order)
        {
           // UPDATE Mobifix_DB.ORDER_TABLE SET FK_NOCONS_CUST_PHONE_ID = '{order.ContactPhoneID}' WHERE LOWER(ORDER_ID) = '{order.OrderID.ToString()}'
            //string fetchOrder = $"SELECT * FROM Mobifix_DB.ORDER_TABLE WHERE LOWER ORDER_ID() = '{ OrderID.ToString() }'";
            string fetchOrder = $"SELECT * FROM ORDER_TABLE ot INNER JOIN USER_TBL ut ON ut.CUST_VEND_ADMIN_ID=ot.FK_CUST_VEND_ADMIN_ID WHERE LOWER(LOGIN_ID) = '{order.LoginId.ToLowerInvariant()}' ";

            var dtResult = MySqlOrderHelper.ExecuteQuery(fetchOrder);
            var orderemail = FillOrderModel(dtResult);
            return orderemail.FirstOrDefault<Order>();

        }

        public IList<getAllorders> GetAllOrders()
        {
            //string fetchOrder = $"SELECT * FROM Mobifix_DB.ORDER_TABLE";
            string fetchOrder = $"SELECT CUST_VEND_ADMIN_ID, ORDER_ID, ORDER_PLACED_DATE, FULL_NAME, CONTACT_NUMBER, LOGIN_ID FROM USER_TBL u INNER JOIN ORDER_TABLE ot ON ot.FK_CUST_VEND_ADMIN_ID = u.CUST_VEND_ADMIN_ID INNER JOIN CUST_INFO ci ON ci.FK_CUST_VEND_ADMIN_ID = u.CUST_VEND_ADMIN_ID INNER JOIN CUST_PHONE cp ON cp.FK_CUST_VEND_ADMIN_ID = u.CUST_VEND_ADMIN_ID";
            var dtResult = MySqlOrderHelper.ExecuteQuery(fetchOrder);
            var order = FillgetAllordersModel(dtResult);
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
                    order.AssignedtoVendorID = Convert.ToInt32(row["ASSIGNED_TO_VENDOR_ID"]);
                    order.IssuesTypeID = Convert.ToInt32(row["FK_ISSUE_TYPE_ID"]);
                    order.IssueDetails = Convert.ToString(row["ISSUE_DTLS"]);
                    order.IEMI = Convert.ToString(row["IEMI"]);
                    order.MobileCompID = Convert.ToInt32(row["FK_MOBILE_CMPNY_ID"]);
                    order.MobileVersionTypeID = Convert.ToInt32(row["FK_MOBILE_VER_TYPE_ID"]);
                    order.InitialQuote = Convert.ToInt32(row["INITIAL_QUOTE"]);
                    order.EstimatedQuote = Convert.ToInt32(row["ESTIMATED_QUOTE"]);
                    order.FinalCost = Convert.ToInt32(row["FINAL_COST"]);

                    orderList.Add(order);
                }
            }
            return orderList;
        }

        private IList<getorder> FillgetorderModel(DataTable dtOrders)
        {
            var getorderList = new List<getorder>();
            if (null != dtOrders && dtOrders.Rows.Count > 0)
            {
                foreach (DataRow row in dtOrders.Rows)
                {

                    var order = new getorder();
                    order.OrderID = Convert.ToInt32(row["ORDER_ID"]);
                    order.CustVendorAdminID = Convert.ToInt32(row["FK_CUST_VEND_ADMIN_ID"]);
                    order.AssignedtoVendorID = Convert.ToInt32(row["ASSIGNED_TO_VENDOR_ID"]);
                    order.IssuesTypeID = Convert.ToInt32(row["FK_ISSUE_TYPE_ID"]);
                    order.IssueDetails = Convert.ToString(row["ISSUE_DTLS"]);
                    order.IEMI = Convert.ToString(row["IEMI"]);
                    order.MobileCompID = Convert.ToInt32(row["FK_MOBILE_CMPNY_ID"]);
                    order.MobileVersionTypeID = Convert.ToInt32(row["FK_MOBILE_VER_TYPE_ID"]);
                    order.InitialQuote = Convert.ToInt32(row["INITIAL_QUOTE"]);
                    order.EstimatedQuote = Convert.ToInt32(row["ESTIMATED_QUOTE"]);
                    order.FinalCost = Convert.ToInt32(row["FINAL_COST"]);
                    order.OrderPlacedDate = Convert.ToDateTime(row["ORDER_PLACED_DATE"]);
                    order.EstimatedTimetoDeliver = Convert.ToDateTime(row["ESTIMIATED_DATE_OF_DELIVER"]);

                    
                    UserStatus userStatus;
                    if (Enum.TryParse<UserStatus>(row["ORDER_ID"].ToString(), out userStatus))
                    {
                        
                        order.OrderID = Convert.ToInt32(row["ORDER_ID"]);
                    }
                    getorderList.Add(order);
                }
            }
            return getorderList;
        }


        private IList<getAllorders> FillgetAllordersModel(DataTable dtUsers)
        {
            var userList = new List<getAllorders>();
            if (null != dtUsers && dtUsers.Rows.Count > 0)
            {
                foreach (DataRow row in dtUsers.Rows)
                {
                    var user = new getAllorders();

                    //CUST_VEND_ADMIN_ID, ORDER_ID, ORDER_PLACED_DATE, FULL_NAME, CONTACT_NUMBER, LOGIN_ID

                    user.customeradminid = Convert.ToInt32(row["CUST_VEND_ADMIN_ID"]);
                    user.OrderID = Convert.ToInt32(row["ORDER_ID"]);
                    user.OrderPlacedDate = Convert.ToDateTime(row["ORDER_PLACED_DATE"]);
                    user.fullname = Convert.ToString(row["FULL_NAME"]);
                    user.ContactNumber = Convert.ToString(row["CONTACT_NUMBER"]);
                    user.LoginId = row["LOGIN_ID"].ToString();


                    //user.Add(user);

                    //UserType userType;
                    //if (Enum.TryParse<UserType>(row["FK_USER_TYPE_ID"].ToString(), out userType))
                    //{
                    //    user.UserType = userType.ToString();
                    //}
                    //user.NoOfAttempts = Convert.ToInt32(row["NUM_OF_FAILED_ATTEMPTS"]);
                    // user.LastLoginDate = Convert.ToDateTime(row["LAST_LOGIN_DT"]);
                    UserStatus userStatus;
                    if (Enum.TryParse<UserStatus>(row["ORDER_ID"].ToString(), out userStatus))
                    {
                        //need to fix
                        user.OrderID = Convert.ToInt32(row["ORDER_ID"]);
                    }
                    userList.Add(user);
                }
            }
            return userList;
        }
    }
}
   