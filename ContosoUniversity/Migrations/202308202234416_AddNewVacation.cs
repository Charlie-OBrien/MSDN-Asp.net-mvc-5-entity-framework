namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewVacation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vacation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 500),
                        UserId = c.Int(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.UserId)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vacation", "User_Id", "dbo.User");
            DropForeignKey("dbo.Vacation", "UserId", "dbo.User");
            DropIndex("dbo.Vacation", new[] { "User_Id" });
            DropIndex("dbo.Vacation", new[] { "UserId" });
            DropTable("dbo.Vacation");
            DropTable("dbo.User");
        }
    }
}
