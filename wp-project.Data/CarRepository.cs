using System;
using System.Collections.Generic;
using System.Linq;
using wp_project.Services.Entities;

namespace wp_project.Data
{
    public class CarRepository : ICarRepository
    {

        private List<Car> _cars = new List<Car>();
        public CarRepository()
        {
            if (!_cars.Any())
            {
                HydrateCars();
            }
        }

        public List<Car> GetCars()
        {
            return _cars;
        }

        public Car GetCar(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public int AddCar(Car car)
        {
            car.Id = _cars.Count + 1;
            _cars.Add(car);

            return car.Id;
        }      

        public void UpdateCar(Car car)
        {
            var carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);

            if(carToUpdate == null)
            {
                throw new NullReferenceException("Car not found");
            }

            carToUpdate.Make = car.Make;
            carToUpdate.Model = car.Model;
            carToUpdate.Year = car.Year;
        }
        public void DeleteCar(int id)
        {
            var carToDelete = _cars.FirstOrDefault(c => c.Id == id);
            _cars.Remove(carToDelete);
        }

        private void HydrateCars()
        {
            _cars.Add(new Car
            {
                Id = 0,
                Make = "Honda",
                Model = "Accord",
                Year = 2019               
            });

            _cars.Add(new Car
            {
                Id = 1,
                Make = "Toyota",
                Model = "Camary",
                Year = 2020
            });

            _cars.Add(new Car
            {
                Id = 2,
                Make = "Hyndai",
                Model = "Elantra",
                Year = 2017
            });

            _cars.Add(new Car
            {
                Id = 3,
                Make = "Honda",
                Model = "Civic",
                Year = 2020
            });
        }
    }
}
