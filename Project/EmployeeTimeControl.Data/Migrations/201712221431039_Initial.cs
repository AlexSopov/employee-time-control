namespace EmployeeTimeControl.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccessAttemptions",
                c => new
                    {
                        AccessAttemptionId = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        PassagePointId = c.Int(nullable: false),
                        SuccessStatus = c.Boolean(nullable: false),
                        IsEnter = c.Boolean(nullable: false),
                        AttemptionTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AccessAttemptionId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.PassagePoints", t => t.PassagePointId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.PassagePointId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.CardAccesses",
                c => new
                    {
                        CardAccessId = c.Int(nullable: false, identity: true),
                        CardId = c.Int(nullable: false),
                        PassagePointId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CardAccessId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.PassagePoints", t => t.PassagePointId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.PassagePointId);
            
            CreateTable(
                "dbo.PassagePoints",
                c => new
                    {
                        PassagePointId = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.PassagePointId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        VisitingRuleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.VisitingRules", t => t.VisitingRuleId, cascadeDelete: true)
                .Index(t => t.VisitingRuleId);
            
            CreateTable(
                "dbo.VisitingRules",
                c => new
                    {
                        VisitingRuleId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.VisitingRuleId);
            
            CreateTable(
                "dbo.DayVisitingRules",
                c => new
                    {
                        DayVisitingRuleId = c.Int(nullable: false, identity: true),
                        VisitingRuleId = c.Int(nullable: false),
                        StartWorkingDay = c.DateTime(nullable: false),
                        EndWorkingDay = c.DateTime(nullable: false),
                        DayNormal = c.Int(nullable: false),
                        DayOfWeek = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DayVisitingRuleId)
                .ForeignKey("dbo.VisitingRules", t => t.VisitingRuleId, cascadeDelete: true)
                .Index(t => t.VisitingRuleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AccessAttemptions", "PassagePointId", "dbo.PassagePoints");
            DropForeignKey("dbo.AccessAttemptions", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Employees", "VisitingRuleId", "dbo.VisitingRules");
            DropForeignKey("dbo.DayVisitingRules", "VisitingRuleId", "dbo.VisitingRules");
            DropForeignKey("dbo.Cards", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.CardAccesses", "PassagePointId", "dbo.PassagePoints");
            DropForeignKey("dbo.CardAccesses", "CardId", "dbo.Cards");
            DropIndex("dbo.DayVisitingRules", new[] { "VisitingRuleId" });
            DropIndex("dbo.Employees", new[] { "VisitingRuleId" });
            DropIndex("dbo.CardAccesses", new[] { "PassagePointId" });
            DropIndex("dbo.CardAccesses", new[] { "CardId" });
            DropIndex("dbo.Cards", new[] { "EmployeeId" });
            DropIndex("dbo.AccessAttemptions", new[] { "PassagePointId" });
            DropIndex("dbo.AccessAttemptions", new[] { "CardId" });
            DropTable("dbo.DayVisitingRules");
            DropTable("dbo.VisitingRules");
            DropTable("dbo.Employees");
            DropTable("dbo.PassagePoints");
            DropTable("dbo.CardAccesses");
            DropTable("dbo.Cards");
            DropTable("dbo.AccessAttemptions");
        }
    }
}
