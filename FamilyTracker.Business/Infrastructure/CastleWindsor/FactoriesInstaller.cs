using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FamilyTracker.Business.Infrastructure.Components.Implementation;
using FamilyTracker.Business.Infrastructure.Components.Interface;

namespace FamilyTracker.Business.Infrastructure.CastleWindsor
{
    public class FactoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddFacility<TypedFactoryFacility>();
            container.Register(Component.For<IManagerFactory>().AsFactory(c => c.SelectedWith(new FactoryComponentSelector())).LifeStyle.Transient);
        }
    }
}