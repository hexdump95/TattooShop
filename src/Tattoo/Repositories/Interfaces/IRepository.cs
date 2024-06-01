namespace Tattoo.Repositories.Interfaces
{
    public interface IRepository<T, K>
    {
        Task<List<T>> FindAll();
        Task<T?> FindById(K id);
        Task<T> Save(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
    }
}
