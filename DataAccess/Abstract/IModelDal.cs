using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Text;
using Core.DataAccess;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
        List<ModelDetailDto> GetModelDetails(Expression<Func<ModelDetailDto, bool>> filter = null);
    }
}
