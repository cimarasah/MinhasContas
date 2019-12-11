using MinhasContas.DAL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MinhasContas.DAL.Interface.Repository
{
    public interface IRepositoryFactory
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
    }
}
