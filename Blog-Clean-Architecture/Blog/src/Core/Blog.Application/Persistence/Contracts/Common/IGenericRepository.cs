

namespace Blog.Application.Persistence.Contracts.Common;

public interface IGenericRepository<T> where T : class
{
    //get all
    public Task<IReadOnlyList<T>> GetAll();

    //get by id
    public Task<T> GetById(int Id);

    //exists
    public Task<bool> Exists(int Id);
    //create new
    public Task<T> CreateNew(T entity);


    //update 
    public Task Update(T entity);


    //delete 
    public Task Delete(T entity);
}