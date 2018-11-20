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
    public class MobileOsController : ApiController
    {
        // GET: api/MobileOs
        public IHttpActionResult GetAllMobileOsTypes()
        {
            var moblieosRepo = new MobileOsRepository();
            var mobiletosypesList = moblieosRepo.GetAllMobileOsTypes();
            if (mobiletosypesList == null || mobiletosypesList.Count == 0)
            {
                return NotFound();
            }

            return Ok(mobiletosypesList);
        }

        // GET: api/MobileOs/5
        public IHttpActionResult GetMobileOsType(int MobileOSID, int MobileVersionTypeID)
        {
            var moblieosRepo = new MobileOsRepository();
            var mobileostype = moblieosRepo.GetMobileOsType(MobileOSID, MobileVersionTypeID);
            if (mobileostype == null)
            {
                return NotFound();
            }
            return Ok(mobileostype);
        }
        // PUT: api/Mobileos
        [HttpPut]
        public IHttpActionResult UpdateMobileOs([FromBody]MobileOs mobileos)
        {
            var mobileosRepo = new MobileOsRepository();
            var result = mobileosRepo.UpdateMobileOs(mobileos);
            if (result <= 0)
            {
                return Ok("Error occurred while updating Mobile Os Status");
            }
            return Ok("Mobile Os Status updated");

        }
    }
}
