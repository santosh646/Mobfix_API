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
    public class ContactTypeController : ApiController
    {
        // GET: api/ContactType
        public IHttpActionResult GetAllContactTypes()
        {
            var contacttypeRepo = new ContactTypeRepository();
            var contacttypeList = contacttypeRepo.GetAllContactTypes();
            if (contacttypeList == null || contacttypeList.Count == 0)
            {
                return NotFound();
            }

            return Ok(contacttypeList);
        }

        // GET: api/ContactType/5
        public IHttpActionResult GetContactType(int ContactTypeID, string ContactTypeDescription)
        {
            var contacttypeRepo = new ContactTypeRepository();
            var contacttype = contacttypeRepo.GetContactType(ContactTypeID, ContactTypeDescription);
            if (contacttype == null)
            {
                return NotFound();
            }
            return Ok(contacttype);
        }
        [HttpPut]
        public IHttpActionResult UpdateContactTypeStatus([FromBody]ContactType contacttype)
        {
            var contacttypeRepo = new ContactTypeRepository();
            var result = contacttypeRepo.UpdateContactTypeStatus(contacttype);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the contact type status");
            }
            return Ok("Contact Type Status updated");

        }
    }
}
