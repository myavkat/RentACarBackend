using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarManager
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car Get(int carId);
        List<Car> GetCars();
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByModelId(int modelId);
        List<Car> GetCarsByModelYear(DateTime modelYear);
        List<Car> GetCarsByDailyPrice(decimal minDailyPrice, decimal maxDailyPrice);
    }
}
