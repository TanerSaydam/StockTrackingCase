using StockTrackingCase.DataAccess.Context;
using StockTrackingCase.Entities.Repositories;
using System.Linq.Expressions;

namespace StockTrackingCase.DataAccess.Repositories;
public class Repository<TEntity>(ApplicationDbContext context) : IRepository<TEntity>
    where TEntity : class
{    
    public void Add(TEntity entity)
    {
        context.Add(entity);
    }

    public IQueryable<TEntity> GetAll()
    {
        return context.Set<TEntity>().AsQueryable();

    }

    public TEntity? GetByExpession(Expression<Func<TEntity, bool>> expression)
    {
        return context.Set<TEntity>().FirstOrDefault(expression);
    }

    public void Remove(TEntity entity)
    {
        context.Remove(entity);
    }

    public void Update(TEntity entity)
    {
        context.Update(entity);
    }
}
