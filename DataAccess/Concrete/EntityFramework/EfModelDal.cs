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
    public class EfModelDal : EfEntityRepositoryBase<Model, ReCapProjectDbContext>, IModelDal
    {
        public List<ModelDetailDto> GetModelDetails()
        {
            using (ReCapProjectDbContext context = new ReCapProjectDbContext())
            {
                var result = from m in context.Models
                             join b in context.Brands
                             on m.BrandId equals b.Id
                             select new ModelDetailDto { 
                                 BrandId = b.Id, 
                                 BrandName = b.Name, 
                                 ModelId = m.Id, 
                                 ModelName = m.Name 
                             };
                return result.ToList();
            }
        }
    }
}
