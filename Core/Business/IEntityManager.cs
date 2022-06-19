using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Core.Utilities.Results;

namespace Core.Business
{
    //Not in use due to problem with getting invocations' names right in cache aspect
    //Will be used after solving the cache's problem with this
    public interface IEntityManager<TEntity> where TEntity: class, IEntity, new()
    {
        IResult Add(TEntity entity);
        IResult Update(TEntity entity);
        IResult Delete(TEntity entity);
        IDataResult<TEntity> GetById(int entityId);
        IDataResult<List<TEntity>> GetAll();
    }
}
