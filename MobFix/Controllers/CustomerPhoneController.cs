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
    public class CustomerPhoneController : ApiController
    {
        // GET: api/CustomerPhone
        public IHttpActionResult GetAllCustomerPhones()
        {
            var custphoneRepo = new CustomerPhoneRepository();
            var customerphoneList = custphoneRepo.GetAllCustomerPhones();
            if (customerphoneList == null || customerphoneList.Count == 0)
            {
                return NotFound();
            }

            return Ok(customerphoneList);
        }

        // GET: api/CustomerPhone/5
        public IHttpActionResult GetCustomerPhone(int CustPhoneID, int CustID)
        {
            var custphoneRepo = new CustomerPhoneRepository();
            var customerphone = custphoneRepo.GetCustomerPhone(CustPhoneID, CustID);
            if (customerphone == null)
            {
                return NotFound();
            }
            return Ok(customerphone);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomerPhoneStatus([FromBody]Cust_Phone customerphone)
        {
            var customerphoneRepo = new CustomerPhoneRepository();
            var result = customerphoneRepo.UpdateCustomerPhoneStatus(customerphone);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the Customer Phone status");
            }
            return Ok("Customer Phone Status updated");

        }
    }
}
