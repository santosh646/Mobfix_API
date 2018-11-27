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
    public class UserStatusController : ApiController
    {
        // GET: api/UserStatus
        public IHttpActionResult GetAllUserStatus()
        {
            var userstatusRepo = new UserStatusRepository();
            var userstatusList = userstatusRepo.GetAllUserStatus();
            if (userstatusList == null || userstatusList.Count == 0)
            {
                return NotFound();
            }
            return Ok(userstatusList);
        }

        // GET: api/UserStatus/5
        [HttpPost]
        public IHttpActionResult GetUserStatus([FromBody]User_Status userstatus)
        {
            var userstatusRepo = new UserStatusRepository();
            var getuserstatus = userstatusRepo.GetUserStatus(userstatus);
            if (getuserstatus == null)
            {
                return NotFound();
            }
            return Ok(getuserstatus);
        }
        
        [HttpPut]
        public IHttpActionResult UpdateUserStatus([FromBody]User_Status userstatus)
        {
            var userstatusRepo = new UserStatusRepository();
            var result = userstatusRepo.UpdateUserStatus(userstatus);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the user status");
            }
            return Ok("User Status updated");

        }

    }
}

