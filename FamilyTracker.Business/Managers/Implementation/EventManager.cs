using FamilyTracker.Business.Infrastructure.Components.Interface;
using FamilyTracker.Business.Managers.Base.Implementation;
using FamilyTracker.Business.Managers.Interface;
using FamilyTracker.Business.Models;
using FamilyTracker.Data.Entity;
using FamilyTracker.Data.Repository.Base.Interface;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Business.Managers.Implementation
{
    public class EventManager : CrudManager<Event, EventModel>, IEventManager
    {
        #region Consctructors

        public EventManager(
            IUnitOfWork unitOfWork, 
            IObjectMapper objectMapper) 
            : base(unitOfWork, unitOfWork.Events, objectMapper)
        {
        }

        #endregion

        #region Interface members



        #endregion
    }
}