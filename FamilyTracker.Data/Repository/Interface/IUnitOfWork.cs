using System;
using System.Threading.Tasks;

namespace FamilyTracker.Data.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IEventRepository Events { get; }
        ILogRepository Logs { get; }
        IMarkerRepository Markers { get; }
        IPersonRepository Persons { get; }
        IUserRepository Users { get; }
        IZoneRepository Zones { get; }
        Task<int> SaveChangesAsync();
    }
}