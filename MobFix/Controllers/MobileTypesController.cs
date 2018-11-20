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
    public class MobileTypesController : ApiController
    {
        // GET: api/MobileTypes
        public IHttpActionResult GetAllMobileTypes()
        {
            var moblietypeRepo = new MobileTypesRepository();
            var mobiletypesList = moblietypeRepo.GetAllMobileTypes();
            if (mobiletypesList == null || mobiletypesList.Count == 0)
            {
                return NotFound();
            }

            return Ok(mobiletypesList);
        }

        // GET: api/MobileTypes/5
        public IHttpActionResult GetMobileType(int MobileCompanyID, string MobileCompDesc)
        {
            var moblietypeRepo = new MobileTypesRepository();
            var mobiletype = moblietypeRepo.GetMobileType(MobileCompanyID, MobileCompDesc);
            if (mobiletype == null)
            {
                return NotFound();
            }
            return Ok(mobiletype);
        }
        // PUT: api/MobileType
        [HttpPut]
        public IHttpActionResult UpdateMobileTypes([FromBody]MobileTypes mobiletypes)
        {
            var mobiletypesRepo = new MobileTypesRepository();
            var result = mobiletypesRepo.UpdateMobileTypes(mobiletypes);
            if (result <= 0)
            {
                return Ok("Error occurred while updating Mobile Type status");
            }
            return Ok("Mobile Type updated");

        }
    }
}
