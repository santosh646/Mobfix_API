using MobFix.Models;
using MobFix.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobFix.Controllers
{
    public class OrderTrackingController : ApiController
    {
        // GET: api/OrderTracking
        public IHttpActionResult GetAllOrderTrackers()
        {
            var ordertrackerRepo = new OrderTrackingRepository();
            var ordertrackerList = ordertrackerRepo.GetAllOrderTrackers();
            if (ordertrackerList == null || ordertrackerList.Count == 0)
            {
                return NotFound();
            }

            return Ok(ordertrackerList);
        }

        // GET: api/OrderTracking/5
        [HttpPost]
        public IHttpActionResult GetOrderTracker(Order_Tracking ordertracking)
        {
            var ordertrackerRepo = new OrderTrackingRepository();
            var getordertracker = ordertrackerRepo.GetOrderTracker(ordertracking);
            if (getordertracker == null)
            {
                return NotFound();
            }
            return Ok(getordertracker);
        }

        [HttpPut]
        public IHttpActionResult UpdateOrderTrackingStatus([FromBody]Order_Tracking ordertracker)
        {
            var ordertrackerRepo = new OrderTrackingRepository();
            var result = ordertrackerRepo.UpdateOrderTrackingStatus(ordertracker);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the order tracking status");
            }
            return Ok("Order Tracking Status Updated");
        }
    }
}
