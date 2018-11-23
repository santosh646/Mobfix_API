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
    public class OrderController : ApiController
    {
        // GET: api/Order
        public IHttpActionResult GetAllOrders()
        {
            var orderRepo = new OrderRepository();
            var orderList = orderRepo.GetAllOrders();
            if (orderList == null || orderList.Count == 0)
            {
                return NotFound();
            }

            return Ok(orderList);
        }

        // GET: api/Order/5
        public IHttpActionResult GetOrder(int OrderID, int CustVendorAdminID)
        {
            var orderRepo = new OrderRepository();
            var order = orderRepo.GetOrder(OrderID, CustVendorAdminID);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // GET: api/Order/testAdmin1@gmail.com  
        public IHttpActionResult GetOrder(String emailid)
        {
            var orderRepo = new OrderRepository();
            var order = orderRepo.GetemailOrder(emailid);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        [HttpPost]
        public IHttpActionResult InsertOrderDetails([FromBody]Order order)
        {
            var orderRepo = new OrderRepository();
            var result = orderRepo.InsertOrderDetails(order);
            if (result <= 0)
            {
                return Ok("Error occurred while inserting the New Order Details");
            }
            return Ok("New Order Details Inserted Successfully.");
        }
        [HttpPut]
        public IHttpActionResult UpdateOrderStatus([FromBody]Order order)
        {
            var orderRepo = new OrderRepository();
            var result = orderRepo.UpdateOrderStatus(order);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the order status");
            }
            return Ok("Order Status Updated");
        }
    }
}
