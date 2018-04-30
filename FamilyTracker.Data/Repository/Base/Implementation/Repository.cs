using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FamilyTracker.Data.Entity.Base;
using FamilyTracker.Data.Repository.Base.Interface;

namespace FamilyTracker.Data.Repository.Base.Implementation
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Constructors

        protected Repository(DbContext context)
        {
            Context = context ?? throw new ArgumentException("Context == null.");
            DbSet = Context.Set<TEntity>();
        }

        #endregion

        #region Properties

        protected DbSet<TEntity> DbSet { get; set; }
        protected DbContext Context { get; set; }

        #endregion

        #region Interface members

        public Task<IQueryable<TEntity>> GetAsync()
        {
            return Task.FromResult(Include());
        }

        public Task<TEntity> GetAsync(int id)
        {
            return Task.FromResult(Include().FirstOrDefault(entity => entity.Id == id));
        }

        public Task AddAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() =>
            {
                var entry = Context.Entry(entity);
                if (entry.State != EntityState.Detached)
                {
                    entry.State = EntityState.Added;
                }
                else
                {
                    DbSet.Add(entity);
                }
            });
        }

        public Task UpdateAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() =>
            {
                var entry = Context.Entry(entity);
                if (entry.State == EntityState.Detached)
                {
                    DbSet.Attach(entity);
                }
                entry.State = EntityState.Modified;
            });
        }

        public Task DetachAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() =>
            {
                var entry = Context.Entry(entity);
                entry.State = EntityState.Detached;
            });
        }

        public Task DeleteAsync(TEntity entity)
        {
            return Task.Factory.StartNew(() =>
            {
                var entry = Context.Entry(entity);
                if (entry.State != EntityState.Detached)
                {
                    DbSet.Remove(entity);
                }
            });
        }

        public Task DeleteAsync(int id)
        {
            return Task.Factory.StartNew(async () =>
            {
                var entity = DbSet.FirstOrDefault(e => e.Id == id);
                if (entity != null)
                {
                    await DeleteAsync(id);
                }
            });
        }

        public Task<bool> ExistAsync(int id)
        {
            return Task.FromResult(DbSet.Any(entity => entity.Id == id));
        }

        public void Dispose()
        {
            Context?.Dispose();
            Context = null;
        }

        #endregion

        #region Helpers

        protected IQueryable<TEntity> Include()
        {
            return DbSet;
        }

        #endregion
    }
}