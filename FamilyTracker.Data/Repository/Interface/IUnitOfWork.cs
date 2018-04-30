using System;
using System.Threading.Tasks;

namespace FamilyTracker.Data.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();
    }
}