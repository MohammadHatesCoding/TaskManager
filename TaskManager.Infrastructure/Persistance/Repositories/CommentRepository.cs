using TaskManager.Business.Abstraction.Interfaces.Repositories;
using TaskManager.Domain.Models;
using TaskManager.Infrastructure.Persistance.Context;
using TaskManager.Infrastructure.Persistance.Repositories.Base;

namespace TaskManager.Infrastructure.Persistance.Repositories;

public class CommentRepository : BaseRepository<Comment>, ICommentRepository
{
    private readonly ApplicationDbContext _context;
    public CommentRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
}
