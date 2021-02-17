using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete
{
    public class InMemoryCarDal:ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1, BrandId=1, ColorId=1, ModelYear=new DateTime(2021), DailyPrice=450, CarDescription="Çok Hızlı"},
                new Car{CarId=2, BrandId=1, ColorId=2, ModelYear=new DateTime(2016), DailyPrice=250, CarDescription="Hızlı"},
                new Car{CarId=3, BrandId=2, ColorId=1, ModelYear=new DateTime(2008), DailyPrice=100, CarDescription="Normal Hızda"},
            };
        }

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars;
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
