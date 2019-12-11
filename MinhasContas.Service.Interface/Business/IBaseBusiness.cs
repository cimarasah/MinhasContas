using MinhasContas.DAL.Interface.Entities;
using MinhasContas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhasContas.Service.Interface.Business
{
    public interface IBaseBusiness<TEntity, T> where TEntity : BaseEntity where T : BaseModel
    {
        Task<bool> SaveAsync(T dto);
        Task<bool> DeleteAsync(int id);
    }
}
