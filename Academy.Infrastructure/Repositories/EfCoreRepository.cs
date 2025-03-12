using Academy.Application.Repositories;
using Academy.Domain.Entities;
using Academy.Infrastructure.EfCore;
using System.Linq.Expressions;

namespace Academy.Infrastructure.Repositories;

public class EfCoreRepository<T> : IRepository<T> where T : Entity
{
    private readonly AppDbContext _context;

    public EfCoreRepository(AppDbContext context)
    {
        _context = context;
    }

    public virtual void Add(T entity)
    {
        _context.Set<T>().Add(entity);
        _context.SaveChanges();
    }

    public virtual T Get(Func<T, bool> predicate)
    {
        return _context.Set<T>().FirstOrDefault(predicate);
    }

    public virtual List<T> GetAll(Expression<Func<T, bool>>? predicate = null)
    {
        IQueryable<T> query = _context.Set<T>();

        if (predicate != null)
            query = query.Where(predicate);

        return query.ToList();
    }

    public virtual void Remove(int id)
    {
        var existEntity = _context.Set<T>().Find(id);

        if (existEntity == null)
            throw new Exception("Not found");

        _context.Set<T>().Remove(existEntity);
        _context.SaveChanges();
    }

    public virtual void Update(int id, T entity)
    {
        var existEntity = _context.Set<T>().Find(id);

        if (existEntity == null)
            throw new Exception("Not found");

        existEntity = entity;
        existEntity.Id = id;
        _context.Set<T>().Update(existEntity);
    }
}