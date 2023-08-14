namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setupslot : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Slot", name: "Instructor_ID", newName: "InstructorId");
            RenameIndex(table: "dbo.Slot", name: "IX_Instructor_ID", newName: "IX_InstructorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Slot", name: "IX_InstructorId", newName: "IX_Instructor_ID");
            RenameColumn(table: "dbo.Slot", name: "InstructorId", newName: "Instructor_ID");
        }
    }
}
