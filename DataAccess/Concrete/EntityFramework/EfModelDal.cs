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
    public class EfModelDal : EfEntityRepositoryBase<Model, RentACarDbContext>, IModelDal
    {
        public List<ModelDetailDto> GetModelDetails(Expression<Func<ModelDetailDto, bool>> filter = null)
        {
            using (RentACarDbContext context = new RentACarDbContext())
            {
                var result = from m in context.Models
                             join b in context.Brands
                             on m.BrandId equals b.Id
                             select new ModelDetailDto { 
                                 BrandId = b.Id, 
                                 BrandName = b.Name, 
                                 Id = m.Id, 
                                 Name = m.Name 
                             };
                return filter == null ?
                       result.ToList() :
                       result.Where(filter).ToList();
            }
        }
    }
}
