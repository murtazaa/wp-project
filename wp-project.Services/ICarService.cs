using System;
using System.Collections.Generic;
using wp_project.Services.Models;

namespace wp_project.Services
{
    public interface ICarService
    {
        public List<CarModel> GetCars();

        public CarModel GetCar(int id);

        public int AddCar(CarModel car);

        public void UpdateCar(CarModel car);

        public void DeleteCar(int id);
    }
}
