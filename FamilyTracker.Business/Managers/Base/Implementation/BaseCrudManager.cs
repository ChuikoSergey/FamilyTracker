using FamilyTracker.Data.Entity.Base;
using FamilyTracker.Data.Repository.Base.Interface;
using FamilyTracker.Data.Repository.Interface;
using System;
using FamilyTracker.Business.Infrastructure.Components.Interface;

namespace FamilyTracker.Business.Managers.Base.Implementation
{
    public abstract class BaseCrudManager<TEntity> : IDisposable where TEntity : class, IEntity
    {
        #region Fields

        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<TEntity> _repository;
        private readonly IObjectMapper _objectMapper;

        #endregion

        #region Constructors

        protected BaseCrudManager(
            IUnitOfWork unitOfWork, 
            IRepository<TEntity> repository,
            IObjectMapper objectMapper)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _objectMapper = objectMapper;
        }

        #endregion

        #region Properties

        protected IUnitOfWork UnitOfWork => _unitOfWork;

        protected IRepository<TEntity> Repository => _repository;

        protected IObjectMapper ObjectMapper => _objectMapper;

        #endregion

        #region Interface members

        public virtual void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        #endregion
    }
}