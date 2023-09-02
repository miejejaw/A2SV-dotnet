using MediatR;

namespace Application.Contracts.Common;

public interface IGenericRepository<T> where T : class
{
    //get all
    public Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);

    //get by id
    public Task<T> GetByIdAsync(int Id, CancellationToken cancellationToken);

    //exist
    public Task<bool> ExistAsync(int Id, CancellationToken cancellationToken);

    //create new
    public Task<T> CreateAsync(T entity, CancellationToken cancellationToken);


    //update 
    public Task<Unit> UpdateAsync(T oldEntity, T updateEntity,CancellationToken cancellationToken);


    //delete 
    public Task<Unit> DeleteAsync(T entity, CancellationToken cancellationToken);
}