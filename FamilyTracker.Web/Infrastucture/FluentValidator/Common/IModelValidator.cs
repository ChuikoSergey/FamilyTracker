using System.Threading.Tasks;
using FluentValidation.Results;

namespace FamilyTracker.Web.Infrastucture.FluentValidator.Common
{
    public interface IModelValidator
    {
        Task<ValidationResult> ValidateAsync(object value);
        ValidationMode Mode { get; }
    }
}