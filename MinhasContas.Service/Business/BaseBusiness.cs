using AutoMapper;
using MinhasContas.DAL.Interface.Entities;
using MinhasContas.DAL.Interface.UnitOfWork;
using MinhasContas.Domain.Models;
using MinhasContas.Service.Interface.Business;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhasContas.Service.Business
{
    public class BaseBusiness<TEntity, T> : IBaseBusiness<TEntity, T> where TEntity : BaseEntity where T : BaseModel
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public BaseBusiness(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<bool> SaveAsync(T model)
        {
            var repository = unitOfWork.GetRepository<TEntity>();
            var entity = mapper.Map<TEntity>(model);
            entity = (entity.Id == 0
                ? await repository.AddAsync(entity)
                : repository.Update(entity));
            return await unitOfWork.SaveAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var repository = unitOfWork.GetRepository<TEntity>();
            var entity = await repository
                .GetOneAsync(id);
            if (entity != null)
            {
                repository.Delete(entity);
                return await unitOfWork.SaveAsync() > 0;
            }
            return false;
        }
    }
}
