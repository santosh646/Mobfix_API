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
    public class UserTypeController : ApiController
    {
        // GET: api/UserType
        public IHttpActionResult GetAllUserTypes()
        {
            var usertypeRepo = new UserTypesRepository();
            var usertypesList = usertypeRepo.GetAllUserTypes();
            if (usertypesList == null || usertypesList.Count == 0)
            {
                return NotFound();
            }

            return Ok(usertypesList);
        }

        // GET: api/UserType/5
        public IHttpActionResult GetUserType(int UserTypeID, string UserRole)
        {
            var usertypeRepo = new UserTypesRepository();
            var usertype = usertypeRepo.GetUserType(UserTypeID, UserRole);
            if (usertype == null)
            {
                return NotFound();
            }
            return Ok(usertype);
        }

        [HttpPut]
        public IHttpActionResult UpdateUserTypeStatus([FromBody]UserTypes usertype)
        {
            var usertypeRepo = new UserTypesRepository();
            var result = usertypeRepo.UpdateUserTypeStatus(usertype);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the user type status");
            }
            return Ok("User Type Status updated");

        }

    }
}
