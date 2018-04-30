using System;
using System.Linq;
using System.Threading.Tasks;
using FamilyTracker.Data.Entity.Base;

namespace FamilyTracker.Data.Repository.Base.Interface
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class, IEntity
    {
        Task<IQueryable<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DetachAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}