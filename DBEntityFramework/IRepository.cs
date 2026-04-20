namespace DBEntityFramework;

public interface IRepository<TEntity>
{
    public IEnumerable<TEntity> GetAll();
    public TEntity GetById(int id);
    public void Add(TEntity entity);
    public void Update(TEntity entity);
    public void Delete(TEntity entity);
    public void Save();
}