using System.Threading.Tasks;
using FamilyTracker.Business.Managers.Base.Interface;
using FamilyTracker.Business.Models.Base;
using FluentValidation;
using FluentValidation.Results;

namespace FamilyTracker.Web.Infrastucture.FluentValidator.Common
{
    public class ModelValidator<TModel>: AbstractValidator<TModel>, IModelValidator where TModel: class, IModel
    {
        protected readonly ValidationMode _mode;
        protected ICrudManager<TModel> _manager;

        protected ModelValidator(ICrudManager<TModel> manager, ValidationMode mode)
        {
            _mode = mode;
            _manager = manager;
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x => x.Id).GreaterThan(0).When(x => HasFlag(ValidationMode.None & ~(ValidationMode.Add | ValidationMode.DataRelevance)))
                .WithMessage("{PropertyName} can't be less or equal 0.");
            RuleFor(x => x.Id).MustAsync(async (id, token) => await ExistsAsync(id, _manager))
                .When(x => HasFlag(ValidationMode.Exist | ValidationMode.Delete | ValidationMode.Update))
                .WithMessage("{PropertyValue}th item isn't exists.");
        }

        public ValidationMode Mode => _mode;

        protected bool HasFlag(ValidationMode mode)
        {
            return mode.HasFlag(_mode);
        }

        protected Task<bool> ExistsAsync(int id, ICrudManager<TModel> manager)
        {
            return manager.ExistAsync(id);
        }

        public Task<ValidationResult> ValidateAsync(object value)
        {
            return Task.FromResult(Validate((TModel)value));
        }
    }
}