using System;
using System.Collections.Generic;
using System.Text;
using Core.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarService:IEntityManager<Car>
    {
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);
        IDataResult<List<Car>> GetCarsByModelId(int modelId);
        IDataResult<List<Car>> GetCarsByModelYear(int modelYear);
        IDataResult<List<Car>> GetCarsByDailyPrice(decimal minDailyPrice, decimal maxDailyPrice);
        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
