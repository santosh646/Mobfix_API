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

    }
}
