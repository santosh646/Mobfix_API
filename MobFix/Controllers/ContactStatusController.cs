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
    public class ContactStatusController : ApiController
    {
        // GET: api/ContactStatus
        public IHttpActionResult GetAllContactStatus()
        {
            var contactstatusRepo = new ContactStatusRepository();
            var contactstatusList = contactstatusRepo.GetAllContactStatus();
            if (contactstatusList == null || contactstatusList.Count == 0)
            {
                return NotFound();
            }

            return Ok(contactstatusList);
        }

        // GET: api/ContactStatus/5
        [HttpPost]
        public IHttpActionResult GetContactStatus([FromBody]ContactStatus contactStatus)
        {
            var contactstatusRepo = new ContactStatusRepository();
            var getContactStatus = contactstatusRepo.GetContactStatus(contactStatus);
            if (getContactStatus == null)
            {
                return NotFound();
            }
            return Ok(getContactStatus);
        }

        // PUT: api/ContactStatus/5
        [HttpPut]
        public IHttpActionResult UpdateContactStatus([FromBody]ContactStatus contactstatus)
        {
            var contactstatusRepo = new ContactStatusRepository();
            var result = contactstatusRepo.UpdateContactStatus(contactstatus);
            if (result <= 0)

           {
                return Ok("Error occurred while updating the contact type status");
            }
            return Ok("Contact Status updated");
        }
        /*[HttpDelete]
        public IHttpActionResult DeleteContactStatus([FromBody]ContactStatus contactstatus)
        {
            var contactstatusRepo = new ContactStatusRepository();
            var result = contactstatusRepo.DeleteContactStatus(contactstatus);
            if (result <= 0)
            {
                return Ok("Error occurred while Deleting the contact status");
            }
            return Ok("Deleted Contact status");

        }*/
    }
}
