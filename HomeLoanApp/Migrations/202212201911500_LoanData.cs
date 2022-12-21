namespace HomeLoanApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LoanData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationForms",
                c => new
                    {
                        Application_Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Phone_No = c.String(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        Address = c.String(nullable: false),
                        Bank_Account_No = c.Int(nullable: false),
                        Employeement_Type = c.String(nullable: false),
                        Organization_Name = c.String(nullable: false),
                        Property_Location = c.String(nullable: false),
                        Property_Value = c.Double(nullable: false),
                        Users_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Application_Id)
                .ForeignKey("dbo.Users", t => t.Users_UserId)
                .Index(t => t.Users_UserId);
            
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
                        Application_Id = c.Int(nullable: false, identity: true),
                        Loanid = c.Int(nullable: false),
                        Name = c.String(),
                        LoanAmount = c.Double(nullable: false),
                        InterestRate = c.Double(nullable: false),
                        LoanStatus = c.String(nullable: false),
                        Tenure = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Application_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationForms", "Users_UserId", "dbo.Users");
            DropIndex("dbo.ApplicationForms", new[] { "Users_UserId" });
            DropTable("dbo.LoanDetails");
            DropTable("dbo.Users");
            DropTable("dbo.ApplicationForms");
        }
    }
}
