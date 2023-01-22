namespace PlatformCommon.Data;

public interface IRepository<TEntity,IKey>
{
    bool SaveChanges();
    Task<bool> SaveChangesAsync();

    IEnumerable<TEntity> GetAll();
    Task<IEnumerable<TEntity>> GetAllAsync();

    TEntity? Get(IKey id);
    Task<TEntity?> GetAsync(IKey id);

    void Create(TEntity entity);
    Task CreateAsync(TEntity entity);
}