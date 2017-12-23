using EmployeeTimeControl.Data.Models;
using System;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class AccessAttemptionTest : DataTestBase
    {
        [Fact]
        [assembly: CollectionBehavior(DisableTestParallelization = true)]
        public void AccessAttemptionNavigationPropertiesWork()
        {
            AccessAttemption accessAttemption = new AccessAttemption()
            {
                Card = new Card()
                {
                    Employee = new Employee()
                    {
                        FirstName = "FirstName",
                        SecondName = "SecondName",
                        JobTitle = "Job",
                        VisitingRule = new VisitingRule() { Description = "Description"}
                    },
                },
                PassagePoint = new PassagePoint()
                {
                    Address = "Address"
                },
                SuccessStatus = true,
                IsEnter = true,
                AttemptionTime = DateTime.Now
            };

            employeeTimeControlDataContext.AccessAttemptionSet.Add(accessAttemption);
            Assert.NotEqual(0, employeeTimeControlDataContext.SaveChanges());

            accessAttemption = employeeTimeControlDataContext.AccessAttemptionSet.Find(accessAttemption.AccessAttemptionId);

            Assert.NotNull(accessAttemption);
            Assert.NotNull(accessAttemption.PassagePoint);
            Assert.NotNull(accessAttemption.Card);
        }
    }
}
