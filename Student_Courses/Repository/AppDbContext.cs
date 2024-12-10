using Microsoft.EntityFrameworkCore;
using Student_Courses.Model;

namespace Student_Courses.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Class> Classes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Student>()
                        .HasKey(s => s.Id);

            modelBuilder.Entity<Class>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Student>()
                .HasMany(s => s.classes)
                .WithMany(c => c.student)
                .UsingEntity(join =>
                    join.ToTable("StudentClasses"));

            // Configure unique constraints
            modelBuilder.Entity<Student>()
                .HasIndex(s => s.EmailId)
                .IsUnique();

            modelBuilder.Entity<Student>()
                .HasIndex(s => s.PhoneNumber)
                .IsUnique();

            // Configure max length for Class description
            modelBuilder.Entity<Class>()
                .Property(c => c.Description)
                .HasMaxLength(100);
        }
    }
}
