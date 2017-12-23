using EmployeeTimeControl.Data.Models;
using System;
using System.Linq;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class VisitingRuleTest : DataTestBase
    {
        [Fact]
        public void DayOffNavigationPropertiesWork()
        {
            VisitingRule visitingRule = new VisitingRule
            {
                Description = "Two days a week"
            };
            visitingRule.DayRules.Add(new DayVisitingRule
            {
                StartWorkingDay = new TimeSpan(10, 0, 0),
                EndWorkingDay = new TimeSpan(18, 0, 0),
                DayOfWeek = DayOfWeek.Monday,
                DayNormal = 8,    
            });
            visitingRule.DayRules.Add(new DayVisitingRule
            {
                StartWorkingDay = new TimeSpan(11, 0, 0),
                EndWorkingDay = new TimeSpan(20, 0, 0),
                DayOfWeek = DayOfWeek.Wednesday,
                DayNormal = 9,
            });

            employeeTimeControlDataContext.VisitingRuleSet.Add(visitingRule);
            Assert.NotEqual(0, employeeTimeControlDataContext.SaveChanges());

            visitingRule = employeeTimeControlDataContext.VisitingRuleSet.Find(visitingRule.VisitingRuleId);

            Assert.Equal(2, visitingRule.DayRules.Count);
            Assert.Equal(2, employeeTimeControlDataContext.DayVisitingRuleSet.Count(dayVisitingRule =>
                dayVisitingRule.VisitingRuleId == visitingRule.VisitingRuleId));
        }
    }
}
