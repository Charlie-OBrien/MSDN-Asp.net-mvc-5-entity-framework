namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrainingDates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TrainingBooking",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BookingID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Person_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Person", t => t.Person_ID)
                .Index(t => t.Person_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TrainingBooking", "Person_ID", "dbo.Person");
            DropIndex("dbo.TrainingBooking", new[] { "Person_ID" });
            DropTable("dbo.TrainingBooking");
        }
    }
}
