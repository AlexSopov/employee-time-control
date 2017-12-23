using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeTimeControl.Data.AccessLayer;
using EmployeeTimeControl.Data.Models;

namespace EmployeeTimeControl.API.Controllers
{
    public class VisitingRulesController : ApiController
    {
        private EmployeeTimeControlDataContext db = new EmployeeTimeControlDataContext();

        // GET: api/VisitingRules
        public IQueryable<VisitingRule> GetVisitingRuleSet()
        {
            return db.VisitingRuleSet;
        }

        // GET: api/VisitingRules/5
        [ResponseType(typeof(VisitingRule))]
        public IHttpActionResult GetVisitingRule(int id)
        {
            VisitingRule visitingRule = db.VisitingRuleSet.Find(id);
            if (visitingRule == null)
            {
                return NotFound();
            }

            return Ok(visitingRule);
        }

        // PUT: api/VisitingRules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVisitingRule(int id, VisitingRule visitingRule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != visitingRule.VisitingRuleId)
            {
                return BadRequest();
            }

            db.Entry(visitingRule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VisitingRuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VisitingRules
        [ResponseType(typeof(VisitingRule))]
        public IHttpActionResult PostVisitingRule(VisitingRule visitingRule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VisitingRuleSet.Add(visitingRule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = visitingRule.VisitingRuleId }, visitingRule);
        }

        // DELETE: api/VisitingRules/5
        [ResponseType(typeof(VisitingRule))]
        public IHttpActionResult DeleteVisitingRule(int id)
        {
            VisitingRule visitingRule = db.VisitingRuleSet.Find(id);
            if (visitingRule == null)
            {
                return NotFound();
            }

            db.VisitingRuleSet.Remove(visitingRule);
            db.SaveChanges();

            return Ok(visitingRule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VisitingRuleExists(int id)
        {
            return db.VisitingRuleSet.Count(e => e.VisitingRuleId == id) > 0;
        }
    }
}