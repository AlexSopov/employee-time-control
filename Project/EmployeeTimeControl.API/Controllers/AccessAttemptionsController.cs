using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using EmployeeTimeControl.Data.AccessLayer;
using EmployeeTimeControl.Data.Models;

namespace EmployeeTimeControl.API.Controllers
{
    public class AccessAttemptionsController : ApiController
    {
        private EmployeeTimeControlDataContext db = new EmployeeTimeControlDataContext();

        // GET: api/AccessAttemptions
        public IQueryable<AccessAttemption> GetAccessAttemptionSet()
        {
            return db.AccessAttemptionSet;
        }

        // GET: api/AccessAttemptions/5
        [ResponseType(typeof(AccessAttemption))]
        public IHttpActionResult GetAccessAttemption(int id)
        {
            AccessAttemption accessAttemption = db.AccessAttemptionSet.Find(id);
            if (accessAttemption == null)
            {
                return NotFound();
            }

            return Ok(accessAttemption);
        }

        // PUT: api/AccessAttemptions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAccessAttemption(int id, AccessAttemption accessAttemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != accessAttemption.AccessAttemptionId)
            {
                return BadRequest();
            }

            db.Entry(accessAttemption).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccessAttemptionExists(id))
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

        // POST: api/AccessAttemptions
        [ResponseType(typeof(AccessAttemption))]
        public IHttpActionResult PostAccessAttemption(AccessAttemption accessAttemption)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AccessAttemptionSet.Add(accessAttemption);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = accessAttemption.AccessAttemptionId }, accessAttemption);
        }

        // DELETE: api/AccessAttemptions/5
        [ResponseType(typeof(AccessAttemption))]
        public IHttpActionResult DeleteAccessAttemption(int id)
        {
            AccessAttemption accessAttemption = db.AccessAttemptionSet.Find(id);
            if (accessAttemption == null)
            {
                return NotFound();
            }

            db.AccessAttemptionSet.Remove(accessAttemption);
            db.SaveChanges();

            return Ok(accessAttemption);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AccessAttemptionExists(int id)
        {
            return db.AccessAttemptionSet.Count(e => e.AccessAttemptionId == id) > 0;
        }
    }
}