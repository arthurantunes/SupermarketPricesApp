using Microsoft.EntityFrameworkCore;
using SupermarketPrices.Api.Models;
using SupermarketPrices.Infra.Context;
using System.Linq;
using System.Threading.Tasks;

namespace SupermarketPrices.Api.Infrastructure.Queries
{
    public class SupermarketProductQuery : ISupermarketProductQuery
    {

        private readonly SupermarketPricesDbContext _context;

        public SupermarketProductQuery(SupermarketPricesDbContext context)
        {
            _context = context;
        }
        public async Task<SupermarketViewModel> GetProductWIthPrice(int supermarketId, int productID)
        {
            var supermarket = _context.Supermarkets.Where(x => x.Id == supermarketId)
                .Select(s => new SupermarketViewModel
                {
                    Id = s.Id,
                    Name = s.Name,

                    Products = s.SupermarketProduct.Where(sp => sp.ProductId.Equals(productID)).Select(sp => new SupermarketProductViewModel
                    {
                        Date = sp.Date,
                        Price = sp.Price,
                        ProductId = sp.ProductId,
                        SupermarketId = sp.SupermarketId,
                        Product = _context.Products.Select(p => new ProductViewModel
                        {
                            Id = p.Id,
                            Description = p.Description,
                            Brand = p.Brand,
                            EAN = p.EAN,
                            Name = p.Name,
                            SKU = p.SKU,
                        }).Where(p => p.Id.Equals(sp.ProductId)).FirstOrDefault()
                    }).ToList()
                });

            return await supermarket.FirstOrDefaultAsync();
        }

        public async Task<SupermarketViewModel> GetProductWIthPrice(int supermarketId)
        {
            var supermarket = _context.Supermarkets.Where(x => x.Id == supermarketId)
                .Select(s => new SupermarketViewModel
                {
                    Id = s.Id,
                    Name = s.Name,

                    Products = s.SupermarketProduct.Select(sp => new SupermarketProductViewModel
                    {
                        Date = sp.Date,
                        Price = sp.Price,
                        ProductId = sp.ProductId,
                        SupermarketId = sp.SupermarketId,
                        Product = _context.Products.Select(p => new ProductViewModel
                        {
                            Id = p.Id,
                            Description = p.Description,
                            Brand = p.Brand,
                            EAN = p.EAN,
                            Name = p.Name,
                            SKU = p.SKU,
                        }).Where(p => p.Id.Equals(sp.ProductId)).FirstOrDefault()
                    }).ToList()
                });

            return await supermarket.FirstOrDefaultAsync();
        }
    }
}
