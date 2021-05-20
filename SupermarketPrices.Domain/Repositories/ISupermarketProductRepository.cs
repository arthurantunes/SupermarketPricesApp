using SupermarketPrices.Domain.Entities;
using System.Threading.Tasks;

namespace SupermarketPrices.Domain.Repositories
{
    public interface ISupermarketProductRepository : IRepository<SupermarketProduct>
    {
        Task<SupermarketProduct> GetByIds(int supermarketId, int productId);
    }
}
