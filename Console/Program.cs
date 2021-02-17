using System;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { CarId = 2, BrandId = 5, ModelId = 9, ColorId = 1, CarName = "Ford Fusion 2020 Model", DailyPrice = 550.29, CarDescription = "Too fast. Be cautious!", ModelYear = new DateTime(2020, 1, 1,0,0,0) });
            Console.WriteLine("GetCars()\n");
            foreach (var car in carManager.GetCars())
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nGetCarsByBrandId(1)\n");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nGetCarsByColorId(1)\n");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nGetCarsByDailyPrice(800, 1200)\n");
            foreach (var car in carManager.GetCarsByDailyPrice(800, 1200))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nGetCarsByModelYear(new DateTime(2020, 1, 1))\n");
            foreach (var car in carManager.GetCarsByModelYear(new DateTime(2020, 1, 1,0,0,0)))
            {
                Console.WriteLine(car.CarName);
            }

            



        }
    }
}
