using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FamilyTracker.Business.Managers.Base.Interface;
using System.Linq;
using FamilyTracker.Business.Managers.Implementation;
using FamilyTracker.Business.Managers.Interface;

namespace FamilyTracker.Business.Infrastructure.CastleWindsor
{
    public class ManagersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IManagerStore>().ImplementedBy<ManagerStore>().LifeStyle.Transient);

            var allTypes = typeof(ManagersInstaller).Assembly.GetTypes();
            var interfaces = allTypes.Where(x => x.IsInterface && x.GetInterfaces()?.FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(ICrudManager<>)) != null);

            foreach (var type in interfaces)
            {
                container.Register(Component.For(type).Named(type.FullName).ImplementedBy(allTypes.FirstOrDefault(x => x.GetInterfaces().Contains(type))).LifeStyle.Transient);
            }
        }
    }
}
