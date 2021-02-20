using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarManager:IEntityManager<Car>
    {
        List<Car> GetCarsByBrandId(int brandId);
        List<Car> GetCarsByColorId(int colorId);
        List<Car> GetCarsByModelId(int modelId);
        List<Car> GetCarsByModelYear(DateTime modelYear);
        List<Car> GetCarsByDailyPrice(decimal minDailyPrice, decimal maxDailyPrice);
        List<CarDetailDto> GetCarDetails();
    }
}
