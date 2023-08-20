using ContosoUniversity.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<TrainingBooking> Bookings { get; set; }
        public DbSet<Slot> Slots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vacation> Vacations { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Course>()
                .HasMany(c => c.Instructors).WithMany(i => i.Courses)
                .Map(t => t.MapLeftKey("CourseID")
                    .MapRightKey("InstructorID")
                    .ToTable("CourseInstructor"));

            // Configure User
            modelBuilder.Entity<User>()
                .HasKey(u => u.Id)  // Setting the primary key
                .Property(u => u.FirstName)  // Configuring FirstName property
                .IsRequired()  // Making FirstName required
                .HasMaxLength(100);  // Setting maximum length for FirstName

            modelBuilder.Entity<User>()
                .Property(u => u.LastName)  // Configuring LastName property
                .IsRequired()  // Making LastName required
                .HasMaxLength(100);  // Setting maximum length for LastName

            // Configure Vacation
            modelBuilder.Entity<Vacation>()
                .HasKey(v => v.Id)  // Setting the primary key
                .Property(v => v.Description)  // Configuring Description property
                .HasMaxLength(500);  // Setting maximum length for Description

            // Setting up the relationship between User and Vacation
            modelBuilder.Entity<Vacation>()
                .HasRequired(v => v.User)  // A vacation has one required User
                .WithMany()  // A user can have many vacations
                .HasForeignKey(v => v.UserId);  // Foreign key from Vacation to User

            // Set up one-to-many relationship between Book and Review
            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Book)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookId)
                .WillCascadeOnDelete(true);


            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Department>().MapToStoredProcedures();
        }
    }
}