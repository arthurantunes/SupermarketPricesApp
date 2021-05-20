using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Repositories;
using SupermarketPrices.Infra.Context;

namespace SupermarketPrices.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(SupermarketPricesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
