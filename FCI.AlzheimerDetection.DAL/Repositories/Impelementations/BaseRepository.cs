using FCI.AlzheimerDetection.DAL.Context;
using FCI.AlzheimerDetection.DAL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FCI.AlzheimerDetection.DAL.Repositories.Impelementations;

public class BaseRepository<TModel>
    : IBaseRepository<TModel> where TModel : class
{
    private readonly AlzheimerDetectionDbContext _context;

    public BaseRepository(AlzheimerDetectionDbContext context)
    {
        _context = context;
    }

    public void Create(TModel entity) => _context.Set<TModel>().Add(entity);

    public void Delete(TModel entity) => _context.Set<TModel>().Remove(entity);

    public IQueryable<TModel> FindAll(Expression<Func<TModel, bool>> key) => _context.Set<TModel>()
        .Where(key)
        .AsNoTracking()
        .AsQueryable();

    public IQueryable<TModel> GetAll() => _context.Set<TModel>()
        .AsNoTracking()
        .AsQueryable();

    public IQueryable<TModel> GetAllWithPaging(int pageNumber, int pageSize) => _context.Set<TModel>()
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize);

    public TModel? GetById(int id) => _context.Set<TModel>().Find(id);

    public void Update(TModel entity) => _context.Set<TModel>().Update(entity);
}