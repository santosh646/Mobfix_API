using MobFix.Models;
using MobFix.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobFix.Controllers
{
    public class UserController : ApiController
    {
        // GET: api/User
        public IHttpActionResult GetAllUsers()
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

        [HttpPost]
        public IHttpActionResult InsertUserDetails([FromBody]User user)
        {
            var userRepo = new UserRepository();
            var result = userRepo.InsertUserDetails(user);
            if (result <= 0)
            {
                return Ok("Error occurred while inserting the New User Details");
            }
            return Ok("New User Details inserted");
        }

        [HttpPut]
        public IHttpActionResult UpdateUserStatus([FromBody]User user)
        {
            var userRepo = new UserRepository();
            var result = userRepo.UpdateUserStatus(user);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the user status");
            }
            return Ok("User Status updated");
        }

        // DELETE: api/User/Delete
        public void Delete(string Id)
        {
        }
    }
}
