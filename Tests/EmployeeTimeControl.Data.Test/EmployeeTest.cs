using EmployeeTimeControl.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class EmployeeTest : DataTestBase
    {
        [Fact]
        public void CanStoreEmployee()
        {
            Employee employee1 = new Employee
            {
                FirstName = "FirstName",
                SecondName = "SecondName",
                JobTitle = "Job",
                VisitingRule = new VisitingRule { Description = "Description" }
            };
            Employee employee2 = new Employee
            {
                FirstName = "FirstName2",
                SecondName = "SecondName2",
                JobTitle = "Job2",
                VisitingRule = new VisitingRule { Description = "Description2" }
            };

            employeeTimeControlDataContext.EmployeeSet.Add(employee1);
            employeeTimeControlDataContext.EmployeeSet.Add(employee2);
            Assert.NotEqual(0, employeeTimeControlDataContext.SaveChanges());

            Assert.Equal(2, employeeTimeControlDataContext.EmployeeSet.Count());
        }
    }
}
