using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
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
        public void Add(Car car)
        {
            if (car.CarName.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
            }
            else
            {
                Console.WriteLine("Car couldn't added because either car's name wasn't longer than 1 character or daily price wasn't bigger than 0.");
            }
        }
        public void Update(Car car)
        {
            if (car.CarName.Length > 1 && car.DailyPrice > 0)
            {
                _carDal.Update(car);
            }
            else
            {
                Console.WriteLine("Car couldn't updated because either car's name wasn't longer than 1 character or daily price wasn't bigger than 0.");
            }
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.CarId == carId);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetCarsByModelId(int modelId)
        {
            return _carDal.GetAll(c => c.ModelId == modelId);
        }

        public List<Car> GetCarsByModelYear(DateTime modelYear)
        {
            return _carDal.GetAll(c => c.ModelYear == modelYear);
        }

        public List<Car> GetCarsByDailyPrice(decimal minDailyPrice, decimal maxDailyPrice)
        {
            return _carDal.GetAll(c=> c.DailyPrice<=maxDailyPrice && c.DailyPrice>=minDailyPrice);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }
    }
}
