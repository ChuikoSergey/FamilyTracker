using System.Web.Http;
using FamilyTracker.Business.Managers.Base.Interface;
using FamilyTracker.Business.Managers.Interface;
using FamilyTracker.Business.Models.Base;

namespace FamilyTracker.Web.Controllers.Base
{
    public abstract class BaseApiController<TModel> : ApiController where TModel:class, IModel
    {
        #region Fields

        private IManagerStore _managerStore;
        private ICrudManager<TModel> _manager;

        #endregion

        #region Constructors

        public BaseApiController(
            IManagerStore managerStore, ICrudManager<TModel> manager)
        {
            _managerStore = managerStore;
            _manager = manager;
        }

        #endregion

        #region Properties

        protected IManagerStore ManagerStore => _managerStore;
        protected ICrudManager<TModel> Manager => _manager;

        #endregion

        #region Interface members

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_manager != null)
                {
                    _manager.Dispose();
                    _manager = null;
                }
                if (_managerStore != null)
                {
                    _managerStore.Dispose();
                    _managerStore = null;
                }
            }

            base.Dispose(disposing);
        }

        #endregion
    }
}
