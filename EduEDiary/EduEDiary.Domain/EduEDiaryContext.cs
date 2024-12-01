using Microsoft.EntityFrameworkCore;

namespace EduEDiary.Domain;

public class EduEDiaryContext(DbContextOptions<EduEDiaryContext> options) : DbContext(options)
{
    public DbSet<Class> Classes { get; set; }
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Subject> Subjects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>()
            .HasKey(c => c.Id);

        modelBuilder.Entity<Class>()
            .Property(c => c.Number)
            .IsRequired();

        modelBuilder.Entity<Class>()
            .Property(c => c.Letter)
            .HasMaxLength(2)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .HasKey(st => st.Id);

        modelBuilder.Entity<Student>()
            .HasOne(st => st.Class)
            .WithMany()
            .HasForeignKey("ClassId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Student>()
            .Property(st => st.Passport)
            .HasMaxLength(12);

        modelBuilder.Entity<Student>()
            .Property(st => st.FullName)
            .HasMaxLength(120)
            .IsRequired();

        modelBuilder.Entity<Student>()
            .Property(st => st.BirthDate)
            .IsRequired();

        modelBuilder.Entity<Subject>()
            .HasKey(s => s.Id);

        modelBuilder.Entity<Subject>()
            .Property(s => s.Name)
            .HasMaxLength(50)
            .IsRequired();

        modelBuilder.Entity<Subject>()
            .Property(s => s.Year)
            .IsRequired();

        modelBuilder.Entity<Grade>()
            .HasKey(g => g.Id);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Student)
            .WithMany()
            .HasForeignKey("StudentId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .HasOne(g => g.Subject)
            .WithMany()
            .HasForeignKey("SubjectId")
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Grade>()
            .Property(g => g.GradeValue)
            .IsRequired();

        modelBuilder.Entity<Grade>()
            .Property(g => g.Date)
            .IsRequired();
    }
}
