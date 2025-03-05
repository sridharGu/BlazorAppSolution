using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppProj.Model;

public partial class TestingCrudContext : DbContext
{
    public TestingCrudContext()
    {
    }

    public TestingCrudContext(DbContextOptions<TestingCrudContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TestingCrud");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC078BF08506");

            entity.ToTable("Product");

            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");

            entity.Property(e => e.Quntity)
                .HasColumnType("int")
                .HasColumnName("Quntity");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("Product_Name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
