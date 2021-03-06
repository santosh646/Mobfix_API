﻿using MobFix.Models;
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
        [HttpPost]
        public IHttpActionResult GetUser([FromBody]GetUser user)
        {
            var userRepo = new UserRepository();
            var getuser = userRepo.GetUser(user);
            
            if (getuser == null)
            {
                return NotFound();
            }
            return Ok(getuser);
        }

        // GET: api/User/5
        [HttpPost]
        public IHttpActionResult GetPassword([FromBody]GetPassword password)
        {
            var userRepo = new UserRepository();
            var getpassword = userRepo.GetPassword(password);

            if (getpassword == null)
            {
                return NotFound();
            }
            return Ok(getpassword);
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

        [HttpPost]
        public IHttpActionResult InsertUserRegistrationDetails([FromBody]User user)
        {
            var userRepo = new UserRepository();
            var result = userRepo.InsertUserRegistrationDetails(user);
            if (result <= 0)
            {
                return Ok("Error occurred while inserting the New User Registration Details");
            }
            return Ok("New User Registration Details Inserted");
        }

        [HttpPost]
        public IHttpActionResult getuserDetails([FromBody]GetUserDetails UserDetails)
        {
            var userRepo = new UserRepository();
            var result = userRepo.getuserDetails(UserDetails);
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        public IHttpActionResult UserNameStatus([FromBody]GetUser getuser)
        {
            var userRepo = new UserRepository();
            var result = userRepo.UserNameStatus(getuser);
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }



        [HttpPost]
        public IHttpActionResult resetPassword([FromBody]GetUser getuser)
        {
            var userRepo = new UserRepository();
            var result = userRepo.resetPassword(getuser);
            if (result == null || result.Count == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public IHttpActionResult UpdateUserStatus([FromBody]User user)
        {
            var userRepo = new UserRepository();
            var result = userRepo.UpdateUserStatus(user);
            if (result <= 0)
          //      if (result == null || result.Count == 0)
                {
                return NotFound();
            }
            return Ok(result);
        }

        // DELETE: api/User/Delete
        [HttpDelete]
        public void Delete(string Id)
        {
        }
    }
}
