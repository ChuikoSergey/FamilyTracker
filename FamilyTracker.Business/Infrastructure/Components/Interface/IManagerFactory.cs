namespace FamilyTracker.Business.Infrastructure.Components.Interface
{
    public interface IManagerFactory
    {
        T Create<T>(string managerName);
    }
}