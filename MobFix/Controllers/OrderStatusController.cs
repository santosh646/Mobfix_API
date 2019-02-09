using MobFix.Models;
using MobFix.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobFix.Controllers
{
    public class OrderStatusController : ApiController
    {
        // GET: api/OrderStatus
        public IHttpActionResult GetAllOrderStatus()
        {
            var orderstatusRepo = new OrderStatusRepository();
            var orderstatusList = orderstatusRepo.GetAllOrderStatus();
            if (orderstatusList == null || orderstatusList.Count == 0)
            {
                return NotFound();
            }

            return Ok(orderstatusList);
        }

        // GET: api/OrderStatus/5
        //[HttpPost]
        //public IHttpActionResult GetOrderStatus(OrderStatus orderstatus )
        //{
        //    var orderstatusRepo = new OrderStatusRepository();
        //    var getorderstatus = orderstatusRepo.GetOrderStatus(orderstatus);
        //    if (getorderstatus == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(getorderstatus);
        //}
        // GET: api/OrderStatus/5
        [HttpPost]
        public IHttpActionResult GetOrderStatus(OrderStatus1 orderstatus)
        {
            var orderstatusRepo = new OrderStatusRepository();
            var getorderstatus = orderstatusRepo.GetOrderStatus(orderstatus);
            if (getorderstatus == null)
            {
                return NotFound();
            }
            return Ok(getorderstatus);
        }

        [HttpPut]
        public IHttpActionResult UpdateOrderstatusStatus([FromBody]OrderStatus orderstatus)
        {
            var orderstatusRepo = new OrderStatusRepository();
            var result = orderstatusRepo.UpdateOrderstatusStatus(orderstatus);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the order status");
            }
            return Ok("Order Status Updated");
        }
    }
}
