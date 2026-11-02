using FTELMarket.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace FTELMarket.Infrastructure
{
    public class FtelMarketDbContext : DbContext
    {
        public FtelMarketDbContext(DbContextOptions<FtelMarketDbContext> options) : base(options) { }

        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FtelMarketDbContext).Assembly);
        }
    }
}