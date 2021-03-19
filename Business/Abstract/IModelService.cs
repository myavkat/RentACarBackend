using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IModelService : IEntityManager<Model>
    {
        IDataResult<List<ModelDetailDto>> GetModelDetails();
    }
}
