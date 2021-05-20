using SupermarketPrices.Infra.Context;

namespace SupermarketPrices.Api.Infrastructure.Queries
{

    public class SupermarketQuery : ISupermarketQuery
    {

        private readonly SupermarketPricesDbContext _context;

        public SupermarketQuery(SupermarketPricesDbContext context)
        {
            _context = context;
        }


    }
}
