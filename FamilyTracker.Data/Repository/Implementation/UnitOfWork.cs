using System.Data.Entity;
using System.Threading.Tasks;
using FamilyTracker.Data.Repository.Interface;

namespace FamilyTracker.Data.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Fields

        private DbContext _context;

        #endregion

        #region Contructors

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        #endregion

        #region Interface members

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