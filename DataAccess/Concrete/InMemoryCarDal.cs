using System;
using System.Collections.Generic;
using System.Linq;
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
                new Car{Id=1, BrandId=1, ColorId=1, ModelYear=new DateTime(2021), DailyPrice=450, Description="Çok Hızlı"},
                new Car{Id=2, BrandId=1, ColorId=2, ModelYear=new DateTime(2016), DailyPrice=250, Description="Hızlı"},
                new Car{Id=3, BrandId=2, ColorId=1, ModelYear=new DateTime(2008), DailyPrice=100, Description="Normal Hızda"},
            };
        }

        public List<Car> GetById(int id)
        {

            return _cars.Where(c => c.Id == id).ToList();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Update(int id, Car car)
        {
            Car carToUpdate = _cars.Single(c => c.Id == id);
            carToUpdate.ColorId = car.ColorId; 
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }

        public void Delete(int id)
        {
            _cars.Remove(_cars.Single(c=>c.Id==id));
        }
    }
}
