using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public IResult Add(Model entity)
        {
            _modelDal.Add(entity);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Model entity)
        {
            _modelDal.Delete(entity);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Model>> GetAll()
        {
            return new SuccessDataResult<List<Model>>(_modelDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Model> GetById(int entityId)
        {
            return new SuccessDataResult<Model>(_modelDal.Get(m=> m.ModelId == entityId), Messages.ItemListed);
        }

        public IDataResult<List<ModelDetailDto>> GetModelDetails()
        {
            return new SuccessDataResult<List<ModelDetailDto>>(_modelDal.GetModelDetails(), Messages.FilteredItemsListed);
        }

        public IResult Update(Model entity)
        {
            _modelDal.Update(entity);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
