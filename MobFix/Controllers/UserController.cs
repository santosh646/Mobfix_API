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
    public class UserController : ApiController
    {
        // GET: api/User
        [HttpGet]
        public IHttpActionResult AllUsers()
        {
            var userRepo = new UserRepository();
            var userList = userRepo.GetAllUsers();
            if(userList == null || userList.Count ==0)
            {
                return NotFound();
            }

            return Ok(userList);
        }

        // GET: api/User/5
        public IHttpActionResult GetUser(string userName, string password)
        {
            var userRepo = new UserRepository();
            var user = userRepo.GetUser(userName, password);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        public void Post([FromBody]User user)
        {
            var userRepo = new UserRepository();

        }

        // PUT: api/User/5
        [HttpPut]
        public IHttpActionResult UpdateUserStatus([FromBody]User user)
        {
            var userRepo = new UserRepository();
            var result = userRepo.UpdateUserStatus(user);
            if(result <= 0)
            {
                return Ok("Error occurred while updating the user status");
            }
            return Ok("User Status updated");

        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
