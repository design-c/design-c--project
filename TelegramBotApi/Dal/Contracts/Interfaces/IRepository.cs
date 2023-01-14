using Dal.Contracts.Models;

namespace Dal.Contracts.Interfaces;

public interface IRepository <TModel, TType> where TModel : BaseModel<TType>
{
        Task<IEnumerable<TModel>> GetAllAsync();
        Task<TModel?> FindAsync(TType id);
        Task CreateAsync(TModel item);
        Task<TModel> UpdateAsync(TModel item);
        Task DeleteAsync(TType id);
}