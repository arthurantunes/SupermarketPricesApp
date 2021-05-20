using SupermarketPrices.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Domain.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<IEnumerable<Product>> GetAllBySupermarketId(int id);

    }
}
