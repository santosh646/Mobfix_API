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

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
