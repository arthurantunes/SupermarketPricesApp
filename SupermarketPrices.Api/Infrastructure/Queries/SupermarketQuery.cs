using Microsoft.EntityFrameworkCore;
using SupermarketPrices.Api.Models;
using SupermarketPrices.Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Infrastructure.Queries
{

    public class SupermarketQuery : ISupermarketQuery
    {

        private readonly SupermarketPricesDbContext _context;

        public SupermarketQuery(SupermarketPricesDbContext context)
        {
            _context = context;
        }

        

        public async Task<IList<SupermarketViewModel>> GetAllAsync()
        {
            return await _context.Supermarkets.Select(s => new SupermarketViewModel()
            {
                Id = s.Id,
                Name = s.Name
            }).ToListAsync();
        }
    }
}
