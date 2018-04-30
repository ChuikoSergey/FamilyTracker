namespace FamilyTracker.Business.Infrastructure.Components.Interface
{
    public interface IObjectMapper
    {
        TTo Map<TFrom, TTo>(TFrom value);
    }
}