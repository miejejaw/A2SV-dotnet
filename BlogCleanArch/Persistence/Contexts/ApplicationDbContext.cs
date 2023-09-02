using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;
public class AppDbContext : DbContext
{
    public DbSet<PostEntity> Posts { get; set; }
    public DbSet<CommentEntity> Comments { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
}