using Microsoft.EntityFrameworkCore;

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
        public DbSet<ReviewsProduct> ReviewsProducts { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<CharacteristicProduct> CharacteristicProducts { get; set; }
        public DbSet<Character> Character { get; set; }
        public DbSet<BrandProduct> BrandProduct { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<RecentlyViewed> RecentlyViewed { get; set; }
        public DbSet<PostponedProduct> PostponedProduct { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=DESKTOP-DIDBBK2;Initial Catalog=AppliancesStore;Integrated Security=True; TrustServerCertificate=True");
        }

    }
}
