using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FamilyTracker.Business.Infrastructure.Components.Interface;
using FamilyTracker.Business.Managers.Base.Interface;
using FamilyTracker.Business.Models.Base;
using FamilyTracker.Data.Entity.Base;
using FamilyTracker.Data.Repository.Base.Interface;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Business.Managers.Base.Implementation
{
    public abstract class CrudManager<TEntity, TModel> : BaseCrudManager<TEntity>, ICrudManager<TModel> where TEntity: class, IEntity
                                                                                                        where TModel : class, IModel
    {
        #region Fields



        #endregion

        #region Constructors

        protected CrudManager(IUnitOfWork unitOfWork, 
            IRepository<TEntity> repository, 
            IObjectMapper objectMapper) 
            : base(unitOfWork, repository, objectMapper)
        {
        }

        #endregion

        #region Interface members

        public virtual async Task<List<TModel>> GetAsync()
        {
            return ObjectMapper.Map<IQueryable<TEntity>, List<TModel>>(
                await Repository.GetAsync());
        }

        public virtual async Task<TModel> GetAsync(int id)
        {
            return ObjectMapper.Map<TEntity, TModel>(
                await Repository.GetAsync(id));
        }

        public virtual async Task<int> AddAsync(TModel model)
        {
            if (model == null) return 0;
            var entity = ObjectMapper.Map<TModel, TEntity>(model);
            await Repository.AddAsync(entity);
            await UnitOfWork.SaveChangesAsync();
            return entity.Id;

        }

        public virtual async Task UpdateAsync(TModel model)
        {
            if (model == null) return;
            await Repository.DetachAsync(
                await Repository.GetAsync(model.Id));

            await Repository.UpdateAsync(
                ObjectMapper.Map<TModel, TEntity>(model));

            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TModel model)
        {
            if (model == null) return;

            await Repository.DeleteAsync(
                ObjectMapper.Map<TModel, TEntity>(model));

            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);

            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task<bool> ExistAsync(int id)
        {
            return await Repository.ExistAsync(id);
        }

        #endregion
    }
}