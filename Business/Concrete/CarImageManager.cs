using System;
using System.Collections.Generic;
using System.IO;
using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;

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
        public IResult Add(IFormFile image, int carId)
        {
            var result = BusinessRules.Run(CheckIfImageCountExceeded(carId));
            if (result != null)
            {
                return result;
            }
            var addFileResult = FileHelper.AddFile(image, FileHelper.carImages);
            if (!addFileResult.Success)
            {
                return new ErrorResult(addFileResult.Message);
            }
            CarImage carImage = new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = addFileResult.Data };
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.ItemAdded);

        }

        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Delete(int carImageId)
        {
            var getResult = GetById(carImageId);
            if (!getResult.Success)
            {
                return new ErrorResult(getResult.Message);
            }
            var deleteFileResult = FileHelper.DeleteFile(getResult.Data.ImagePath,FileHelper.carImages);
            if (!deleteFileResult.Success)
            {
                return new ErrorResult(deleteFileResult.Message);
            }
            _carImageDal.Delete(getResult.Data);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            var result = new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(), Messages.ItemsListed);
            if (result.Data.Count == 0)
            {
                CarImage defaultImage = new CarImage();
                defaultImage.CarId = 0;
                defaultImage.ImagePath = "default.png";
                result.Data.Add(defaultImage);
            }
            return result;
        }

        [CacheAspect]
        public IDataResult<List<CarImage>> GetAllByCarId(int carId)
        {
            var result = new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId), Messages.ItemsListed);
            if (result.Data.Count == 0)
            {
                CarImage defaultImage = new CarImage();
                defaultImage.CarId = 0;
                defaultImage.ImagePath = "default.png";
                result.Data.Add(defaultImage);
            }
            return result;
        }

        public IDataResult<CarImage> GetById(int id)
        {
            var result = new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == id), Messages.ItemListed);
            if (result.Data == null)
                return new ErrorDataResult<CarImage>("This id doesn't have a matching image");
            return result;
        }

        private IResult CheckIfImageCountExceeded(int carId)
        {
            var images = _carImageDal.GetAll(i => i.CarId == carId);
            if (images.Count >= 5)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
