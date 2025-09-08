using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ITIGraduation.Models;

namespace ITIGraduation.Data;

public partial class SparkContext : DbContext
{
    public SparkContext()
    {
    }

    public SparkContext(DbContextOptions<SparkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Boot> Boots { get; set; }


    public virtual DbSet<Oxford> Oxfords { get; set; }

    public virtual DbSet<Prouduct> Prouducts { get; set; }

    public virtual DbSet<Sport> Sports { get; set; }

    public virtual DbSet<TrendingSelling> TrendingSellings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    

    public DbSet<CartItemEntity> CartItems { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Spark;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartItemEntity>()
    .Property(c => c.Price)
    .HasPrecision(18, 2);

        modelBuilder.Entity<Boot>(entity =>
        {
            entity.HasKey(e => e.BootId).HasName("PK__boots__A1BFC0423832348B");

            entity.ToTable("boots");

            entity.Property(e => e.BootId)
                .ValueGeneratedOnAdd()
                .HasColumnName("boot_id");
            entity.Property(e => e.BootName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("boot_name");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag_url");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        

        modelBuilder.Entity<Oxford>(entity =>
        {
            entity.HasKey(e => e.OxfordId).HasName("PK__oxford__D49DEDC900C25A6B");

            entity.ToTable("oxford");

            entity.Property(e => e.OxfordId)
                .ValueGeneratedOnAdd()
                .HasColumnName("oxford_id");
            entity.Property(e => e.BootName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("boot_name");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag_url");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<Prouduct>(entity =>
        {
            entity.HasKey(e => e.ProuductId).HasName("PK__Prouduct__0D534CAB3AB37D03");

            entity.ToTable("Prouduct");

            entity.Property(e => e.ProuductId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Prouduct_id");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag_url");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProuductName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Prouduct_name");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<Sport>(entity =>
        {
            entity.HasKey(e => e.SportId).HasName("PK__sport__0439264189FA7CDC");

            entity.ToTable("sport");

            entity.Property(e => e.SportId)
                .ValueGeneratedOnAdd()
                .HasColumnName("sport_id");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag_url");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Size).HasColumnName("size");
            entity.Property(e => e.SportName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("sport_name");
        });

        modelBuilder.Entity<TrendingSelling>(entity =>
        {
            entity.HasKey(e => e.ProudId).HasName("PK__Trending__A698124A20DF5AAE");

            entity.ToTable("Trending_selling");

            entity.Property(e => e.ProudId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Proud_id");
            entity.Property(e => e.Imag2)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag2");
            entity.Property(e => e.Imag3)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag3");
            entity.Property(e => e.Imag4)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag4");
            entity.Property(e => e.ImagUrl)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("imag_url");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ProudName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Proud_name");
            entity.Property(e => e.Size).HasColumnName("size");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UsersId).HasName("PK__USERS__EAA7D14B9FC4913F");

            entity.ToTable("USERS");

            entity.Property(e => e.UsersId)
                .ValueGeneratedNever()
                .HasColumnName("users_id");
            entity.Property(e => e.Country)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Gmail)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("gmail");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("user_name");
        });

        

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
