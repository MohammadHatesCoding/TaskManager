using Microsoft.EntityFrameworkCore;
using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;

namespace TaskManager.Infrastructure.Persistance.Repositories;

public class AttachmentRepository : IAttachmentRepository
{
    private readonly ApplicationDbContext _context;
    public AttachmentRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task CreateAsync(Attachment model)
    {
        await _context.Set<Attachment>().AddAsync(model);
    }

    public async Task DeleteAsync(Guid id)
    {
        var model = await _context.Set<Attachment>().FirstOrDefaultAsync(x => x.Id == id);

        if (model is null)
            return;

        model.IsDeleted = true;
    }

    public async Task<List<Attachment>> GetAllAsync()
    {
        var models = await _context.Set<Attachment>().Where(x => !x.IsDeleted).ToListAsync();
        return models;
    }

    public async Task<Attachment> GetByIdAsync(Guid Id)
    {
        var model = await _context.Set<Attachment>().FirstOrDefaultAsync(x => x.Id == Id && !x.IsDeleted);

        if (model is null)
            throw new Exception();

        return model;
    }
}
