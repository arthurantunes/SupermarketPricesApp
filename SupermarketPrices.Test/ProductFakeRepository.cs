using SupermarketPrices.Domain.Entities;
using SupermarketPrices.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Test
{
    public class ProductFakeRepository : IProductRepository
    {
        public void Create(Product entity)
        {
        }

        public void Delete(Product Entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetAll()
        {
            List<Product> lst = new List<Product>();

            lst.Add(new Product("Notebook Asus x240", "The best notebook", "axc1234", "1213123", "Asus"));
            lst.Add(new Product("Macbook Air M1", "Try the new macbook", "64562123", "675434675", "Apple"));

            return lst;
        }

        public IEnumerable<Product> GetAllBySupermarketId(int id)
        {
            throw new NotImplementedException();
        }


        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IRepository<Product>.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetAllBySupermarketId(int id)
        {
            throw new NotImplementedException();
        }

        Task<Product> IRepository<Product>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
