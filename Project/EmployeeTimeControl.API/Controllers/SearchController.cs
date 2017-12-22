using EmployeeTimeControl.Data.AccessLayer;
using EmployeeTimeControl.Data.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Http;

namespace EmployeeTimeControl.API.Controllers
{
    public class SearchController : ApiController
    {
        private EmployeeTimeControlDataContext db = new EmployeeTimeControlDataContext();

        //[Route("api/Search/LatecomersList")]
        //public IEnumerable<Employee> GetLatecomersList(int id, string fromDate, string toDate)
        //{
        //    return db.AccessAttemptionSet.SqlQuery(
        //        "SELECT * FROM AccessAttemptions AS aas WHERE aas.CardId IN" +
        //        "(SELECT Cards.CardId FROM Cards WHERE Cards.EmployeeId = @id); ",
        //        new SqlParameter("@id", id));
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
