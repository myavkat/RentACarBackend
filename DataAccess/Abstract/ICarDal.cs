using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        List<Car> GetById(int id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(int id, Car car);
        void Delete(int id);
    }
}
