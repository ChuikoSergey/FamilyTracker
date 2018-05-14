using Castle.Windsor;

namespace FamilyTracker.Business.Infrastructure.CastleWindsor
{
    public class ServiceLocator
    {
        private static ServiceLocator _instance;
        private IWindsorContainer _serviceContainer;

        private ServiceLocator()
        { }

        public static ServiceLocator Current => _instance ?? (_instance = new ServiceLocator());

        public void SetLocatorProvider(IWindsorContainer container)
        {
            _serviceContainer = container;
        }

        public T Get<T>()
        {
            return _serviceContainer.Resolve<T>();
        }

        public T Get<T>(object arguments)
        {
            return _serviceContainer.Resolve<T>(arguments);
        }

        public T Get<T>(string name, object args)
        {
            return _serviceContainer.Resolve<T>(name, args);
        }
    }
}