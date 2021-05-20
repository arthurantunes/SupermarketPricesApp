using SupermarketPrices.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Infrastructure.Queries
{
    public interface ISupermarketQuery
    {
        public Task<IList<SupermarketViewModel>> GetAllAsync();
    }
}
