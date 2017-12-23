using EmployeeTimeControl.Data.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmployeeTimeControl.Data.Test
{
    public class CardPassageAccessTest : DataTestBase
    {
        [Fact]
        public void CardAccessNavigationPropertiesWork()
        {
            Card card1 = new Card()
            {
                Employee = new Employee()
                {
                    FirstName = "FirstName",
                    SecondName = "SecondName",
                    JobTitle = "Job",
                    VisitingRule = new VisitingRule() { Description = "Description" }
                }
            };
            Card card2 = new Card()
            {
                Employee = new Employee()
                {
                    FirstName = "FirstName2",
                    SecondName = "SecondName2",
                    JobTitle = "Job",
                    VisitingRule = new VisitingRule() { Description = "Description" }
                }
            };
            Card card3 = new Card()
            {
                Employee = new Employee()
                {
                    FirstName = "FirstName3",
                    SecondName = "SecondName3",
                    JobTitle = "Job",
                    VisitingRule = new VisitingRule() { Description = "Description" }
                }
            };

            PassagePoint passagePoint = new PassagePoint() { Address = "Address" };

            Assert.False(CanIntersectPassagePoint(card1, passagePoint));
            Assert.False(CanIntersectPassagePoint(card2, passagePoint));
            Assert.False(CanIntersectPassagePoint(card3, passagePoint));

            employeeTimeControlDataContext.CardAccessSet.Add(new CardAccess { Card = card1, PassagePoint = passagePoint });
            employeeTimeControlDataContext.CardAccessSet.Add(new CardAccess { Card = card2, PassagePoint = passagePoint });
            Assert.NotEqual(0, employeeTimeControlDataContext.SaveChanges());

            IEnumerable<CardAccess> cardAccesses = employeeTimeControlDataContext.CardAccessSet;
            Assert.NotEmpty(cardAccesses);

            Assert.True(CanIntersectPassagePoint(card1, passagePoint));
            Assert.True(CanIntersectPassagePoint(card2, passagePoint));
            Assert.False(CanIntersectPassagePoint(card3, passagePoint));

            Assert.True(passagePoint.CardAccesses.Any(cardAccess => cardAccess.CardId == card1.CardId));
            Assert.True(passagePoint.CardAccesses.Any(cardAccess => cardAccess.CardId == card2.CardId));
            Assert.False(passagePoint.CardAccesses.Any(cardAccess => cardAccess.CardId == card3.CardId));
        }

        private bool CanIntersectPassagePoint(Card card, PassagePoint passagePoint)
        {
            return employeeTimeControlDataContext.CardAccessSet.Any(
                (item) => item.CardId == card.CardId && item.PassagePointId == passagePoint.PassagePointId);
        }
    }
}
