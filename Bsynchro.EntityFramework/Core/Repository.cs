using Bsynchro.Contracts.Repos;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Bsynchro.EntityFramework.Core
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly RJPDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(RJPDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            _entities.Update(entity);
        }

        public void Remove(T entity)
        {
            _entities.Remove(entity);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public IQueryable<T> Query()
        {
            return _entities.AsQueryable();
        }


    }

}