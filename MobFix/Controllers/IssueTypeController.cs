﻿using MobFix.Models;
using MobFix.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobFix.Controllers
{
    public class IssueTypeController : ApiController
    {
        // GET: api/IssueType
        public IHttpActionResult GetAllIssueTypes()
        {
            var issuetypeRepo = new IssueTypeRepository();
            var issuetypesList = issuetypeRepo.GetAllIssueTypes();
            if (issuetypesList == null || issuetypesList.Count == 0)
            {
                return NotFound();
            }

            return Ok(issuetypesList);
        }

        // GET: api/IssueType/5
        public IHttpActionResult GetIssueType(int IssueTypeID, int IssuesTypeInd)
        {
            var issuetypeRepo = new IssueTypeRepository();
            var issuetype = issuetypeRepo.GetIssueType(IssueTypeID, IssuesTypeInd);
            if (issuetype == null)
            {
                return NotFound();
            }
            return Ok(issuetype);
        }

        [HttpPut]
        public IHttpActionResult UpdateIssueTypeStatus([FromBody]IssueType issuetype)
        {
            var issuetypeRepo = new IssueTypeRepository();
            var result = issuetypeRepo.UpdateIssueTypeStatus(issuetype);
            if (result <= 0)
            {
                return Ok("Error occurred while updating the issue type status");
            }
            return Ok("Issue Type Status updated");

        }
    }
}
