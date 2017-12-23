using EmployeeTimeControl.Data.Models;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class CardTest : DataTestBase
    {
        [Fact]
        public void CardNavigationPropertiesWork()
        {
            Card card = new Card()
            {
                Employee = new Employee()
                {
                    FirstName = "FirstName",
                    SecondName = "SecondName",
                    JobTitle = "Job",
                    VisitingRule = new VisitingRule { Description = "Description" }
                },
            };

            employeeTimeControlDataContext.CardSet.Add(card);
            Assert.NotEqual(0, employeeTimeControlDataContext.SaveChanges());

            card = employeeTimeControlDataContext.CardSet.Find(card.CardId);

            Assert.NotNull(card);
            Assert.NotNull(card.Employee);
            Assert.Equal("SecondName", card.Employee.SecondName);
        }
    }
}
