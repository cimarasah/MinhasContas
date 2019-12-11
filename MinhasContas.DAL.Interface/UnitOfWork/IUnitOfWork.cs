using MinhasContas.DAL.Interface.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhasContas.DAL.Interface.UnitOfWork
{
    public interface IUnitOfWork : IRepositoryFactory
    {
        Task<int> SaveAsync();
    }
}
