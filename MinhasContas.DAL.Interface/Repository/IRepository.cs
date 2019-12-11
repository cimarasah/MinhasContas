using MinhasContas.DAL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinhasContas.DAL.Interface.Repository
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        //Task<TEntity> GetOneAsync(IQuerySpecification<TEntity> specification);
        //Task<TEntity> GetLastAsync(IQuerySpecification<TEntity> specification);
        Task<TEntity> GetOneAsync(long id);
        //Task<IReadOnlyList<TEntity>> GetAsync(IQuerySpecification<TEntity> specification);
        //Task<IReadOnlyList<TEntity>> GetAsync(IPagedListSpecification<TEntity> pagedListSpecification);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> criteria);
        Task<TEntity> AddAsync(TEntity entity);
        void AddAsync(IEnumerable<TEntity> entity);
        TEntity Update(TEntity entity);
        TEntity Update(TEntity entity, TEntity source);
        void Delete(TEntity entity);
        void HardDelete(TEntity entity);
        //Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, int page, int size, bool descending, Expression<Func<TEntity, object>> orderby);
        //Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, int page, int size, bool descending, Expression<Func<TEntity, object>> orderby, List<Expression<Func<TEntity, object>>> includes);
        //Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification);
        //Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, object>>> includes);
        //Task<int> CountAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, object>>> includes);
        //Task<IReadOnlyList<TEntity>> GetAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, string>>> includes);
        //Task<int> CountAsyncSpecification(Specification<TEntity> specification, List<Expression<Func<TEntity, string>>> includes);
    }
}
