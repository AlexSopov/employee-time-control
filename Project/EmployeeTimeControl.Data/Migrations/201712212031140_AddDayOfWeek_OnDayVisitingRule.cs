namespace EmployeeTimeControl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayOfWeek_OnDayVisitingRule : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DayVisitingRules", "DayOfWeek", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DayVisitingRules", "DayOfWeek");
        }
    }
}
