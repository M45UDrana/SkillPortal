using Microsoft.EntityFrameworkCore;
using SkillPortal.Models;

namespace SkillPortal.Data.DbContexts;

public partial class SkillPortalDbContext : DbContext
{
    public SkillPortalDbContext()
    {
    }

    public SkillPortalDbContext(DbContextOptions<SkillPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){ }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Email__3214EC070FAAE178");

            entity.ToTable("Email");

            entity.Property(e => e.EmailAddress)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Emails)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Email__UserId__398D8EEE");
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC077A04CD24");

            entity.ToTable("Employee");

            entity.Property(e => e.BasicSalary).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.EducationalQualification)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.EmployeeName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.JoiningDate).HasColumnType("date");

            entity.HasMany(d => d.Skills).WithMany(p => p.Employees)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeeSkill",
                    r => r.HasOne<Skill>().WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmployeeS__Skill__4222D4EF"),
                    l => l.HasOne<Employee>().WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EmployeeS__Emplo__412EB0B6"),
                    j =>
                    {
                        j.HasKey("EmployeeId", "SkillId").HasName("PK__Employee__172A4609237F6D72");
                    });
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skill__3214EC07013F0B8F");

            entity.ToTable("Skill");

            entity.Property(e => e.SkillName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User).WithMany(p => p.Skills)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Skill__UserId__3C69FB99");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC074513D2CF");

            entity.ToTable("User");

            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Mobile)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
