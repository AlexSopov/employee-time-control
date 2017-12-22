namespace EmployeeTimeControl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTypeToTimeOnDayVisitingRule : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.DayVisitingRules", "StartWorkingDay", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.DayVisitingRules", "EndWorkingDay", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.DayVisitingRules", "EndWorkingDay", c => c.DateTime(nullable: false));
            AlterColumn("dbo.DayVisitingRules", "StartWorkingDay", c => c.DateTime(nullable: false));
        }
    }
}
