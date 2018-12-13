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
    public class VendorController : ApiController
    {
        [HttpPost]
        public IHttpActionResult InsertVendorRegistrationDetails([FromBody]Vendor vendor)
       {
            var vendorRepo = new VendorRepository();
            var result = vendorRepo.InsertVendorRegistrationDetails(vendor);
            if (result <= 0)
            {
                return Ok("Error occurred while inserting the New Vendor Registration Details");
            }
            return Ok("New Vendor Registration Details Inserted");
        }
        // GET: api/User/5
        [HttpPost]
        public IHttpActionResult GetVendorPassword([FromBody]GetVendorPassword getpassword)
        {
            var vendorRepo = new VendorRepository();
            var getvendorpassword = vendorRepo.GetVendorPassword(getpassword);


            if (getvendorpassword == null)
            {
                return NotFound();
            }
            return Ok(getvendorpassword);
        }

        [HttpPost]
        public IHttpActionResult InsertVendorDetails([FromBody]Vendor vendor)
        {
            var vendorRepo = new VendorRepository();
            var result = vendorRepo.InsertVendorDetails(vendor);
            if (result <= 0)
            {
                return Ok("Error occurred while inserting the New Vendor Details");
            }
            return Ok("New Vendor Details inserted");

        }
    }
}
