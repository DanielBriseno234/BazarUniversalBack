using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MediFinder_Backend.Models;

public partial class MedifinderContext : DbContext
{
    public MedifinderContext()
    {
    }

    public MedifinderContext(DbContextOptions<MedifinderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductImage> ProductImages { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__brands__3213E83F46C5D796");

            entity.ToTable("brands");

            entity.HasIndex(e => e.Name, "UQ__brands__72E12F1BBED4C460").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__categori__3213E83F4F505326");

            entity.ToTable("categories");

            entity.HasIndex(e => e.Name, "UQ__categori__72E12F1B7A6C2152").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__products__3213E83F06197826");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.BrandId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("brand_id");
            entity.Property(e => e.CategoryId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("category_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.DiscountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discountPercentage");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Rating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("rating");
            entity.Property(e => e.Stock).HasColumnName("stock");
            entity.Property(e => e.Thumbnail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("thumbnail");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");
        });

        modelBuilder.Entity<ProductImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__product___3213E83FDC62583D");

            entity.ToTable("product_images");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductImages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductImages_Products");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__purchase__3213E83FBBC7D3BC");

            entity.ToTable("purchases");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");
            entity.Property(e => e.UnitPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("unit_price");
            entity.Property(e => e.discountPercentage)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("discountPercentage");
            entity.Property(e => e.totalWithDiscount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("totalWithDiscount");

            entity.HasOne(d => d.Product).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_Purchases_Products");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
