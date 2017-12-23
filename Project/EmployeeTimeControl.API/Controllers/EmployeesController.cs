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
using System.Data.SqlClient;

namespace EmployeeTimeControl.API.Controllers
{
    public class EmployeesController : ApiController
    {
        private EmployeeTimeControlDataContext db = new EmployeeTimeControlDataContext();
        
        // GET: api/Employees
        public IQueryable<Employee> GetEmployeeSet()
        {
            return db.EmployeeSet;
        }

        [Route("api/Employees/{id}/AccessHistory")]
        public IEnumerable<AccessAttemption> GetAccessHistory(int id)
        {
            return db.AccessAttemptionSet.SqlQuery(
                "SELECT * FROM AccessAttemptions AS aas WHERE aas.CardId IN" + 
                "(SELECT Cards.CardId FROM Cards WHERE Cards.EmployeeId = @id); ", 
                new SqlParameter("@id", id));
        }

        // GET: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult GetEmployee(int id)
        {
            Employee employee = db.EmployeeSet.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // PUT: api/Employees/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee(int id, Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            db.Entry(employee).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // POST: api/Employees
        [ResponseType(typeof(Employee))]
        public IHttpActionResult PostEmployee(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmployeeSet.Add(employee);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee.EmployeeId }, employee);
        }

        // DELETE: api/Employees/5
        [ResponseType(typeof(Employee))]
        public IHttpActionResult DeleteEmployee(int id)
        {
            Employee employee = db.EmployeeSet.Find(id);
            if (employee == null)
            {
                return NotFound();
            }

            db.EmployeeSet.Remove(employee);
            db.SaveChanges();

            return Ok(employee);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeExists(int id)
        {
            return db.EmployeeSet.Count(e => e.EmployeeId == id) > 0;
        }
    }
}