using AutomobileLibrary.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomobileLibrary.DataAccess
{
    public class CarDBContext
    {
        // Initialize car List
        private List<Car> CarList = new List<Car>()
        {
            new Car(){CarID =1, CarName="CRV",Manufacturer ="Honda", Price = 30_000,ReleaseYear = 2021},
            new Car(){CarID =2, CarName= "Ford Focus",Manufacturer="Ford",Price=15_000, ReleaseYear = 2020}
        };
        // Singleton Pattern
        private static CarDBContext instance = null;
        private static readonly object instanceLock = new object();
        private CarDBContext() { }
        public static CarDBContext Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if(instance == null)
                    {
                        instance = new CarDBContext();
                    }
                    return instance;
                }
            }
        }
        public List<Car> GetCarList => CarList;
        public Car GetCarByID(int carID)
        {
            // Using LINQ to Object
            Car car = CarList.SingleOrDefault(pro => pro.CarID == carID);
            return car;
        }

        public void AddNew (Car car)
        {
            Car checkCar = GetCarByID(car.CarID);
            if(checkCar == null)
            {
                CarList.Add(car);
            }
            else
            {
                throw new Exception("Car is already existed.");
            }
        }

        public void Update(Car car)
        {
            Car checkCar = GetCarByID(car.CarID);
            if(checkCar != null)
            {
                int index = CarList.IndexOf(checkCar);
                CarList[index] = car;
            }
            else
            {
                throw new Exception("Car does not already exist.");
            }
        }
        public void Remove(int carID)
        {
            Car car = GetCarByID(carID);
            if(car != null)
            {
                CarList.Remove(car);
            }
            else
            {
                throw new Exception("Car does not already exist.");
            }
        }
    }
}
