using EmployeeTimeControl.Data.Models;
using System;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class DayOffTest : DataTestBase
    {
        [Fact]
        public void DayOffNavigationPropertiesWork()
        {
            Employee employee1 = new Employee()
            {
                FirstName = "FirstName",
                SecondName = "SecondName",
                JobTitle = "Job",
                VisitingRule = new VisitingRule() { Description = "Description" }
            };
            Employee employee2 = new Employee()
            {
                FirstName = "FirstName2",
                SecondName = "SecondName2",
                JobTitle = "Job",
                VisitingRule = new VisitingRule() { Description = "Description" }
            };

            employee1.DayOffs.Add(new DayOff() { DayOffDate = DateTime.Now, DayOffType = DayOffType.SickLeave });

            employeeTimeControlDataContext.EmployeeSet.Add(employee1);
            employeeTimeControlDataContext.EmployeeSet.Add(employee2);
            Assert.NotEqual(0, employeeTimeControlDataContext.SaveChanges());

            employee1 = employeeTimeControlDataContext.EmployeeSet.Find(employee1.EmployeeId);

            Assert.NotNull(employee1);
            Assert.Equal(1, employee1.DayOffs.Count);
            Assert.Equal(0, employee2.DayOffs.Count);
        }
    }
}
