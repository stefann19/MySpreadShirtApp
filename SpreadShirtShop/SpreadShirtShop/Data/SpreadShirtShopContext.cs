#nullable disable
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SpreadShirtShop.Models;
using Size = SpreadShirtShop.Models.Size;

namespace SpreadShirtShop.Data
{
    public class SpreadShirtShopContext : DbContext
    {
        public SpreadShirtShopContext(DbContextOptions<SpreadShirtShopContext> options)
            : base(options)
        {
        }

        public DbSet<Appearance> Appearances { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Colors> Colors { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<CurrencyPrice> CurrencyPrices { get; set; }
        public DbSet<ImageModel> ImageModels { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Length> Lengths { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet<MeasureValue> MeasureValues { get; set; }
        public DbSet<PrintType> PrintTypes { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public DbSet<ProductTypeDepartment> ProductTypeDepartments { get; set; }
        public DbSet<ProductTypePrice> ProductTypePrices { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Sellable> Sellables { get; set; }
        public DbSet<ShippingCountry> ShippingCountries { get; set; }
        public DbSet<ShippingState> ShippingStates { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<StockState> StockStates { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<User> Users { get; set; }

        //Country Length Language
        public DbSet<WashingInstruction> WashingInstructions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            if (modelBuilder == null)
                throw new ArgumentNullException("modelBuilder");

            modelBuilder.AddRemovePluralizeConvention();
            /*
            modelBuilder.AddRemoveOneToManyCascadeConvention();
            */

            modelBuilder.ApplyConventions();

            modelBuilder.Entity<Sellable>()
                .HasOne(s => s.ProductType)
                .WithMany(p=> p.Sellables)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);

        }
    }

    public static class ContextExtensions
    {

        private static List<Action<IMutableEntityType>> Conventions = new List<Action<IMutableEntityType>>();

        public static void AddRemovePluralizeConvention(this ModelBuilder builder)
        {
            Conventions.Add(et => et.SetTableName(et.DisplayName()));
        }

        public static void AddRemoveOneToManyCascadeConvention(this ModelBuilder builder)
        {
            Conventions.Add(et => et.GetForeignKeys()
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                .ToList()
                .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict));
        }

        public static void ApplyConventions(this ModelBuilder builder)
        {
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (Action<IMutableEntityType> action in Conventions)
                    action(entityType);
            }

            Conventions.Clear();
        }
    }
}
