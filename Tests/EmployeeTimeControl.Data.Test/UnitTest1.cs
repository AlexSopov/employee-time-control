using EmployeeTimeControl.Data.AccessLayer;
using EmployeeTimeControl.Data.Models;
using System;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            using (EmployeeTimeControlDataContext db = new EmployeeTimeControlDataContext())
            {
                var employees = db.EmployeeSet;
                employees.Add(new Employee() { FirstName = "1", SecondName = "2", JobTitle = "3" });
                db.SaveChanges();

                foreach (var b in employees)
                {
                    Console.WriteLine(b);
                }

                var c = db.CardSet;
                foreach (var d in c)
                {
                    Console.WriteLine(d);
                }

                var emp = db.EmployeeSet.Find(1);
            }
        }

        [Fact]
        public void PassingTest2()
        {
            Employee e = new Employee();
            e.FirstName = "Name";

            Assert.Equal("Name", e.FirstName);
        }

        [Fact]
        public void UWTest()
        {
            UnitOfWork unit = new UnitOfWork();

            unit.ToString();
            Assert.NotNull(unit);
        }
    }
}
