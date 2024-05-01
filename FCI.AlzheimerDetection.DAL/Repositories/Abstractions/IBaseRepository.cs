using System.Linq.Expressions;

namespace FCI.AlzheimerDetection.DAL.Repositories.Abstractions;

public interface IBaseRepository<T> where T : class
{
    T? GetById(int id);

    IQueryable<T> GetAll();

    IQueryable<T> GetAllWithPaging(int pageNumber, int pageSize);

    IQueryable<T> FindAll(Expression<Func<T, bool>> key);

    void Create(T entity);

    void Update(T entity);

    void Delete(T entity);
}