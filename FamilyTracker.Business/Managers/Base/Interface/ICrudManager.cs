using FamilyTracker.Business.Models.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FamilyTracker.Business.Managers.Base.Interface
{
    public interface ICrudManager<TModel> where TModel : class, IModel
    {
        Task<List<TModel>> GetAsync();
        Task<TModel> GetAsync(int id);
        Task<int> AddAsync(TModel model);
        Task UpdateAsync(TModel model);
        Task DeleteAsync(TModel model);
        Task DeleteAsync(int id);
        Task<bool> ExistAsync(int id);
    }
}