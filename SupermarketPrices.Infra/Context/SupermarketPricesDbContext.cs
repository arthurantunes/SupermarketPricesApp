using Microsoft.EntityFrameworkCore;
using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Infra.Context.Mapping;

namespace SupermarketPrices.Infra.Context
{
    public class SupermarketPricesDbContext : DbContext
    {
        public SupermarketPricesDbContext(DbContextOptions<SupermarketPricesDbContext> options)
                  : base(options)
        {
        }

        public DbSet<Supermarket> Supermarkets { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SupermarketProduct> SupermarketProducts { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SupermarketMapping());
            modelBuilder.ApplyConfiguration(new ProductMapping());
            modelBuilder.ApplyConfiguration(new SupermarketProductMapping());

        }
    }
}
