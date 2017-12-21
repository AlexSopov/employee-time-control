namespace EmployeeTimeControl.Data.Migrations
{
    using AccessLayer;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeTimeControlDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EmployeeTimeControlDataContext context)
        {
            #region Init Working Day Standart Rule

            VisitingRule visitingRuleEveryWorkDay = new VisitingRule();
            visitingRuleEveryWorkDay.Description = "Visiting in work days From 10 till 18";
            visitingRuleEveryWorkDay.DayRules.Add(new DayVisitingRule()
            {
                DayOfWeek = DayOfWeek.Monday,
                DayNormal = 8,
                StartWorkingDay = new DateTime(2000, 1, 1, 9, 0, 0),
                EndWorkingDay = new DateTime(2000, 1, 1, 17, 0, 0)
            });
            visitingRuleEveryWorkDay.DayRules.Add(new DayVisitingRule()
            {
                DayOfWeek = DayOfWeek.Tuesday,
                DayNormal = 8,
                StartWorkingDay = new DateTime(2000, 1, 1, 9, 0, 0),
                EndWorkingDay = new DateTime(2000, 1, 1, 17, 0, 0)
            });
            visitingRuleEveryWorkDay.DayRules.Add(new DayVisitingRule()
            {
                DayOfWeek = DayOfWeek.Wednesday,
                DayNormal = 8,
                StartWorkingDay = new DateTime(2000, 1, 1, 9, 0, 0),
                EndWorkingDay = new DateTime(2000, 1, 1, 17, 0, 0)
            });
            visitingRuleEveryWorkDay.DayRules.Add(new DayVisitingRule()
            {
                DayOfWeek = DayOfWeek.Thursday,
                DayNormal = 8,
                StartWorkingDay = new DateTime(2000, 1, 1, 9, 0, 0),
                EndWorkingDay = new DateTime(2000, 1, 1, 17, 0, 0)
            });
            visitingRuleEveryWorkDay.DayRules.Add(new DayVisitingRule()
            {
                DayOfWeek = DayOfWeek.Friday,
                DayNormal = 8,
                StartWorkingDay = new DateTime(2000, 1, 1, 9, 0, 0),
                EndWorkingDay = new DateTime(2000, 1, 1, 17, 0, 0)
            });

            #endregion

            #region Init Working Day Weekend Rule

            VisitingRule visitingRuleWeekends = new VisitingRule();
            visitingRuleWeekends.Description = "Visiting on weekends rule";
            visitingRuleWeekends.DayRules.Add(new DayVisitingRule()
            {
                DayOfWeek = DayOfWeek.Saturday,
                DayNormal = 5,
                StartWorkingDay = new DateTime(2000, 1, 1, 12, 0, 0),
                EndWorkingDay = new DateTime(2000, 1, 1, 17, 0, 0)
            });
            visitingRuleWeekends.DayRules.Add(new DayVisitingRule()
            {
                DayOfWeek = DayOfWeek.Sunday,
                DayNormal = 8,
                StartWorkingDay = new DateTime(2000, 1, 1, 12, 0, 0),
                EndWorkingDay = new DateTime(2000, 1, 1, 17, 0, 0)
            });

            #endregion

            #region Initialize Employees

            Employee employee1 = new Employee()
            {
                FirstName = "Alex",
                SecondName = "Sopov",
                JobTitle = "Developer",
                VisitingRule = visitingRuleEveryWorkDay
            };
            Employee employee2 = new Employee()
            {
                FirstName = "James",
                SecondName = "Richardson",
                JobTitle = "Does something. No one knows what, but he has biggest salary",
                VisitingRule = visitingRuleEveryWorkDay
            };
            Employee employee3 = new Employee()
            {
                FirstName = "Tamara ",
                SecondName = "Lawless",
                JobTitle = "I'm Tamara Lawless - it's my work",
                VisitingRule = visitingRuleEveryWorkDay
            };
            Employee employee4 = new Employee()
            {
                FirstName = "Ryan ",
                SecondName = "Rew",
                JobTitle = "Have no idea about job title",
                VisitingRule = visitingRuleEveryWorkDay
            };
            Employee employee5 = new Employee()
            {
                FirstName = "Paul",
                SecondName = "Ingraham",
                JobTitle = "Simply the best job title",
                VisitingRule = visitingRuleWeekends
            };

            #endregion

            #region Initialize Passing Points

            PassagePoint passingPoint1 = new PassagePoint()
            {
                Address = "Address 1"
            };
            PassagePoint passingPoint2 = new PassagePoint()
            {
                Address = "Address 2"
            };

            #endregion

            #region Initialize Cards

            Card card1 = new Card() { CardOwner = employee1 };
            Card card2 = new Card() { CardOwner = employee2 };
            Card card3 = new Card() { CardOwner = employee3 };
            Card card4 = new Card() { CardOwner = employee4 };
            Card card5 = new Card() { CardOwner = employee5 };

            #endregion

            #region Initialize Card Accesses

            CardAccess cardAccess1 = new CardAccess()
            {
                Card = card1,
                PassagePoint = passingPoint1
            };
            CardAccess cardAccess2 = new CardAccess()
            {
                Card = card2,
                PassagePoint = passingPoint1
            };
            CardAccess cardAccess3 = new CardAccess()
            {
                Card = card3,
                PassagePoint = passingPoint1
            };
            CardAccess cardAccess4 = new CardAccess()
            {
                Card = card4,
                PassagePoint = passingPoint1
            };
            CardAccess cardAccess5 = new CardAccess()
            {
                Card = card5,
                PassagePoint = passingPoint1
            };

            #endregion

            #region Initialize Access Attemptions

            List<Employee> employees = new List<Employee>() { employee1, employee2, employee3, employee4, employee5 };
            List<Card> cards = new List<Card>() { card1, card2, card3, card4, card5 };
            List<AccessAttemption> accessAttemptions = new List<AccessAttemption>();
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                // In
                accessAttemptions.Add(new AccessAttemption()
                {
                    Card = cards[i % 5],
                    PassagePoint = passingPoint1,
                    AttemptionTime = new DateTime(2017, 11, 2 + i % 5, 9 + random.Next(-2, 2), 0, 0),
                    SuccessStatus = true,
                    IsEnter = true
                });

                // Out
                accessAttemptions.Add(new AccessAttemption()
                {
                    Card = cards[i % 5],
                    PassagePoint = passingPoint1,
                    AttemptionTime = new DateTime(2017, 11, 2 + i % 5, 17 + random.Next(-2, 2), 0, 0),
                    SuccessStatus = true,
                    IsEnter = false
                });
            }

            using (EmployeeTimeControlDataContext dataContext = new EmployeeTimeControlDataContext())
            {
                dataContext.EmployeeSet.AddRange(employees);
                dataContext.AccessAttemptionSet.AddRange(accessAttemptions);

                dataContext.SaveChanges();
            }


            #endregion
        }
    }
}
