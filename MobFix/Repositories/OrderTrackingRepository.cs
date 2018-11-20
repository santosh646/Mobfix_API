using MobFix.Helper;
using MobFix.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace MobFix.Repositories
{
    public class OrderTrackingRepository
    {
        MySqlOrderTrackingHelper MySqlOrderTrackingHelper = new MySqlOrderTrackingHelper();


        public Order_Tracking GetOrderTracker(int OrdertrackingID, int orderID)
        {
            string fetchOrderTracker = $"SELECT * FROM Mobifix_DB.ORDER_TRACKING WHERE LOWER ORDER_TRACKING_ID() = '{ OrdertrackingID.ToString() }'";
            var dtResult = MySqlOrderTrackingHelper.ExecuteQuery(fetchOrderTracker);
            var ordertracker = FillOrderTrackingModel(dtResult);
            return ordertracker.FirstOrDefault<Order_Tracking>();

        }

        public IList<Order_Tracking> GetAllOrderTrackers()
        {
            string fetchOrderTracker = $"SELECT * FROM Mobifix_DB.ORDER_TRACKING";
            var dtResult = MySqlOrderTrackingHelper.ExecuteQuery(fetchOrderTracker);
            var ordertracker = FillOrderTrackingModel(dtResult);
            return ordertracker;

        }

        public int UpdateOrderTrackingStatus(Order_Tracking ordertracker)
        {
            string updateOrderTrackingInfo = $"UPDATE Mobifix_DB.ORDER_TRACKING SET FK_ORDER_STATUS_ID = '{ordertracker.ORDERSTATUSID}' WHERE LOWER(ORDER_TRACKING_ID) = '{ordertracker.OrderTrackingID.ToString()}' ";
            return MySqlOrderTrackingHelper.ExecuteNonQuery(updateOrderTrackingInfo);
        }


        private IList<Order_Tracking> FillOrderTrackingModel(DataTable dtOrderTrackers)
        {
            var ordertrackerList = new List<Order_Tracking>();
            if (null != dtOrderTrackers && dtOrderTrackers.Rows.Count > 0)
            {
                foreach (DataRow row in dtOrderTrackers.Rows)
                {
                    var ordertracker = new Order_Tracking();
                    ordertracker.OrderTrackingID = Convert.ToInt32(row["ORDER_TRACKING_ID"]);
                    ordertracker.OrderFKId = Convert.ToInt32(row["FK_ORDER_ID"]);
                    ordertracker.ORDERSTATUSID = Convert.ToInt32(row["FK_ORDER_STATUS_ID"]);
                    ordertrackerList.Add(ordertracker);
                }
            }
            return ordertrackerList;
        }
    }
}