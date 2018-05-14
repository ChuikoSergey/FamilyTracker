using System;
using System.Collections.Generic;
using System.Linq;
using FamilyTracker.Business.Infrastructure.CastleWindsor;
using FamilyTracker.Web.Infrastucture.FluentValidator.Common;
using FamilyTracker.Web.Infrastucture.FluentValidator.Store.Interfaces;

namespace FamilyTracker.Web.Infrastucture.FluentValidator.Store.Implementations
{
    public class ValidatorStore : IValidatorStore
    {
        #region Fields

        private readonly IEnumerable<Type> _availbleTypes;

        #endregion

        #region Constructor

        public ValidatorStore()
        {
            _availbleTypes = typeof(ValidatorStore).Assembly.GetTypes().Where(x => x.GetInterface(nameof(IModelValidator)) != null);
        }

        #endregion

        #region Interface members

        public IModelValidator GetValidator(ValidationMode mode, Type model)
        {
            return ServiceLocator.Current.Get<IModelValidator>(_availbleTypes.FirstOrDefault(x => x.BaseType.GetGenericArguments()[0] == model)?.Name, new { mode = mode });
        }

        #endregion
    }
}