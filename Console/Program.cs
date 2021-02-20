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
            CarTest();

            //CarDtoTest();

            //BrandTest();

            //ColorTest();

            //ModelTest();

            //ModelDtoTest();

        }

        private static void ModelDtoTest()
        {
            IModelManager modelManager = new ModelManager(new EfModelDal());
            foreach (var modelDetail in modelManager.GetModelDetails())
            {
                Console.WriteLine(modelDetail.ModelName + " " + modelDetail.BrandName);
            }
        }

        private static void ModelTest()
        {
            IModelManager modelManager = new ModelManager(new EfModelDal());
            foreach (var model in modelManager.GetAll())
            {
                Console.WriteLine(model.ModelName);
            }

            modelManager.Add(new Model { ModelId = 11, ModelName = "Epica", BrandId = 4 });
            Console.WriteLine("\n" + modelManager.GetById(11).ModelName);

            modelManager.Update(new Model { ModelId = 11, ModelName = "Cruze", BrandId = modelManager.GetById(11).BrandId });
            Console.WriteLine("\n" + modelManager.GetById(11).ModelName);

            modelManager.Delete(new Model { ModelId = 11 });
            Console.WriteLine("");
            foreach (var model in modelManager.GetAll())
            {
                Console.WriteLine(model.ModelName);
            }
        }

        private static void ColorTest()
        {
            IColorManager colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }

            colorManager.Add(new Color { ColorId = 6, ColorName = "Pink" });
            Console.WriteLine("\n" + colorManager.GetById(6).ColorName);

            colorManager.Update(new Color { ColorId = 6, ColorName = "Turqoise" });
            Console.WriteLine("\n" + colorManager.GetById(6).ColorName);

            colorManager.Delete(new Color { ColorId = 6 });
            Console.WriteLine("");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            IBrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }

            brandManager.Add(new Brand { BrandId = 7, BrandName = "Ferrari" });
            Console.WriteLine("\n"+brandManager.GetById(7).BrandName);

            brandManager.Update(new Brand { BrandId = 7, BrandName = "Bugatti" });
            Console.WriteLine("\n"+brandManager.GetById(7).BrandName);

            brandManager.Delete(new Brand { BrandId = 7 });
            Console.WriteLine("");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarDtoTest()
        {
            ICarManager carManager = new CarManager(new EfCarDal());
            foreach (var Car in carManager.GetCarDetails())
            {
                Console.WriteLine(Car.BrandName + " " + Car.ModelName + " " + Car.ColorName + " " + Car.ModelYear.Year + " " + Car.DailyPrice);
            }
        }

        private static void CarTest()
        {
            ICarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { CarId = 2, BrandId = 5, ModelId = 9, ColorId = 1, CarName = "Ford Fusion 2020 Model", DailyPrice = 550.29, CarDescription = "Too fast. Be cautious!", ModelYear = new DateTime(2020, 1, 1,0,0,0) });
            Console.WriteLine("Listing all cars:\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing Mercedeses:\n");
            foreach (var car in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing black cars:\n");
            foreach (var car in carManager.GetCarsByColorId(1))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing cars whose daily price is between 800 and 1200:\n");
            foreach (var car in carManager.GetCarsByDailyPrice(800, 1200))
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing 2020 model cars:\n");
            foreach (var car in carManager.GetCarsByModelYear(new DateTime(2020, 1, 1, 0, 0, 0)))
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
