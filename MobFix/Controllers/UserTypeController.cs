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
        

        [HttpPost]
        public IHttpActionResult GetUserType([FromBody]UserTypes usertype)
        {
            var usertypeRepo = new UserTypesRepository();
            var getusertype = usertypeRepo.GetUserType(usertype);
            if (getusertype == null)
            {
                return NotFound();
            }
            return Ok(getusertype);
        }

        [HttpPost]
        public IHttpActionResult InsertUserRegistrationDetails([FromBody]UserTypes usertype)
        {
            var usertypeRepo = new UserTypesRepository();
            var result = usertypeRepo.InsertUserRegistrationDetails(usertype);
            if (result <= 0)
            {
                return Ok("Error occurred while inserting the New User Registration Details");
            }
            return Ok("New User Registration Details Inserted");
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
