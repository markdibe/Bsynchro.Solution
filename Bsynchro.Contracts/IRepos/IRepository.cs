using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bsynchro.Contracts.Repos
{
    public interface IRepository<T> where T : class
    {
        Task Add(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task<T> GetByIdAsync(Guid id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Query();
    }
}
