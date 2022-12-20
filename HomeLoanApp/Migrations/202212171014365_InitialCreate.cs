namespace HomeLoanApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                    {
                        Application_Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        Name = c.String(nullable: false),
                        Phone_No = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Bank_Account_No = c.Int(nullable: false),
                        Employeement_Type = c.String(nullable: false),
                        Organization_Name = c.String(nullable: false),
                        Property_Location = c.String(nullable: false),
                        Property_Value = c.Double(nullable: false),
                        Aadharcard = c.Binary(nullable: false),
                        PanCard = c.Binary(nullable: false),
                        SalarySlip = c.Binary(nullable: false),
                        NOC = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Application_Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        ConfirmPassword = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.LoanDetails",
                c => new
                    {
                        LoanId = c.Int(nullable: false, identity: true),
                        Application_Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Name = c.String(nullable: false),
                        LoanAmount = c.Double(nullable: false),
                        InterestRate = c.Double(nullable: false),
                        LoanStatus = c.String(nullable: false),
                        Tenure = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.LoanId)
                .ForeignKey("dbo.ApplicationForms", t => t.Application_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Application_Id)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LoanDetails", "UserId", "dbo.Users");
            DropForeignKey("dbo.LoanDetails", "Application_Id", "dbo.ApplicationForms");
            DropForeignKey("dbo.ApplicationForms", "UserId", "dbo.Users");
            DropIndex("dbo.LoanDetails", new[] { "UserId" });
            DropIndex("dbo.LoanDetails", new[] { "Application_Id" });
            DropIndex("dbo.ApplicationForms", new[] { "UserId" });
            DropTable("dbo.LoanDetails");
            DropTable("dbo.Users");
            DropTable("dbo.ApplicationForms");
        }
    }
}
