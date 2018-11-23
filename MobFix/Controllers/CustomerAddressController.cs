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
    public class CustomerAddressController : ApiController
    {
        // GET: api/CustomerAddress
        public IHttpActionResult GetAllCustomerAddrresses()
        {
            var custaddressRepo = new CustomerAddressRepository();
            var customeraddressList = custaddressRepo.GetAllCustomerAddresses();
            if (customeraddressList == null || customeraddressList.Count == 0)
            {
                return NotFound();
            }

            return Ok(customeraddressList);
        }

        // GET: api/CustomerAddress/5
        public IHttpActionResult GetCustomerAddress(int CustAddrID, int CustID)
        {
            var custaddressRepo = new CustomerAddressRepository();
            var customeraddress = custaddressRepo.GetCustomerAddress(CustAddrID, CustID);
            if (customeraddress == null)
            {
                return NotFound();
            }
            return Ok(customeraddress);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomerAddressStatus([FromBody]Cust_Addr customeraddress)
        {
            var custaddressRepo = new CustomerAddressRepository();
            var result = custaddressRepo.UpdateCustomerAddressStatus(customeraddress);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the Customer Address status");
            }
            return Ok("Customer Address Status updated");

        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomerAddress([FromBody]Cust_Addr customeraddress)
        {
            var customeraddressRepo = new CustomerAddressRepository();
            var result = customeraddressRepo.DeleteCustomerAddress(customeraddress);
            if (result <= 0)
            {
                return Ok("Error occurred while Deleting the Customer address");
            }
            return Ok("Deleted Customer address");

        }
    }
}
