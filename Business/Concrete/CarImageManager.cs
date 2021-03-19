using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Business.Constants;
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

        public IResult Update(CarImage carImage)
        {
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i=> i.CarId == carId), Messages.ItemsListed);
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.CarImageId == carImageId), Messages.ItemListed);
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
