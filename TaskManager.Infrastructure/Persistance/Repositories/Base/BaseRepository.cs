using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Abstraction.Interfaces.Repositories.Base;
using TaskManager.Domain.Models.BaseModel;
using TaskManager.Infrastructure.Persistance.Context;

namespace TaskManager.Infrastructure.Persistance.Repositories.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _context;
    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(T model)
    {
        await _context.Set<T>().AddAsync(model);
    }

    public async Task DeleteAsync(int id)
    {
        var model = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        
        if (model is null)
            return;

        _context.Set<T>().Remove(model);

        await _context.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        var models = await _context.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
        return models;
    }

    public async Task<T> GetByIdAsync(int Id)
    {
        var model = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);
        
        if (model is null)
            throw new Exception();

        return model;
    }

    public async Task UpdateAsync(T model)
    {
        model.UpdateDate = DateTime.Now;
        _context.Set<T>().Update(model);
    }
}
