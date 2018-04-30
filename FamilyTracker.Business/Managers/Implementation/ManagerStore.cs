using FamilyTracker.Business.Infrastructure.Components.Interface;
using FamilyTracker.Business.Managers.Interface;

namespace FamilyTracker.Business.Managers.Implementation
{
    public class ManagerStore : IManagerStore
    {
        private IManagerFactory _managerFactory;

        #region Fields



        #endregion

        #region Constructors

        public ManagerStore(IManagerFactory managerFactory)
        {
            _managerFactory = managerFactory;
        }

        #endregion

        #region Interface members

        public void Dispose()
        {
        }

        #endregion
    }
}