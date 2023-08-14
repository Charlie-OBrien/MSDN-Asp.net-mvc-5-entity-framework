namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSlotModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Slot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        type = c.String(),
                        Instructor_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Person", t => t.Instructor_ID)
                .Index(t => t.Instructor_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slot", "Instructor_ID", "dbo.Person");
            DropIndex("dbo.Slot", new[] { "Instructor_ID" });
            DropTable("dbo.Slot");
        }
    }
}
