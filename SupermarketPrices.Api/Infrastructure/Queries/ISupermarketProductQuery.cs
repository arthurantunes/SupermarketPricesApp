using SupermarketPrices.Api.Models;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Infrastructure.Queries
{
    public interface ISupermarketProductQuery
    {
        Task<SupermarketViewModel> GetProductWIthPrice(int supermarketId, int productID);
        Task<SupermarketViewModel> GetProductWIthPrice(int supermarketId);
    }
}
