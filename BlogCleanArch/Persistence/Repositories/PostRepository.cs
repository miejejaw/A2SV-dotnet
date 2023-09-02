
using Application.Contracts;
using Domain.Entities;
using Persistence.Contexts;
using Persistence.Repository.Common;

namespace Persistence.Repositories;
public class PostRepository : GenericRepository<PostEntity>,IPostRepository
{
    public PostRepository(AppDbContext dbContext) : base(dbContext)
    {

    }
}
