namespace EmployeeTimeControl.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeToDayOff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DayOffs", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.DayOffs", "EmployeeId");
            AddForeignKey("dbo.DayOffs", "EmployeeId", "dbo.Employees", "EmployeeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DayOffs", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.DayOffs", new[] { "EmployeeId" });
            DropColumn("dbo.DayOffs", "EmployeeId");
        }
    }
}
