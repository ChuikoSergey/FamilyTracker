using System.Data.Entity;
using System.Threading.Tasks;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Data.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private DbContext _context;
        private IEventRepository _eventRepository;
        private ILogRepository _logRepository;
        private IMarkerRepository _markerRepository;
        private IPersonRepository _personRepository;
        private IUserRepository _userRepository;
        private IZoneRepository _zoneRepository;

        #endregion

        #region Contructors

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Interface members

        public IEventRepository Events => _eventRepository ?? (_eventRepository = new EventRepository(_context));
        public ILogRepository Logs => _logRepository ?? (_logRepository = new LogRepository(_context));
        public IMarkerRepository Markers => _markerRepository ?? (_markerRepository = new MarkerRepository(_context));
        public IPersonRepository Persons => _personRepository ?? (_personRepository = new PersonRepository(_context));
        public IUserRepository Users => _userRepository ?? (_userRepository = new UserRepository(_context));
        public IZoneRepository Zones => _zoneRepository ?? (_zoneRepository = new ZoneRepository(_context));


        public void Dispose()
        {
            _context?.Dispose();
            _context = null;
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }


        #endregion
    }
}