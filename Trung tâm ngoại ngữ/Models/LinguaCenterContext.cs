using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LinguaCenter.Models;

public partial class LinguaCenterContext : DbContext
{
    public LinguaCenterContext()
    {
    }

    public LinguaCenterContext(DbContextOptions<LinguaCenterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAccount> TbAccounts { get; set; }

    public virtual DbSet<TbCategory> TbCategories { get; set; }

    public virtual DbSet<TbContact> TbContacts { get; set; }

    public virtual DbSet<TbCourse> TbCourses { get; set; }

    public virtual DbSet<TbEvent> TbEvents { get; set; }

    public virtual DbSet<TbFeedback> TbFeedbacks { get; set; }

    public virtual DbSet<TbLesson> TbLessons { get; set; }

    public virtual DbSet<TbMenu> TbMenus { get; set; }

    public virtual DbSet<TbModule> TbModules { get; set; }

    public virtual DbSet<TbOrder> TbOrders { get; set; }

    public virtual DbSet<TbRole> TbRoles { get; set; }

    public virtual DbSet<TbTrainer> TbTrainers { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("data source=LAPTOP-RJ9B4RJJ; initial catalog=LinguaCenter; integrated security=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAccount>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Account");

            entity.Property(e => e.AccountId).ValueGeneratedOnAdd();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.LastLogin)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TbCategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Tb_Categ__19093A0BA9ADF74C");

            entity.ToTable("Tb_Categories");

            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<TbContact>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__Tb_Conta__5C66259B6BD2E480");

            entity.ToTable("Tb_Contact");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbCourse>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Tb_Cours__C92D71A7DE9DD7B1");

            entity.ToTable("Tb_Courses");

            entity.Property(e => e.Alias)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Image)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.Language).HasMaxLength(100);
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Category).WithMany(p => p.TbCourses)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK_Courses_Category");

            entity.HasOne(d => d.Trainer).WithMany(p => p.TbCourses)
                .HasForeignKey(d => d.TrainerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Courses_Trainer");
        });

        modelBuilder.Entity<TbEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__tb_Event__7944C8102F8886AD");

            entity.ToTable("tb_Events");

            entity.Property(e => e.EventDate).HasColumnType("datetime");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);
        });

        modelBuilder.Entity<TbFeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__tb_Feedb__6A4BEDD68A879F21");

            entity.ToTable("tb_Feedback");

            entity.Property(e => e.AvatarPath).HasMaxLength(500);
            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FullName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.JobTitle).HasMaxLength(255);
            entity.Property(e => e.Rating).HasDefaultValue(5);
        });

        modelBuilder.Entity<TbLesson>(entity =>
        {
            entity.HasKey(e => e.LessonId).HasName("PK__Tb_Lesso__B084ACD0C591B3D9");

            entity.ToTable("Tb_Lessons");

            entity.Property(e => e.Title).HasMaxLength(255);
            entity.Property(e => e.Type)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Module).WithMany(p => p.TbLessons)
                .HasForeignKey(d => d.ModuleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Lessons_Module");
        });

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity.HasKey(e => e.MenuId);

            entity.ToTable("tb_Menu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
        });

        modelBuilder.Entity<TbModule>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Tb_Modul__2B7477A7D970BAF4");

            entity.ToTable("Tb_Modules");

            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.Course).WithMany(p => p.TbModules)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Modules_Course");
        });

        modelBuilder.Entity<TbOrder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__tb_Order__C3905BCF4533E32D");

            entity.ToTable("tb_Order");

            entity.Property(e => e.CreateDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CustomerName).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Course).WithMany(p => p.TbOrders)
                .HasForeignKey(d => d.CourseId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tb_Order_tb_Courses");
        });

        modelBuilder.Entity<TbRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Role");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.RoleId).ValueGeneratedOnAdd();
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<TbTrainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__tb_Train__366A1A7C82480243");

            entity.ToTable("tb_Trainers");

            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.Facebook).HasMaxLength(250);
            entity.Property(e => e.FullName).HasMaxLength(150);
            entity.Property(e => e.Image).HasMaxLength(250);
            entity.Property(e => e.Instagram).HasMaxLength(250);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LinkedIn).HasMaxLength(250);
            entity.Property(e => e.Speciality).HasMaxLength(150);
            entity.Property(e => e.Twitter).HasMaxLength(250);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
