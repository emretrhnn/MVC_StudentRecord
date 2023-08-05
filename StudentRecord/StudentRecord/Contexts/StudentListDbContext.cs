using Microsoft.EntityFrameworkCore;
using StudentRecord.Entities;

namespace StudentRecord.Contexts;

public partial class StudentListDbContext : DbContext
{
    public StudentListDbContext()
    {
    }

    public StudentListDbContext(DbContextOptions<StudentListDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<StudentTable> StudentTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=StudentListDB;trusted_connection=true;trustservercertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentTable>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK_Table_1");

            entity.ToTable("StudentTable");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.StudentAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentImage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.StudentMail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StudentSurname)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
