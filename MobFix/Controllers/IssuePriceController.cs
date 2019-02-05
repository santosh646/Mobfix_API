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
    public class IssuePriceController : ApiController
    {
        [HttpPost] 
        public IHttpActionResult GetIssueprice([FromBody]IssuePrice issueprice)
        {
            var issuepriceRepo = new IssuePriceRepository();
            var getissueprice = issuepriceRepo.GetIssuePrice(issueprice);
            if (getissueprice == null)
            {
                return NotFound();
            }
            return Ok(getissueprice);
        }
    }
}