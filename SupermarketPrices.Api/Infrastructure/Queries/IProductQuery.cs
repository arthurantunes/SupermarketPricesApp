using SupermarketPrices.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Infrastructure.Queries
{
    public interface IProductQuery
    {
        Task<List<ProductViewModel>> GetAllProducts();

        Task<ProductSupermarketPriceViewModel> GetAllProductsPrice(int productId);
        Task<ProductSupermarketPriceViewModel> GetAllProductsByPrice(int productId, int priceFrom, int priceTo);
        Task<List<ProductViewModel>> GetProductsByName(string name);
    }
}
