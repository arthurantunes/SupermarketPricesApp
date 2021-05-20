using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Repositories;
using SupermarketPrices.Infra.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Infra.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly SupermarketPricesDbContext _dbContext;

        public ProductRepository(SupermarketPricesDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<Product>> GetAllBySupermarketId(int id)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<Product> GetAllBySupermarketId(int id)
        //{
        //    return _dbContext.Products.Where(x => x.SupermarketId == id).ToList();
        //}
    }
}
