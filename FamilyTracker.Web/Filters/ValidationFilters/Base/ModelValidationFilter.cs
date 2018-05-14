using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using FamilyTracker.Business.Infrastructure.CastleWindsor;
using FamilyTracker.Business.Models.Base;
using FamilyTracker.Web.Infrastucture.FluentValidator.Attributes;
using FamilyTracker.Web.Infrastucture.FluentValidator.Store.Interfaces;

namespace FamilyTracker.Web.Filters.ValidationFilters.Base
{
    public class ModelValidationFilter : ActionFilterAttribute
    {
        protected IValidatorStore _validatorStore;

        public override async Task OnActionExecutingAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            if (_validatorStore == null) { _validatorStore = ServiceLocator.Current.Get<IValidatorStore>(); }
            var type = default(Type);
            var model = default(object);
            foreach (var parameter in actionContext.ActionDescriptor.GetParameters().Where(x => x.GetCustomAttributes<object>().OfType<Validator>().Any()))
            {
                if (parameter.ParameterName == "id")
                {
                    var temp = ((ReflectedHttpActionDescriptor)actionContext.ActionDescriptor).MethodInfo.DeclaringType.GetGenericArguments();
                    type = temp.Any() ? temp[0] : ((ReflectedHttpActionDescriptor)actionContext.ActionDescriptor).MethodInfo.DeclaringType.BaseType.GetGenericArguments()[0];
                    model = (IModel)Activator.CreateInstance(type);
                    ((IModel)model).Id = (int)actionContext.ActionArguments[parameter.ParameterName];
                }
                if (parameter.ParameterType.GetInterface("IModel") != null)
                {
                    type = actionContext.ActionArguments[parameter.ParameterName].GetType();
                    model = actionContext.ActionArguments[parameter.ParameterName];
                }
                if (type == default(Type)) { continue; }
                var attribute = parameter.GetCustomAttributes<object>().OfType<Validator>().FirstOrDefault();
                var validator = _validatorStore.GetValidator(attribute.Mode, type);
                var result = await validator.ValidateAsync(model);
                //if (!result.IsValid)
                //{
                //    throw new ApiValidationException(string.Join(Environment.NewLine, result.Errors));
                //}
            }
        }
    }
}