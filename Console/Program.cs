using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarManager inMemoryCarManager = new CarManager(new InMemoryCarDal());

            inMemoryCarManager.Add(new Car { BrandId = 1, Id = 7, ColorId = 3, DailyPrice = 400, ModelYear = new DateTime(2071), Description = "Geleceğin arabası" });
            foreach (var car in inMemoryCarManager.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }
            inMemoryCarManager.Update(2, new Car {BrandId=100});
            foreach (var car in inMemoryCarManager.GetAll())
            {
                Console.WriteLine(car.BrandId);
            }
            ICarDal inMemoryCarDal = new InMemoryCarDal();

            foreach (var car in inMemoryCarDal.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            inMemoryCarDal.Add(new Car {BrandId=1,Id=7,ColorId=3,DailyPrice=400, ModelYear=new DateTime(2071),Description="Geleceğin arabası" });

            foreach (var car in inMemoryCarDal.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
