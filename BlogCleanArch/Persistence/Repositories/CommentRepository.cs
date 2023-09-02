
using Application.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repository.Common;

namespace Persistence.Repositories;
public class CommentRepository : GenericRepository<CommentEntity>, ICommentRepository
{
    public new readonly AppDbContext _dbContext;
    public CommentRepository(AppDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<CommentEntity>> GetCommentByPostId(int postId)
    {
        return await _dbContext.Comments.Where(comment => comment.PostId == postId)
                                        .ToListAsync();
    }
}
