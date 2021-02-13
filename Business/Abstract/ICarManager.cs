using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarManager
    {
        List<Car> GetById(int id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(int id, Car car);
        void Delete(int id);
    }
}
