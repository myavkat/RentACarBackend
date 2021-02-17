using System;
using System.Collections.Generic;
using Entities.Concrete;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IModelDal : IEntityRepository<Model>
    {
    }
}
