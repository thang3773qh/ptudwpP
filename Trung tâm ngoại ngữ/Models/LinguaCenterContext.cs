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

    public virtual DbSet<TbMenu> TbMenus { get; set; }

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

        modelBuilder.Entity<TbMenu>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tb_Menu");

            entity.Property(e => e.Alias).HasMaxLength(150);
            entity.Property(e => e.CreatedBy).HasMaxLength(150);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.MenuId).ValueGeneratedOnAdd();
            entity.Property(e => e.ModifiedBy).HasMaxLength(150);
            entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(150);
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
