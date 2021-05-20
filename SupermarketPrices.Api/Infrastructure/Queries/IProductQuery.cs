using SupermarketPrices.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Infrastructure.Queries
{
    public interface IProductQuery
    {
        Task<List<ProductViewModel>> GetAllProductsAsync();

        Task<ProductSupermarketPriceViewModel> GetAllProductsPriceAsync(int productId);
        Task<ProductSupermarketPriceViewModel> GetAllProductsByPriceAsync(int productId, int priceFrom, int priceTo);
        Task<List<ProductViewModel>> GetProductsByNameAsync(string name);
    }
}
