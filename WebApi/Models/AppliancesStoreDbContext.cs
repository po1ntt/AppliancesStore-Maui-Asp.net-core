using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace WebApi.Models
{
    public class AppliancesStoreDbContext : DbContext
    {
        public AppliancesStoreDbContext()
        {
        }

        public AppliancesStoreDbContext(DbContextOptions options)
            : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Review>  Review { get; set; }
        public DbSet<ReviewsProduct> ReviewsProduct { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CharacteristicProduct> CharacteristicProduct { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<BrandProduct> BrandProduct { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<RecentlyViewed> RecentlyViewed { get; set; }
        public DbSet<PostponedProduct> PostponedProduct { get; set; }
        public DbSet<Basket> Basket { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>()
               .HasMany(e => e.CharacteristicProduct)
                .WithOne(e => e.Product)
                .HasForeignKey(e => e.product_id)
                .IsRequired();
            modelBuilder.Entity<Users>()
              .HasMany(e => e.PostponedProduct)
               .WithOne(e => e.Users)
               .HasForeignKey(e => e.user_id)
               .IsRequired();
            modelBuilder.Entity<Users>()
             .HasMany(e => e.Basket)
              .WithOne(e => e.Users)
              .HasForeignKey(e => e.user_id)
              .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DIDBBK2;Initial Catalog=AppliancesStore;Integrated Security=True; TrustServerCertificate=True");
        }

    }
}
