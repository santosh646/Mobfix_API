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


        public OrderStatus GetOrderStatus(OrderStatus orderstatus)
        {
            string fetchOrderStatus = $"SELECT * FROM Mobifix_DB.ORDER_STATUS WHERE LOWER (ORDER_STATUS_ID) = '{ orderstatus.OrderStatusID.ToString() }'";
            var dtResult = MySqlOrderStatusHelper.ExecuteQuery(fetchOrderStatus);
            var getorderstatus = FillOrderStatusModel(dtResult);
            return getorderstatus.FirstOrDefault<OrderStatus>();

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
    }
}