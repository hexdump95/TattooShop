namespace Tattoo.Repositories.Interfaces
{
    public interface IRepository<TEntity, in TKey>
    {
        Task<List<TEntity>> FindAll();
        Task<TEntity?> FindById(TKey id);
        Task<TEntity> Save(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
    }
}
