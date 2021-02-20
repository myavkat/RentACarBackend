using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join col in context.Colors
                             on car.ColorId equals col.ColorId
                             join m in context.Models
                             on car.ModelId equals m.ModelId
                             
                             select new CarDetailDto {
                                 CarId=car.CarId,
                                 BrandId= b.BrandId,
                                 ModelId = m.ModelId,
                                 ColorId = col.ColorId,
                                 CarName = car.CarName,
                                 BrandName = b.BrandName,
                                 ModelName = m.ModelName,
                                 ColorName = col.ColorName,
                                 DailyPrice= car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 CarDescription = car.CarDescription, 
                             };
                return result.ToList();
            }
        }
    }
}
