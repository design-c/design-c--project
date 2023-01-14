using Dal.Contracts.Interfaces;
using Dal.Contracts.Models;
using Microsoft.EntityFrameworkCore;

namespace Dal.Implementations.Repositories;

public class BaseRepository<TModel, TType> : IRepository<TModel, TType> where TModel : BaseModel<TType>
{
    protected readonly DbContext DbContext;
    protected DbSet<TModel> DbSet => DbContext.Set<TModel>();
    
    public BaseRepository(DbContext context)
    {
        DbContext = context;
    }
    

    public virtual async Task<IEnumerable<TModel>> GetAllAsync() => await DbSet.ToListAsync();

    public virtual async Task<TModel?> FindAsync(TType id) => await DbSet.FindAsync(id);

    public virtual async Task CreateAsync(TModel item)
    {
        await DbSet.AddAsync(item);
        await DbContext.SaveChangesAsync();
    }

    public virtual async Task<TModel> UpdateAsync(TModel item)
    {
        var model = DbSet.Update(item).Entity;
        await DbContext.SaveChangesAsync();

        return model;
    }

    public virtual async Task DeleteAsync(TType id)
    {
        var item = await FindAsync(id);
        if (item == null)
            return;

        DbSet.Remove(item);
        await DbContext.SaveChangesAsync();
    }
}