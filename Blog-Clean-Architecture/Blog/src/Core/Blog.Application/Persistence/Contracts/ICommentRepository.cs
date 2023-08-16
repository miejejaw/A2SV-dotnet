using Blog.Application.Persistence.Contracts.Common;
using Blog.Domain.Entities;

namespace Blog.Application.Persistence.Contracts;

public interface ICommentRepository : IGenericRepository<Comment>
{

}
