using System;
using System.IO;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //CarDtoTest();

            //BrandTest();

            //ColorTest();

            //ModelTest();

            //ModelDtoTest();

            //UserTest();

            //CustomerTest();
        }

        private static void CustomerTest()
        {
            ICustomerService customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { CustomerId = 1, UserId = 1, CompanyName = "Holaron Company" });
        }

        private static void UserTest()
        {
            IUserService userManager = new UserManager(new EfUserDal());
            userManager.Add(new User { UserId = 1, FirstName = "James", LastName = "Bonded", Email = "bonded.james@coolmail.com", Password = "iamnotbounded" });
        }

        private static void ModelDtoTest()
        {
            IModelService modelManager = new ModelManager(new EfModelDal());
            foreach (var modelDetail in modelManager.GetModelDetails().Data)
            {
                Console.WriteLine(modelDetail.ModelName + " " + modelDetail.BrandName);
            }
        }

        private static void ModelTest()
        {
            IModelService modelManager = new ModelManager(new EfModelDal());
            foreach (var model in modelManager.GetAll().Data)
            {
                Console.WriteLine(model.ModelName);
            }

            modelManager.Add(new Model { ModelId = 11, ModelName = "Epica", BrandId = 4 });
            Console.WriteLine("\n" + modelManager.GetById(11).Data.ModelName);

            modelManager.Update(new Model { ModelId = 11, ModelName = "Cruze", BrandId = modelManager.GetById(11).Data.BrandId });
            Console.WriteLine("\n" + modelManager.GetById(11).Data.ModelName);

            modelManager.Delete(new Model { ModelId = 11 });
            Console.WriteLine("");
            foreach (var model in modelManager.GetAll().Data)
            {
                Console.WriteLine(model.ModelName);
            }
        }

        private static void ColorTest()
        {
            IColorService colorManager = new ColorManager(new EfColorDal());
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }

            colorManager.Add(new Color { ColorId = 6, ColorName = "Pink" });
            Console.WriteLine("\n" + colorManager.GetById(6).Data.ColorName);

            colorManager.Update(new Color { ColorId = 6, ColorName = "Turqoise" });
            Console.WriteLine("\n" + colorManager.GetById(6).Data.ColorName);

            colorManager.Delete(new Color { ColorId = 6 });
            Console.WriteLine("");
            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            IBrandService brandManager = new BrandManager(new EfBrandDal());
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }

            brandManager.Add(new Brand { BrandId = 7, BrandName = "Ferrari" });
            Console.WriteLine("\n"+brandManager.GetById(7).Data.BrandName);

            brandManager.Update(new Brand { BrandId = 7, BrandName = "Bugatti" });
            Console.WriteLine("\n"+brandManager.GetById(7).Data.BrandName);

            brandManager.Delete(new Brand { BrandId = 7 });
            Console.WriteLine("");
            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarDtoTest()
        {
            ICarService carManager = new CarManager(new EfCarDal());
            foreach (var Car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine(Car.BrandName + " " + Car.ModelName + " " + Car.ColorName + " " + Car.ModelYear + " " + Car.DailyPrice);
            }
        }

        private static void CarTest()
        {
            ICarService carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { CarId = 2, BrandId = 5, ModelId = 9, ColorId = 1, CarName = "Ford Fusion 2020 Model", DailyPrice = 550.29, CarDescription = "Too fast. Be cautious!", ModelYear = new DateTime(2020, 1, 1,0,0,0) });
            Console.WriteLine("Listing all cars:\n");
            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing Mercedeses:\n");
            foreach (var car in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing black cars:\n");
            foreach (var car in carManager.GetCarsByColorId(1).Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing cars whose daily price is between 800 and 1200:\n");
            foreach (var car in carManager.GetCarsByDailyPrice(800, 1200).Data)
            {
                Console.WriteLine(car.CarName);
            }
            Console.WriteLine("\nListing 2020 model cars:\n");
            foreach (var car in carManager.GetCarsByModelYear(2020).Data)
            {
                Console.WriteLine(car.CarName);
            }
        }
    }
}
