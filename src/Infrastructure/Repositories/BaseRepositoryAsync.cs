using Microsoft.EntityFrameworkCore;
using Domain.Core.Specifications;
using Domain.Core.Models;
using Application.Core.Repositories;
using Domain.Exceptions;

namespace Infrastructure.Repositories
{
    public class BaseRepositoryAsync<T> : IBaseRepositoryAsync<T> where T : BaseEntity
    {
        protected readonly ErpDbContext  _dbContext;

        public BaseRepositoryAsync(ErpDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<IList<T>> ListAllAsync(bool allowTracking)
        {
            if (allowTracking)
            {
                return await _dbContext.Set<T>().ToListAsync();
            }
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<IList<T>> ListAsync(ISpecification<T> spec, bool allowTracking)
        {
            if (allowTracking)
            {
                return await ApplySpecification(spec).ToListAsync();
            }
            return await ApplySpecification(spec).AsNoTracking().ToListAsync();
        }
        public async Task<T?> FirstOrDefaultAsync(ISpecification<T> spec, bool allowTracking)
        {
            if (allowTracking)
            {
                return await ApplySpecification(spec).FirstOrDefaultAsync();
            }
            return await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync();
        }

        public async Task<T> SingleAsync(ISpecification<T> spec, bool allowTracking)
        {
            T? item;
            if (allowTracking)
            {
                item = await ApplySpecification(spec).FirstOrDefaultAsync();
            }
            else
            {
                item = await ApplySpecification(spec).AsNoTracking().FirstOrDefaultAsync();
            }
            if (item == null)
            {
                throw new RecordNotFoundException(string.Format("{0} Not Found", typeof(T).Name));
            }
            return item;
        }
    }
}
