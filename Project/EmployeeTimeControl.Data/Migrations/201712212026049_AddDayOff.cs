namespace EmployeeTimeControl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayOff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DayOffs",
                c => new
                    {
                        DayOffId = c.Int(nullable: false, identity: true),
                        DayOffDate = c.DateTime(nullable: false),
                        DayOffType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DayOffId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DayOffs");
        }
    }
}
