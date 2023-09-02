using Application.Contracts.Common;
using Domain.Entities;

namespace Application.Contracts;

public interface ICommentRepository : IGenericRepository<CommentEntity>
{
    Task<IReadOnlyList<CommentEntity>> GetCommentByPostId(int postId);
}

