using System.Collections.Generic;
using System.Threading.Tasks;

namespace SupermarketPrices.Domain.Repositories
{
    public interface IRepository<T>
    {
        void Create(T entity);
        void Update(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
        void Delete(T Entity);
    }
}
