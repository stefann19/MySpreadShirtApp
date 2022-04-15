#nullable disable
using Microsoft.EntityFrameworkCore;
using SpreadShirtShop.Models;

namespace SpreadShirtShop.Data
{
    public class SpreadShirtShopContext : DbContext
    {
        public SpreadShirtShopContext (DbContextOptions<SpreadShirtShopContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }
        public DbSet<Sellable> Sellables { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ImageModel> ImageModels { get; set; }
        public DbSet<CurrencyPrice> CurrencyPrices { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Appearance> Appearances { get; set; }
    }
}
