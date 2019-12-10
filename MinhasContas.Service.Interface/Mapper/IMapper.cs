using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinhasContas.Service.Interface.Mapper
{
    public interface IMapper<TModel, TEntity>
        where TModel : class
        where TEntity : class
    {
        IEnumerable<TModel> ListMapToModel(IEnumerable<TEntity> listEntity);
        IEnumerable<TEntity> ListMapToEntity(IEnumerable<TModel> listModel);
        TModel MapToModel(TEntity entity);
        TEntity MapToEntity(TModel model);
    }
}
