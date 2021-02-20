using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Core.Business
{
    public interface IEntityManager<TEntity> where TEntity: class, IEntity, new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int entityId);
        List<TEntity> GetAll();
    }
}
