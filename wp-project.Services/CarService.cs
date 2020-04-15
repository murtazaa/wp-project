using System;
using System.Collections.Generic;
using wp_project.Data;
using wp_project.Services.Entities;
using wp_project.Services.Models;

namespace wp_project.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;
        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        public int AddCar(CarModel car)
        {
            return _carRepository.AddCar(MapCarModelToCar(car));
        }

        public void DeleteCar(int id)
        {
            _carRepository.DeleteCar(id);
        }

        public CarModel GetCar(int id)
        {
            var car = _carRepository.GetCar(id);
            return MapCarToModel(car);
        }

        public List<CarModel> GetCars()
        {
            var cars = _carRepository.GetCars();
            var result = new List<CarModel>();

            foreach(var c in cars)
            {
                result.Add(MapCarToModel(c));
            }

            return result;
        }

        public void UpdateCar(CarModel car)
        {
            _carRepository.UpdateCar(MapCarModelToCar(car));
        }

        private CarModel MapCarToModel(Car car)
        {
            return new CarModel
            {
                Id = car.Id,
                Make = car.Make,
                Model = car.Model,
                Year = car.Year
            };
        }

        private Car MapCarModelToCar(CarModel carModel)
        {
            return new Car
            {
                Id = carModel.Id,
                Make = carModel.Make,
                Model = carModel.Model,
                Year = carModel.Year
            };
        }
    }
}
