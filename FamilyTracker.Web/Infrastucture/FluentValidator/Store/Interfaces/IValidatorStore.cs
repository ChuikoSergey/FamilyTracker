using System;
using FamilyTracker.Web.Infrastucture.FluentValidator.Common;

namespace FamilyTracker.Web.Infrastucture.FluentValidator.Store.Interfaces
{
    public interface IValidatorStore
    {
        IModelValidator GetValidator(ValidationMode mode, Type model);
    }
}