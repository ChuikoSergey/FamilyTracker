using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using FamilyTracker.Business.Managers.Base.Interface;
using FamilyTracker.Business.Managers.Interface;
using FamilyTracker.Business.Models.Base;
using FamilyTracker.Web.Filters.ValidationFilters.Base;
using FamilyTracker.Web.Infrastucture.FluentValidator.Attributes;
using FamilyTracker.Web.Infrastucture.FluentValidator.Common;

namespace FamilyTracker.Web.Controllers.Base
{
    public abstract class BaseCrudApiController<TModel> : ApiController
        where TModel: class, IModel
    {
        #region Fields

        private IManagerStore _managerStore;
        private ICrudManager<TModel> _manager;

        #endregion

        #region Properties

        protected IManagerStore ManagerStore => _managerStore;
        protected ICrudManager<TModel> Manager => _manager;

        #endregion

        #region Constructors

        protected BaseCrudApiController(
            IManagerStore managerStore,
            ICrudManager<TModel> manager)
        {
            _managerStore = managerStore;
            _manager = manager;
        }

        #endregion

        #region Actions

        [HttpGet]
        [Route("")]
        [ModelValidationFilter]
        public virtual async Task<HttpResponseMessage> GetAsync()
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await Manager.GetAsync());
        }

        [HttpGet]
        [Route("{id:int:min(1)}")]
        [ModelValidationFilter]
        public virtual async Task<HttpResponseMessage> GetAsync(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK,
                await Manager.GetAsync(id));
        }

        [HttpPost]
        [Route("")]
        [ModelValidationFilter]
        public virtual async Task<HttpResponseMessage> GetAsync([Validator(ValidationMode.Add)]TModel model)
        {
            await Manager.AddAsync(model);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpPut]
        [Route("")]
        [ModelValidationFilter]
        public virtual async Task<HttpResponseMessage> UpdateAsync([Validator(ValidationMode.Update)]TModel model)
        {
            await Manager.UpdateAsync(model);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [HttpDelete]
        [Route("{id:int:min(1)}")]
        [ModelValidationFilter]
        public virtual async Task<HttpResponseMessage> DeleteAsync([Validator(ValidationMode.Exist)]int id)
        {
            await Manager.DeleteAsync(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

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