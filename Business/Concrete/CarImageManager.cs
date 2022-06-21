using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(CarImage carImage)
        {
            var result = BusinessRules.Run(CheckIfImageCountExceeded(carImage.CarId));
            if (result == null)
            {
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.ItemAdded);
            }
            return result;
            
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ItemUpdated);
        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ItemsListed);
            if (result.Data.Count == 0)
            {
                CarImage defaultImage = new CarImage();
                defaultImage.CarId = 0;
                defaultImage.ImagePath = Directory.GetCurrentDirectory() + @"\wwwroot\default.png";
                result.Data.Add(defaultImage);
            }
            return result;
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i=> i.CarId == carId), Messages.ItemsListed);
            if (result.Data.Count == 0)
            {
                CarImage defaultImage = new CarImage();
                defaultImage.CarId = 0;
                defaultImage.ImagePath = Directory.GetCurrentDirectory() + @"\wwwroot\default.png";
                result.Data.Add(defaultImage);
            }
            return result;
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id), Messages.ItemListed);
            if(result.Data == null)
            return new ErrorDataResult<CarImage>("No such photo");
            return result;
        }

        private IResult CheckIfImageCountExceeded(int carId)
        {
            var images = _carImageDal.GetAll(i => i.CarId == carId);
            if (images.Count>=5)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
