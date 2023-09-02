using Application.Contracts.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repository.Common;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public readonly AppDbContext _dbContext;
    public GenericRepository(AppDbContext dbContext){
        _dbContext = dbContext;
    }

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _dbContext.Set<T>().AddAsync(entity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task<Unit> DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }

    public async Task<bool> ExistAsync(int Id, CancellationToken cancellationToken)
    {
        var res = await _dbContext.Set<T>().FindAsync(Id);
        return res != null;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task<T> GetByIdAsync(int Id, CancellationToken cancellationToken)
    {
        return await _dbContext.Set<T>().FindAsync(Id,cancellationToken);
    }

    public async Task<Unit> UpdateAsync(T old_entity, T update_entity, CancellationToken cancellationToken)
    {
        _dbContext.Entry(old_entity).CurrentValues.SetValues(update_entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}