using EmployeeTimeControl.Data.Models;
using System.Data.Entity;

namespace EmployeeTimeControl.Data.AccessLayer
{
    public class EmployeeTimeControlDataContext : DbContext
    {
        public EmployeeTimeControlDataContext() : base("EmployeeTimeControlSystem")
        {

        }

        public DbSet<AccessAttemption> AccessAttemptionSet { get; set; }
        public DbSet<Card> CardSet { get; set; }
        public DbSet<CardAccess> CardAccessSet { get; set; }
        public DbSet<DayVisitingRule> DayVisitingRuleSet { get; set; }
        public DbSet<Employee> EmployeeSet { get; set; }
        public DbSet<PassagePoint> PassagePointSet { get; set; }
        public DbSet<VisitingRule> VisitingRuleSet { get; set; }
        public DbSet<DayOff> DayOffSet { get; set; }
    }
}
