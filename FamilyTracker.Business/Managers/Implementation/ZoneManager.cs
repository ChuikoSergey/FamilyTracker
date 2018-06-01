using FamilyTracker.Business.Infrastructure.Components.Interface;
using FamilyTracker.Business.Managers.Base.Implementation;
using FamilyTracker.Business.Managers.Interface;
using FamilyTracker.Business.Models;
using FamilyTracker.Data.Entity;
using FamilyTracker.Data.Repository.Base.Interface;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Business.Managers.Implementation
{
    public class ZoneManager : CrudManager<Zone, ZoneModel>, IZoneManager
    {
        #region Consctructors

        public ZoneManager(
            IUnitOfWork unitOfWork, 
            IObjectMapper objectMapper)
            : base(unitOfWork, unitOfWork.Zones, objectMapper)
        {
        }

        #endregion

        #region Interface members



        #endregion
    }
}