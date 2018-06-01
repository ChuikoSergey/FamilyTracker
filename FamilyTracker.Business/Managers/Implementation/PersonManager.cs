using FamilyTracker.Business.Infrastructure.Components.Interface;
using FamilyTracker.Business.Managers.Base.Implementation;
using FamilyTracker.Business.Managers.Interface;
using FamilyTracker.Business.Models;
using FamilyTracker.Data.Entity;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Business.Managers.Implementation
{
    public class PersonManager : CrudManager<Person, PersonModel>, IPersonManager
    {
        #region Consctructors

        public PersonManager(
            IUnitOfWork unitOfWork, 
            IObjectMapper objectMapper)
            : base(unitOfWork, unitOfWork.Persons, objectMapper)
        {
        }

        #endregion

        #region Interface members



        #endregion
    }
}