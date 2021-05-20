using Microsoft.EntityFrameworkCore;
using SupermarketPrices.Domain.Repositories;
using SupermarketPrices.Infra.Context;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Infra.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly SupermarketPricesDbContext _dbContext;
        public BaseRepository(SupermarketPricesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Create(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(T Entity)
        {
            _dbContext.Remove(Entity);
            _dbContext.SaveChanges();
        }
    }
}
