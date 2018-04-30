using FamilyTracker.Business.Infrastructure.Components.Interface;

namespace FamilyTracker.Business.Infrastructure.Components.Implementation
{
    public class ObjectMapper : IObjectMapper
    {
        public TTo Map<TFrom, TTo>(TFrom value)
        {
            return AutoMapper.Mapper.Map<TFrom, TTo>(value);
        }
    }
}
