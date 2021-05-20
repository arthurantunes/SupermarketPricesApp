using Microsoft.EntityFrameworkCore;
using SupermarketPrices.Api.Models;
using SupermarketPrices.Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Infrastructure.Queries
{

    public class ProductQuery : IProductQuery
    {

        private readonly SupermarketPricesDbContext _context;

        public ProductQuery(SupermarketPricesDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAllProductsAsync()
        {
            var product = from p in _context.Products
                          select new ProductViewModel
                          {
                              Id = p.Id,
                              Description = p.Description,
                              Brand = p.Brand,
                              EAN = p.EAN,
                              Name = p.Name,
                              SKU = p.SKU,
                          };

            return await product.AsNoTracking().ToListAsync();
        }

        public async Task<List<ProductViewModel>> GetProductsByNameAsync(string name)
        {
            var product = _context.Products.Where(x => x.Name.Contains(name)).Select(p =>
                           new ProductViewModel
                           {
                               Id = p.Id,
                               Description = p.Description,
                               Brand = p.Brand,
                               EAN = p.EAN,
                               Name = p.Name,
                               SKU = p.SKU,
                           });

            return await product.AsNoTracking().ToListAsync();
        }

        public async Task<ProductSupermarketPriceViewModel> GetAllProductsPriceAsync(int productId)
        {
            var product = from p in _context.Products

                          where p.Id == productId
                          select new ProductSupermarketPriceViewModel
                          {
                              Id = p.Id,
                              Description = p.Description,
                              Brand = p.Brand,
                              EAN = p.EAN,
                              Name = p.Name,
                              SKU = p.SKU,
                              Prices = (from sp in _context.SupermarketProducts
                                        join s in _context.Supermarkets on sp.SupermarketId equals s.Id
                                        where sp.ProductId.Equals(productId)
                                        select new SupermarketPriceViewModel
                                        {
                                            SupermarketName = s.Name,
                                            Price = sp.Price,
                                            Date = sp.Date
                                        }).ToList()
                          };



            return await product.FirstOrDefaultAsync();
        }

        public async Task<ProductSupermarketPriceViewModel> GetAllProductsByPriceAsync(int productId, int priceFrom, int priceTo)
        {
            var product = from p in _context.Products

                          where p.Id == productId
                          select new ProductSupermarketPriceViewModel
                          {
                              Id = p.Id,
                              Description = p.Description,
                              Brand = p.Brand,
                              EAN = p.EAN,
                              Name = p.Name,
                              SKU = p.SKU,
                              Prices = (from sp in _context.SupermarketProducts
                                        join s in _context.Supermarkets on sp.SupermarketId equals s.Id
                                        where sp.ProductId.Equals(productId)
                                        && sp.Price >= priceFrom && sp.Price <= priceTo
                                        select new SupermarketPriceViewModel
                                        {
                                            SupermarketName = s.Name,
                                            Price = sp.Price,
                                            Date = sp.Date
                                        }).ToList()
                          };



            return await product.FirstOrDefaultAsync();
        }
    }
}
