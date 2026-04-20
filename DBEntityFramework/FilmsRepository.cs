using Microsoft.EntityFrameworkCore;
namespace DBEntityFramework;

public class FilmsRepository<TEntity> : IRepository<TEntity> where TEntity : class
{
    private FilmsManagerDBContext _context;
    private DbSet<TEntity> _dbSet;
    public FilmsRepository(FilmsManagerDBContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }

    public IEnumerable<TEntity> GetAll()
    {
        return _dbSet.ToList();
    }

    public TEntity GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public void Save()
    {
        _context.SaveChanges();
    }

}