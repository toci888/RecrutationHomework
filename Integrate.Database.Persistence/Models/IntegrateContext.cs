using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Integrate.Database.Persistence.Models;

public partial class IntegrateContext : DbContext
{
    public IntegrateContext()
    {
    }

    public IntegrateContext(DbContextOptions<IntegrateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productbysku> Productbyskus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=Integrate;Username=postgres;Password=beatka");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("inventory_pkey");

            entity.ToTable("inventory");

            entity.HasIndex(e => e.Sku, "inventory_sku_key").IsUnique();

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnName("product_id");
            entity.Property(e => e.Manufacturer).HasColumnName("manufacturer");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Shipping).HasColumnName("shipping");
            entity.Property(e => e.ShippingCost).HasColumnName("shipping_cost");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Unit).HasColumnName("unit");

            entity.HasOne(d => d.Product).WithOne(p => p.InventoryProduct)
                .HasForeignKey<Inventory>(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_product_id_fkey");

            entity.HasOne(d => d.SkuNavigation).WithOne(p => p.InventorySkuNavigation)
                .HasPrincipalKey<Product>(p => p.Sku)
                .HasForeignKey<Inventory>(d => d.Sku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("inventory_sku_fkey");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("prices_pkey");

            entity.ToTable("prices");

            entity.HasIndex(e => e.Sku, "prices_sku_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Nettproductprice).HasColumnName("nettproductprice");
            entity.Property(e => e.Nettproductpricediscount).HasColumnName("nettproductpricediscount");
            entity.Property(e => e.Nettproductpricediscountplu).HasColumnName("nettproductpricediscountplu");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Vatrate).HasColumnName("vatrate");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.PriceIdNavigation)
                .HasForeignKey<Price>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prices_id_fkey");

            entity.HasOne(d => d.SkuNavigation).WithOne(p => p.PriceSkuNavigation)
                .HasPrincipalKey<Product>(p => p.Sku)
                .HasForeignKey<Price>(d => d.Sku)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("prices_sku_fkey");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("products_pkey");

            entity.ToTable("products");

            entity.HasIndex(e => e.Sku, "products_sku_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Available).HasColumnName("available");
            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.DefaultImage).HasColumnName("default_image");
            entity.Property(e => e.Ean).HasColumnName("ean");
            entity.Property(e => e.IsVendor).HasColumnName("is_vendor");
            entity.Property(e => e.IsWire).HasColumnName("is_wire");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.ProducerName).HasColumnName("producer_name");
            entity.Property(e => e.Sku).HasColumnName("sku");
        });

        modelBuilder.Entity<Productbysku>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("productbysku");

            entity.Property(e => e.Category).HasColumnName("category");
            entity.Property(e => e.DefaultImage).HasColumnName("default_image");
            entity.Property(e => e.Ean).HasColumnName("ean");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Nettproductprice).HasColumnName("nettproductprice");
            entity.Property(e => e.ProducerName).HasColumnName("producer_name");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.ShippingCost).HasColumnName("shipping_cost");
            entity.Property(e => e.Sku).HasColumnName("sku");
            entity.Property(e => e.Unit).HasColumnName("unit");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
