using System.Data.Entity;
using FamilyTracker.Data.Entity;
using FamilyTracker.Data.Repository.Base.Implementation;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Data.Repository.Implementation
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        #region Consctructors

        public EventRepository(DbContext context) : base(context)
        {
        }

        #endregion

        #region Interface members



        #endregion
    }
}