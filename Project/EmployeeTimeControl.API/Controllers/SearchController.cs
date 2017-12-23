using EmployeeTimeControl.Data.AccessLayer;
using EmployeeTimeControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Http;

namespace EmployeeTimeControl.API.Controllers
{
    public class SearchController : ApiController
    {
        private EmployeeTimeControlDataContext db = new EmployeeTimeControlDataContext();

        [Route("api/Search/LatecomersList")]
        public IEnumerable<Employee> GetLatecomersList(string fromDate, string toDate)
        {
            DateTime fromAccessDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime toAccessDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return db.EmployeeSet.SqlQuery(@"SELECT empl.EmployeeId, empl.FirstName, empl.SecondName, empl.JobTitle, empl.VisitingRuleId 
                        FROM Employees AS empl
                                JOIN Cards ON Cards.EmployeeId = empl.EmployeeId
                                JOIN AccessAttemptions AS aas ON aas.CardId = Cards.CardId
                        WHERE cast(aas.AttemptionTime as time) >
                        (
                            SELECT cast(dvr.StartWorkingDay as time)
                                FROM DayVisitingRules as dvr
                                    JOIN VisitingRules AS vis ON dvr.VisitingRuleId = vis.VisitingRuleId
                                    JOIN Employees AS empl ON empl.VisitingRuleId = vis.VisitingRuleId
                                    JOIN Cards AS ca ON ca.CardId = empl.EmployeeId
                                WHERE ca.CardId = aas.CardId AND dvr.DayOfWeek + 1 = DATEPART(weekday, aas.AttemptionTime)
                        )  AND aas.IsEnter = 1
                        AND NOT aas.AttemptionTime IN
                        (
                            SELECT do.DayOffDate FROM DayOffs AS do
                                    JOIN Employees ON Employees.EmployeeId = do.EmployeeId
                                    JOIN Cards ON Cards.CardId = aas.CardId
	                    )
	                    AND aas.AttemptionTime BETWEEN @from AND @to",
                        new SqlParameter("@from", fromAccessDate.ToString("yyyy-MM-dd")),
                        new SqlParameter("@to", toAccessDate.ToString("yyyy-MM-dd")));
        }
        [Route("api/Search/EarlierOutgoers")]
        public IEnumerable<Employee> GetEarlierOutgoers(string fromDate, string toDate)
        {
            DateTime fromAccessDate = DateTime.ParseExact(fromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            DateTime toAccessDate = DateTime.ParseExact(toDate, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            return db.EmployeeSet.SqlQuery(@"SELECT empl.EmployeeId, empl.FirstName, empl.SecondName, empl.JobTitle, empl.VisitingRuleId 
                        FROM Employees AS empl
	                        JOIN Cards ON Cards.EmployeeId = empl.EmployeeId
	                        JOIN AccessAttemptions AS aas ON aas.CardId = Cards.CardId
                        WHERE aas.IsEnter = 0
                        AND (DATEPART(hour, aas.AttemptionTime -
                        (
	                        SELECT aasg.AttemptionTime FROM AccessAttemptions AS aasg
	                        WHERE aasg.CardId = aas.CardId 
	                        AND aasg.IsEnter = 1
	                        AND aasg.PassagePointId = aas.PassagePointId
	                        AND CONVERT(date, aasg.AttemptionTime) = CONVERT(date, aas.AttemptionTime)

                        ))) 
                        <
                        (
	                        SELECT dvr.DayNormal
	                        FROM DayVisitingRules as dvr
		                        JOIN VisitingRules AS vis ON dvr.VisitingRuleId = vis.VisitingRuleId
		                        JOIN Employees AS empl ON empl.VisitingRuleId = vis.VisitingRuleId
		                        JOIN Cards AS ca ON ca.CardId = empl.EmployeeId
	                        WHERE ca.CardId = aas.CardId AND dvr.DayOfWeek + 1 = DATEPART(weekday, aas.AttemptionTime)
                        )",
                        new SqlParameter("@from", fromAccessDate.ToString("yyyy-MM-dd")),
                        new SqlParameter("@to", toAccessDate.ToString("yyyy-MM-dd")));
        }


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
