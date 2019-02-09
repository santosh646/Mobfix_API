using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MobFix.Repositories
{
    public class OrderStatusRepository
    {
        MySqlOrderStatusHelper MySqlOrderStatusHelper = new MySqlOrderStatusHelper();


        //public OrderStatus GetOrderStatus(OrderStatus orderstatus)
        //{
        //    string fetchOrderStatus = $"SELECT * FROM Mobifix_DB.ORDER_STATUS WHERE LOWER (ORDER_STATUS_ID) = '{ orderstatus.OrderStatusID.ToString() }'";
            
        //    var dtResult = MySqlOrderStatusHelper.ExecuteQuery(fetchOrderStatus);
        //    var getorderstatus = FillOrderStatusModel(dtResult);
        //    return getorderstatus.FirstOrDefault<OrderStatus>();

        //}
        public OrderStatus1 GetOrderStatus(OrderStatus1 orderstatus)
        {
            //string fetchOrderStatus = $"SELECT * FROM Mobifix_DB.ORDER_STATUS WHERE LOWER (ORDER_STATUS_ID) = '{ orderstatus.OrderStatusID.ToString() }'";
            string fetchOrderStatus = $"SELECT ORDER_ID, ORDER_PLACED_DATE, ESTIMIATED_DATE_OF_DELIVER, ORDER_STATUS_DESC FROM Mobifix_DB.ORDER_TABLE ot INNER JOIN ORDER_STATUS os ON ot.ORDER_ID = os.FK_ORDER_ID WHERE LOWER (ORDER_ID) = '{ orderstatus.OrderID.ToString() }'";

            var dtResult = MySqlOrderStatusHelper.ExecuteQuery(fetchOrderStatus);
            var getorderstatus = FillOrderStatus1Model(dtResult);
            return getorderstatus.FirstOrDefault<OrderStatus1>();

        }

        public IList<OrderStatus> GetAllOrderStatus()
        {
            string fetchOrderStatus = $"SELECT * FROM Mobifix_DB.ORDER_STATUS";
            var dtResult = MySqlOrderStatusHelper.ExecuteQuery(fetchOrderStatus);
            var orderstatus = FillOrderStatusModel(dtResult);
            return orderstatus;

        }
        public int UpdateOrderstatusStatus(OrderStatus orderstatus)
        {
            string updateOrderStatusInfo = $"UPDATE Mobifix_DB.ORDER_STATUS SET ORDER_STATUS_DESC = '{orderstatus.Orderstatus}' WHERE LOWER(ORDER_STATUS_ID) = '{orderstatus.OrderStatusID.ToString()}' ";
            return MySqlOrderStatusHelper.ExecuteNonQuery(updateOrderStatusInfo);
        }

        private IList<OrderStatus> FillOrderStatusModel(DataTable dtOrderStatus)
        {
            var orderstatusList = new List<OrderStatus>();
            if (null != dtOrderStatus && dtOrderStatus.Rows.Count > 0)
            {
                foreach (DataRow row in dtOrderStatus.Rows)
                {
                    var orderstatus = new OrderStatus();
                    orderstatus.OrderStatusID = Convert.ToInt32(row["ORDER_STATUS_ID"]);
                    OrderStatusDesc OrderStatus;
                    if (Enum.TryParse<OrderStatusDesc>(row["ORDER_STATUS_DESC"].ToString(), out OrderStatus))
                    {
                        orderstatus.Orderstatus = OrderStatus.ToString();
                    }
                    orderstatus.Orderstatus = Convert.ToString(row["ORDER_STATUS_DESC"]);
                    orderstatus.OderStausInd = Convert.ToString(row["ORDER_STATUS_IND"]);
                    orderstatus.CreatedDate = Convert.ToDateTime(row["CREATED_DATE"]);
                    orderstatus.CreatedBy = Convert.ToInt32(row["CREATED_BY"]);
                    orderstatusList.Add(orderstatus);
                }
            }
            return orderstatusList;
        }
        private IList<OrderStatus1> FillOrderStatus1Model(DataTable dtOrderStatus1)
        {
            var orderstatus1List = new List<OrderStatus1>();
            if (null != dtOrderStatus1 && dtOrderStatus1.Rows.Count > 0)
            {
                foreach (DataRow row in dtOrderStatus1.Rows)
                {
                    var orderstatus1 = new OrderStatus1();
                    orderstatus1.OrderID = Convert.ToInt32(row["ORDER_ID"]);
                    OrderStatusDesc OrderStatus1;
                    if (Enum.TryParse<OrderStatusDesc>(row["ORDER_STATUS_DESC"].ToString(), out OrderStatus1))
                    {
                        orderstatus1.OrderstatusDesc = OrderStatus1.ToString();
                    }
                    orderstatus1.OrderstatusDesc = Convert.ToString(row["ORDER_STATUS_DESC"]);
                    orderstatus1.OrderDate = Convert.ToDateTime(row["ORDER_PLACED_DATE"]);
                    orderstatus1.ExpectedDate = Convert.ToDateTime(row["ESTIMIATED_DATE_OF_DELIVER"]);
                    orderstatus1List.Add(orderstatus1);
                }
            }
            return orderstatus1List;
        }
    }
}