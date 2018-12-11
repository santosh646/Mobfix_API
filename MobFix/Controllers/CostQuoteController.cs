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
    public class CostQuoteController : ApiController
    {
        // GET: api/CostQuote
        public IHttpActionResult GetAllCostQuotes()
        {
            var costquoteRepo = new CostQuoteRepository();
            var costquoteList = costquoteRepo.GetAllCostQuotes();
            if (costquoteList == null || costquoteList.Count == 0)
            {
                return NotFound();
            }

            return Ok(costquoteList);
        }

        // GET: api/CostQuote/5
        [HttpPost]
        public IHttpActionResult GetCostQuote([FromBody]Cost_Quote costquote)
        {
            var costquoteRepo = new CostQuoteRepository();
            var getcostquote = costquoteRepo.GetCostQuote(costquote);
            if (getcostquote == null)
            {
                return NotFound();
            }
            return Ok(getcostquote);
        }
        // PUT: api/CostQuote
        [HttpPut]
        public IHttpActionResult UpdateCostQuote([FromBody]Cost_Quote costquote)
        {
            var costRepo = new CostQuoteRepository();
            var result = costRepo.UpdateCostQuote(costquote);
            if (result <= 0)
            {
                return Ok("Error occurred while updating cost quote");
            }
            return Ok("Cost Quote updated");

        }
        [HttpDelete]
        public IHttpActionResult DeleteCostQuote([FromBody]Cost_Quote costquote)
        {
            var costquoteRepo = new CostQuoteRepository();
            var result = costquoteRepo.DeleteCostQuote(costquote);
            if (result <= 0)
            {
                return Ok("Error occurred while Deleting the contact type status");
            }
            return Ok("Deleted Contact Type status");

        }

    }
}
