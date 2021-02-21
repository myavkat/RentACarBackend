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
    public class CarManager : ICarManager
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            if (car.CarName.Length < 1)
            {
                return new ErrorResult(Messages.MinNameLength);
            }
            else if (car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.MinDailyPrice);
            }
            _carDal.Add(car);
            return new SuccessResult(Messages.ItemAdded);
        }
        public IResult Update(Car car)
        {
            if (car.CarName.Length < 1)
            {
                return new ErrorResult(Messages.MinNameLength);
            }
            else if (car.DailyPrice > 0)
            {
                return new ErrorResult(Messages.MinDailyPrice);
            }
            _carDal.Update(car);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId), Messages.ItemListed);
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),Messages.ItemsListed);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.FilteredItemsListed);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.FilteredItemsListed);
        }

        public IDataResult<List<Car>> GetCarsByModelId(int modelId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelId == modelId), Messages.FilteredItemsListed);
        }

        public IDataResult<List<Car>> GetCarsByModelYear(DateTime modelYear)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ModelYear == modelYear), Messages.FilteredItemsListed);
        }

        public IDataResult<List<Car>> GetCarsByDailyPrice(decimal minDailyPrice, decimal maxDailyPrice)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=> c.DailyPrice<=maxDailyPrice && c.DailyPrice>=minDailyPrice), Messages.FilteredItemsListed);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.ItemsListed);
        }
    }
}
