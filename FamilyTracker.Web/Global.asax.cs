using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;
using System.Web.Mvc;
using System.Web.Optimization;
using AutoMapper;
using Castle.Windsor;
using FamilyTracker.Business.Infrastructure.CastleWindsor;
using FamilyTracker.Web.Infrastucture.CastleWindsor;

namespace FamilyTracker.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private readonly IWindsorContainer _container;

        public WebApiApplication()
        {
            _container = new WindsorContainer();
            _container.Install(
                new ControllerInstaller(),
                new ManagersInstaller(),
                new RepositoriesInstaller(),
                new ValidatorsInstaller());

            ServiceLocator.Current.SetLocatorProvider(_container);
        }

        protected void Application_Start()
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), 
                new WindsorCompositionRoot(_container));
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            InitializeAutoMapper();
        }

        private void InitializeAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith("TBT")))
                {
                    foreach (var profile in assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(typeof(Profile))))
                    {
                        cfg.AddProfile((Profile)Activator.CreateInstance(profile, null));
                    }
                }
            });
        }

        public override void Dispose()
        {
            _container.Dispose();
            base.Dispose();
        }
    }
}
