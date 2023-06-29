using Domain.Core.Models;
using System.Linq.Expressions;

namespace Application.Core.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        IBaseRepositoryAsync<T> Repository<T>() where T : BaseEntity;
        Task<T> LoadRelatedEntity<T>(T entity, params Expression<Func<T, object>>[] includes) where T : BaseEntity;
    }
}