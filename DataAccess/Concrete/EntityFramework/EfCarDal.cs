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
                             on car.BrandId equals b.Id
                             join col in context.Colors
                             on car.ColorId equals col.Id
                             join m in context.Models
                             on car.ModelId equals m.Id

                             select new CarDetailDto {
                                 CarId=car.Id,
                                 BrandId= b.Id,
                                 ModelId = m.Id,
                                 ColorId = col.Id,
                                 CarName = car.Name,
                                 BrandName = b.Name,
                                 ModelName = m.Name,
                                 ColorName = col.Name,
                                 DailyPrice= car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 CarDescription = car.Description, 
                             };
                return result.ToList();
            }
        }
    }
}
