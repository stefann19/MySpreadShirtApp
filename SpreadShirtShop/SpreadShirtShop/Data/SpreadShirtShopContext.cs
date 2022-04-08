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
    }
}
