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
    public class MobileVersionController : ApiController
    {
        // GET: api/MobileVersion
        public IHttpActionResult GetAllMobileVersions()
        {
            var moblieversionRepo = new MobileVersionRepository();
            var mobileversiontypesList = moblieversionRepo.GetAllMobileVersions();
            if (mobileversiontypesList == null || mobileversiontypesList.Count == 0)
            {
                return NotFound();
            }

            return Ok(mobileversiontypesList);
        }

        // GET: api/MobileVersion/5
        [HttpPost]
        public IHttpActionResult GetMobileVersion([FromBody]MobileVersion mobileversion )
        {
            var moblieversionRepo = new MobileVersionRepository();
            var getmobileversiontype = moblieversionRepo.GetMobileVersion(mobileversion);
            if (getmobileversiontype == null)
            {
                return NotFound();
            }
            return Ok(getmobileversiontype);
        }
        // PUT: api/Mobileversion
        [HttpPut]
        public IHttpActionResult UpdateMobileVersion([FromBody]MobileVersion mobileversion)
        {
            var mobileversionRepo = new MobileVersionRepository();
            var result = mobileversionRepo.UpdateMobileVersion(mobileversion);
            if (result <= 0)
            {
                return Ok("Error occurred while updating Mobile Version Status");
            }
            return Ok("Mobile version description updated");

        }
    }
}
