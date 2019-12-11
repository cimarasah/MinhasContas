using Microsoft.EntityFrameworkCore;
using MinhasContas.DAL.Interface.Entities;
using MinhasContas.DAL.Interface.Repository;
using MinhasContas.DAL.Interface.Services;
using MinhasContas.DAL.Interface.UnitOfWork;
using MinhasContas.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhasContas.DAL.UnitOfWork
{
    public class UnitOfWork<TContext> : IUnitOfWork
        where TContext : DbContext
    {
        private readonly TContext context;

        protected IApplicationContextService ApplicationContextService { get; private set; }

        protected Dictionary<Type, object> Repositories { get; private set; }

        public UnitOfWork(TContext context, IApplicationContextService applicationContextService)
        {
            this.context = context;
            this.ApplicationContextService = applicationContextService;
            Repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity
        {
            var type = typeof(TEntity);
            if (!Repositories.ContainsKey(type))
            {
                Repositories.Add(typeof(TEntity),
                    new Repository<TContext, TEntity>(context));
            }
            return Repositories[type] as IRepository<TEntity>;
        }

        public virtual Task<int> SaveAsync()
        {
            var entities = context.ChangeTracker
                .Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added
                    || e.State == EntityState.Modified);
            foreach (var entity in entities)
            {
                if (entity.State == EntityState.Added)
                {
                    entity.Property(e => e.CreatedBy)
                        .CurrentValue = ApplicationContextService.CurrentUser;
                    entity.Property(e => e.CreatedDate)
                        .CurrentValue = DateTime.Now;
                }
                else
                {
                    entity.Property(e => e.CreatedBy)
                       .IsModified = false;
                    entity.Property(e => e.CreatedDate)
                        .IsModified = false;
                }
                entity.Property(e => e.UpdatedDate)
                    .CurrentValue = DateTime.Now;
                entity.Property(e => e.UpdatedBy)
                    .CurrentValue = ApplicationContextService.CurrentUser;
            }
            return context.SaveChangesAsync();
        }
    }
}
