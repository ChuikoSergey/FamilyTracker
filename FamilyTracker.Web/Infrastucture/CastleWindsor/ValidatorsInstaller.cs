using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FamilyTracker.Web.Infrastucture.FluentValidator.Store.Implementations;
using FamilyTracker.Web.Infrastucture.FluentValidator.Store.Interfaces;

namespace FamilyTracker.Web.Infrastucture.CastleWindsor
{
    public class ValidatorsInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IValidatorStore>().Named(typeof(IValidatorStore).FullName)
                .ImplementedBy<ValidatorStore>().LifeStyle.Transient);

        }
    }
}