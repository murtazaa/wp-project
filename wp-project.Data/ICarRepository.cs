using System;
using System.Collections.Generic;
using System.Text;
using wp_project.Services.Entities;

namespace wp_project.Data
{
    public interface ICarRepository
    {
        public List<Car> GetCars();

        public Car GetCar(int id);

        public int AddCar(Car car);

        public void UpdateCar(Car car);

        public void DeleteCar(int id);

    }
}
