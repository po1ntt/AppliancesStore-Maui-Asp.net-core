using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models;

public partial class AppliancesStoreContext : DbContext
{
    public AppliancesStoreContext()
    {
    }

    public AppliancesStoreContext(DbContextOptions<AppliancesStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Adrese> Adreses { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Favorite> Favorites { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderedProduct> OrderedProducts { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server= DESKTOP-82MMU8P\\SQLEXPRESS;Database= AppliancesStore;Trusted_Connection=True; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Adrese>(entity =>
        {
            entity.HasKey(e => e.IdAdress);

            entity.Property(e => e.IdAdress).HasColumnName("id_adress");
            entity.Property(e => e.Adress).HasColumnName("adress");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Adreses)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Adreses_Users");
        });

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.IdBasket);

            entity.ToTable("Basket");

            entity.Property(e => e.IdBasket).HasColumnName("id_basket");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_Id");
            entity.Property(e=> e.CountProduct).HasColumnName("countProduct");
            entity.HasOne(d => d.Product).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Basket_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Basket_Users");
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.IdBrand);

            entity.ToTable("Brand");

            entity.Property(e => e.IdBrand).HasColumnName("id_brand");
            entity.Property(e => e.LogoBrand).HasColumnName("logoBrand");
            entity.Property(e => e.NameBrand).HasColumnName("nameBrand");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory);

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("id_category");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Logo).HasColumnName("logo");

        });

        modelBuilder.Entity<Favorite>(entity =>
        {
            entity.HasKey(e => e.IdFavorites);

            entity.Property(e => e.IdFavorites).HasColumnName("id_favorites");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.HasOne(d => d.Product).WithMany(p => p.Favorites)
               .HasForeignKey(d => d.ProductId)
               .OnDelete(DeleteBehavior.Cascade)
               .HasConstraintName("FK_Favorites_Products");
            entity.HasOne(d => d.User).WithMany(p => p.Favorites)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Favorites_Users");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.IdOrder);

            entity.Property(e => e.IdOrder).HasColumnName("id_order");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.DateOrderBegin)
                .HasColumnType("datetime")
                .HasColumnName("dateOrderBegin");
            entity.Property(e => e.DateOrderEnd)
                .HasColumnType("datetime")
                .HasColumnName("dateOrderEnd");
            entity.Property(e => e.OrderNumber).HasColumnName("orderNumber");
            entity.Property(e => e.OrderedProductsId).HasColumnName("orderedProducts_id");
            entity.Property(e => e.StatusId).HasColumnName("status_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.OrderedProducts).WithMany(p => p.Orders)
                .HasForeignKey(d => d.OrderedProductsId)
                .HasConstraintName("FK_Orders_OrderedProducts");

            entity.HasOne(d => d.Status).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK_Orders_Status");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Orders_Users");
        });

        modelBuilder.Entity<OrderedProduct>(entity =>
        {
            entity.HasKey(e => e.IdOrderedProducts);

            entity.Property(e => e.IdOrderedProducts).HasColumnName("id_orderedProducts");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderedProducts)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderedProducts_Products");

            entity.HasOne(d => d.User).WithMany(p => p.OrderedProducts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_OrderedProducts_Users");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.Property(e => e.IdProduct).HasColumnName("id_product");
            entity.Property(e => e.ProductBrandId).HasColumnName("productBrand_id");
            entity.Property(e => e.ProductCategoryId).HasColumnName("productCategory_id");
            entity.Property(e => e.ProductDescription).HasColumnName("productDescription");
            entity.Property(e => e.ProductImage).HasColumnName("productImage");
            entity.Property(e => e.ProductName).HasColumnName("productName");
            entity.Property(e => e.ProductPrice).HasColumnName("productPrice");

            entity.HasOne(d => d.ProductBrand).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductBrandId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_Brand");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductCategoryId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Products_Category");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.IdReviews);

            entity.Property(e => e.IdReviews)
                .ValueGeneratedNever()
                .HasColumnName("id_reviews");
            entity.Property(e => e.Grade).HasColumnName("grade");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Review1).HasColumnName("review");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Product).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Reviews_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Reviews_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRole);

            entity.Property(e => e.IdRole).HasColumnName("id_role");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus);

            entity.ToTable("Status");

            entity.Property(e => e.IdStatus).HasColumnName("id_status");
            entity.Property(e => e.Status1).HasColumnName("status");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser);

            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.FirstName).HasColumnName("firstName");
            entity.Property(e => e.Gender).HasColumnName("gender");
            entity.Property(e => e.Login).HasColumnName("login");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Patronymic).HasColumnName("patronymic");
            entity.Property(e => e.RoleId).HasColumnName("role_id");
            entity.Property(e => e.SecondName).HasColumnName("secondName");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Users_Roles");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
