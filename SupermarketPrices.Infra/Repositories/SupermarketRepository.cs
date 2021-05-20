using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Repositories;
using SupermarketPrices.Infra.Context;

namespace SupermarketPrices.Infra.Repositories
{
    public class SupermarketRepository : BaseRepository<Supermarket>, ISupermarketRepository
    {
        public SupermarketRepository(SupermarketPricesDbContext dbContext) : base(dbContext)
        {
        }
    }
}
