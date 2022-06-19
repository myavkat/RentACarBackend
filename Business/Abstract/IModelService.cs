using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IModelService
    {
        IResult Add(Model model);
        IResult Update(Model model);
        IResult Delete(Model model);
        IDataResult<Model> GetById(int id);
        IDataResult<List<Model>> GetAll();
        IDataResult<List<ModelDetailDto>> GetModelDetails();
    }
}
