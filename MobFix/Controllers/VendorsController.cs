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
    public class VendorsController : ApiController
    {
        [HttpPost]
        public IHttpActionResult InsertVendorDetails([FromBody]Vendors vendor)
        {
            var vendorsRepo = new VendorsRepository();
            var result = vendorsRepo.InsertVendorDetails(vendor);
            if (result <= 0)
            {
                return Ok("Error occurred while inserting the New Vendor Details");
            }
            return Ok("New Vendor Details inserted");
        }


    }
}
