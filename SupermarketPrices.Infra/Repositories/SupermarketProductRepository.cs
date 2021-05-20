using Microsoft.EntityFrameworkCore;
using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Repositories;
using SupermarketPrices.Infra.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketPrices.Infra.Repositories
{
    public class SupermarketProductRepository : BaseRepository<SupermarketProduct>, ISupermarketProductRepository
    {
        private readonly SupermarketPricesDbContext _dbContext;

        public SupermarketProductRepository(SupermarketPricesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task<SupermarketProduct> GetByIds(int supermarketId, int productId)
        {
            var supermarketPrice = await _dbContext.SupermarketProducts.AsNoTracking().Where(x => x.SupermarketId.Equals(supermarketId) && x.ProductId.Equals(productId)).SingleOrDefaultAsync();
            _dbContext.Entry(supermarketPrice).State = EntityState.Detached;
            return supermarketPrice;
        }
    }
}
