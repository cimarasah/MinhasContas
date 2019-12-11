using Microsoft.EntityFrameworkCore;
using MinhasContas.DAL.Interface.Entities;
using MinhasContas.DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinhasContas.DAL.Repository
{
    public class Repository<TContext, TEntity> : IRepository<TEntity>
        where TContext : DbContext
        where TEntity : BaseEntity
    {
        protected TContext context;

        public Repository(TContext context) : base() =>
            this.context = context;

        //private IQueryable<TEntity> GetQueryableWithSpecification(IQuerySpecification<TEntity> specification)
        //{
        //    var query = context
        //        .Set<TEntity>()
        //        .Where(specification.Criteria);

        //    if (specification.OrderBy != null)
        //    {
        //        if (!specification.OrderDescending)
        //        {
        //            query = query.OrderBy(specification.OrderBy);
        //        }
        //        else
        //        {
        //            query = query.OrderByDescending(specification.OrderBy);
        //        }
        //    }

        //    var queryable = specification
        //        .Includes.Aggregate(query.AsQueryable(),
        //            (current, include) => current.Include(include));

        //    var aggregatedQueryable = specification
        //        .IncludeStrings.Aggregate(queryable,
        //            (current, include) => current.Include(include));

        //    return aggregatedQueryable;
        //}

        //public Task<TEntity> GetOneAsync(IQuerySpecification<TEntity> specification) =>
        //    GetQueryableWithSpecification(specification)
        //        .FirstOrDefaultAsync();

        //public Task<TEntity> GetLastAsync(IQuerySpecification<TEntity> specification) =>
        //    GetQueryableWithSpecification(specification)
        //        .LastOrDefaultAsync();

        public Task<TEntity> GetOneAsync(long id) =>
            context.Set<TEntity>()
                .FirstOrDefaultAsync(e => e.Id == id);

        //public async Task<IReadOnlyList<TEntity>> GetAsync(IQuerySpecification<TEntity> specification) =>
        //    (await GetQueryableWithSpecification(specification)
        //        .ToListAsync())
        //    .AsReadOnly();

        //public async Task<IReadOnlyList<TEntity>> GetAsync(IPagedListSpecification<TEntity> pagedListSpecification) =>
        //    (await GetQueryableWithSpecification(pagedListSpecification as IQuerySpecification<TEntity>)
        //        .Paging(pagedListSpecification)
        //        .ToListAsync())
        //    .AsReadOnly();

        public Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria) =>
            context.Set<TEntity>()
                .Where(criteria)
                .CountAsync();

        public async Task<TEntity> AddAsync(TEntity entity) =>
            (await context.Set<TEntity>()
                .AddAsync(entity)).Entity;

        public void AddAsync(IEnumerable<TEntity> entities) =>
            context.Set<TEntity>()
                .AddRangeAsync(entities);

        public TEntity Update(TEntity entity) =>
            context.Update(entity).Entity;

        public TEntity Update(TEntity entity, TEntity source)
        {
            var values = source.GetType()
                .GetProperties()
                .Where(p => p.Name != "Id")
                .ToDictionary(p => p.Name, p => p.GetValue(source));
            context.Entry(entity)
                .CurrentValues
                .SetValues(values);
            return Update(entity);
        }

        public void Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            Update(entity);
        }

        public void HardDelete(TEntity entity)
        {
            context.Remove(entity);
        }

        //public async Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, int page, int size, bool descending, Expression<Func<TEntity, object>> orderby)
        //{
        //    var query = context
        //                .Set<TEntity>()
        //                .Where(specification.ToExpression())
        //                .Skip((page - 1) * size)
        //                .Take(size);

        //    if (descending)
        //        query = query.OrderByDescending(orderby);
        //    else
        //        query = query.OrderBy(orderby);

        //    return (await query.ToListAsync()).AsReadOnly();
        //}

        //public async Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification)
        //{
        //    var query = context
        //                .Set<TEntity>()
        //                .Where(specification.ToExpression());

        //    return (await query.ToListAsync()).AsReadOnly();
        //}

        //public async Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, int page, int size, bool descending, Expression<Func<TEntity, object>> orderby, List<Expression<Func<TEntity, object>>> includes)
        //{
        //    var query = context
        //                .Set<TEntity>()
        //                .Where(specification.ToExpression())
        //                .Skip((page - 1) * size)
        //                .Take(size);

        //    if (descending)
        //        query = query.OrderByDescending(orderby);
        //    else
        //        query = query.OrderBy(orderby);

        //    if (includes.Any())
        //    {
        //        query = includes.Aggregate(query.AsQueryable(),
        //              (current, include) => current.Include(include));
        //    }

        //    return (await query.ToListAsync()).AsReadOnly();
        //}

        //public async Task<int> CountAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, object>>> includes)
        //{
        //    var query = context
        //                .Set<TEntity>()
        //                .Where(specification.ToExpression());

        //    if (includes.Any())
        //    {
        //        query = includes.Aggregate(query.AsQueryable(),
        //              (current, include) => current.Include(include));
        //    }

        //    return (await query.CountAsync());
        //}

        //public async Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, object>>> includes)
        //{
        //    var query = context
        //               .Set<TEntity>()
        //               .Where(specification.ToExpression());

        //    if (includes.Any())
        //    {
        //        query = includes.Aggregate(query.AsQueryable(),
        //              (current, include) => current.Include(include));
        //    }

        //    return (await query.ToListAsync()).AsReadOnly();
        //}

        //public async Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, string>>> includes)
        //{
        //    var query = context
        //                .Set<TEntity>()
        //                .Where(specification.ToExpression());

        //    if (includes.Any())
        //    {
        //        query = includes.Aggregate(query.AsQueryable(),
        //              (current, include) => current.Include(include));
        //    }

        //    return (await query.ToListAsync()).AsReadOnly();
        //}

        //public async Task<int> CountAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, string>>> includes)
        //{
        //    var query = context
        //                .Set<TEntity>()
        //                .Where(specification.ToExpression());

        //    if (includes.Any())
        //    {
        //        query = includes.Aggregate(query.AsQueryable(),
        //              (current, include) => current.Include(include));
        //    }

        //    return (await query.CountAsync());
        //}
    }
}
