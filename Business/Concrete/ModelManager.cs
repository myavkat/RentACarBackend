using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class ModelManager : IModelManager
    {
        IModelDal _modelDal;

        public ModelManager(IModelDal modelDal)
        {
            _modelDal = modelDal;
        }

        public void Add(Model entity)
        {
            _modelDal.Add(entity);
        }

        public void Delete(Model entity)
        {
            _modelDal.Delete(entity);
        }

        public List<Model> GetAll()
        {
            return _modelDal.GetAll();
        }

        public Model GetById(int entityId)
        {
            return _modelDal.Get(m=> m.ModelId == entityId);
        }

        public List<ModelDetailDto> GetModelDetails()
        {
            return _modelDal.GetModelDetails();
        }

        public void Update(Model entity)
        {
            _modelDal.Update(entity);
        }
    }
}
