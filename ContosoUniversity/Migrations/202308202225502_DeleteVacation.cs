namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteVacation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VacationSlot", "PersonId", "dbo.Person");
            DropIndex("dbo.VacationSlot", new[] { "PersonId" });
            DropTable("dbo.VacationSlot");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.VacationSlot", "PersonId");
            AddForeignKey("dbo.VacationSlot", "PersonId", "dbo.Person", "ID", cascadeDelete: true);
        }
    }
}
