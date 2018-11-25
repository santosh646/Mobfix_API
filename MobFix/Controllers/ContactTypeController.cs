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
        [HttpPost]
        public IHttpActionResult GetContactType([FromBody]ContactType contactType)
        {
            var contacttypeRepo = new ContactTypeRepository();
            var getcontacttype = contacttypeRepo.GetContactType(contactType);
            if (getcontacttype == null)
            {
                return NotFound();
            }
            return Ok(getcontacttype);
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
