using System.Reflection;
using Castle.Facilities.TypedFactory;

namespace FamilyTracker.Business.Infrastructure.Components.Implementation
{
    public class FactoryComponentSelector : DefaultTypedFactoryComponentSelector
    {
        protected override string GetComponentName(MethodInfo method, object[] arguments)
        {
            return (string)arguments[0];
        }
    }
}