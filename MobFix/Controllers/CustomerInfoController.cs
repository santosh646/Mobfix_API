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
    public class CustomerInfoController : ApiController
    {
        // GET: api/CustomerInfo
        public IHttpActionResult GetAllCustomerInfos()
        {
            var custinfoRepo = new CustomerInfoRepository();
            var customerinfoList = custinfoRepo.GetAllCustomerInfos();
            if (customerinfoList == null || customerinfoList.Count == 0)
            {
                return NotFound();
            }

            return Ok(customerinfoList);
        }

        // GET: api/CustomerInfo/5
        public IHttpActionResult GetCustomerInfo(int CustInfoID, int CustVendorAdminID)
        {
            var custinfoRepo = new CustomerInfoRepository();
            var customerinfo = custinfoRepo.GetCustomerInfo(CustInfoID, CustVendorAdminID);
            if (customerinfo == null)
            {
                return NotFound();
            }
            return Ok(customerinfo);
        }

        [HttpPut]
        public IHttpActionResult UpdateCustomerInfoStatus([FromBody]Cust_Info customerinfo)
        {
            var custinfoRepo = new CustomerInfoRepository();
            var result = custinfoRepo.UpdateCustomerInfoStatus(customerinfo);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the Customer Info status");
            }
            return Ok("Customer Info Status updated");

        }
        [HttpDelete]
        public IHttpActionResult DeleteCustomerInfo([FromBody]Cust_Info customerinfo)
        {
            var customerinfoRepo = new CustomerInfoRepository();
            var result = customerinfoRepo.DeleteCustomerInfo(customerinfo);
            if (result <= 0)
            {
                return Ok("Error occurred while Deleting the customer info");
            }
            return Ok("Deleted Customer info");

        }
    }
}
