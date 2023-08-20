namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVacation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VacationSlot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        Description = c.String(),
                        PersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VacationSlot", "PersonId", "dbo.Person");
            DropIndex("dbo.VacationSlot", new[] { "PersonId" });
            DropTable("dbo.VacationSlot");
        }
    }
}
