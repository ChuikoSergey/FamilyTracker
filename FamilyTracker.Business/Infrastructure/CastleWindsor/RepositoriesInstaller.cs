using System.Data.Entity;
using System.Linq;
using AutoMapper;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using FamilyTracker.Business.Infrastructure.Components.Implementation;
using FamilyTracker.Data.Context;
using FamilyTracker.Data.Repository.Base.Interface;
using FamilyTracker.Data.Repository.Implementation;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Business.Infrastructure.CastleWindsor
{
    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().LifeStyle.Transient);

            //container.Register(Component.For<IRepositoryFactory>().AsFactory(r => r.SelectedWith(new FactoryComponentSelector())).LifeStyle.Transient);

            container.Register(Component.For<DbContext>().ImplementedBy<DataContext>()
                .DependsOn(Dependency.OnAppSettingsValue("connectionString", "FamilyTrackerConnectionString")).LifeStyle.Transient);

            var allTypes = typeof(RepositoriesInstaller).Assembly.GetTypes();
            var interfaces = allTypes.Where(x => x.IsInterface && x.GetInterfaces()?.FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRepository<>)) != null);

            foreach (var type in interfaces)
            {
                container.Register(Component.For(type).Named(type.FullName).ImplementedBy(allTypes.FirstOrDefault(x => x.GetInterfaces().Contains(type))).LifeStyle.Transient);
            }
        }
    }
}