namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeslotmodel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Slot", "InstructorId", "dbo.Person");
            DropIndex("dbo.Slot", new[] { "InstructorId" });
            AddColumn("dbo.Slot", "InstructorName", c => c.String());
            AlterColumn("dbo.Slot", "InstructorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Slot", "InstructorId");
            AddForeignKey("dbo.Slot", "InstructorId", "dbo.Person", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slot", "InstructorId", "dbo.Person");
            DropIndex("dbo.Slot", new[] { "InstructorId" });
            AlterColumn("dbo.Slot", "InstructorId", c => c.Int());
            DropColumn("dbo.Slot", "InstructorName");
            CreateIndex("dbo.Slot", "InstructorId");
            AddForeignKey("dbo.Slot", "InstructorId", "dbo.Person", "ID");
        }
    }
}
