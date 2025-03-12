using Academy.Domain.Entities;
using System.Linq.Expressions;

namespace Academy.Application.Repositories;

public interface IRepository<T> where T : Entity
{
    T Get(Func<T, bool> predicate);
    List<T> GetAll(Expression<Func<T, bool>>? predicate = null);
    void Add(T entity);
    void Remove(int id);
    void Update(int id, T entity);
}
