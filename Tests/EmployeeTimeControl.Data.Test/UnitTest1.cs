using EmployeeTimeControl.Data.Models;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class UnitTest1
    {
        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, 2 + 2);
        }

        [Fact]
        public void PassingTest2()
        {
            Employee e = new Employee();
            e.FirstName = "Name";

            Assert.Equal(e.FirstName, "Name");
        }
    }
}
