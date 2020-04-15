using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using wp_project.Services;
using wp_project.Services.Models;

namespace wp_project.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly ILogger<CarController> _logger;

        public CarController(ICarService carService,
            ILogger<CarController> logger)
        {
            _carService = carService;
            _logger = logger;
        }

        /// <summary>
        /// Get All Cars
        /// </summary>
        /// <returns>List of Cars</returns>
        [HttpGet]
        [Produces(typeof(List<CarModel>))]
        public List<CarModel> Get()
        {
            return _carService.GetCars();
        }

        /// <summary>
        /// Gets a car by Id
        /// </summary>
        /// <param name="carId"></param>
        /// <returns>Car</returns>
        [HttpGet("{carId}")]
        [Produces(typeof(CarModel))]
        public IActionResult GetCar([FromRoute] int carId)
        {
            var car = _carService.GetCar(carId);

            return Ok(car);
        }

        /// <summary>
        /// Create a new car object in the system
        /// </summary>
        /// <param name="carModel"></param>
        /// <returns>Id of the newly created car object</returns>
        [HttpPost]
        [Produces(typeof(int))]
        public IActionResult Post([FromBody] CarModel carModel)
        {
            var newCarId = _carService.AddCar(carModel);

            return Ok(newCarId);
        }

        /// <summary>
        /// Update a car object in the system
        /// </summary>
        /// <param name="carModel"></param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] CarModel carModel)
        {
            _carService.UpdateCar(carModel);

            return Ok();
        }

        /// <summary>
        /// Delete a car by Id
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        [HttpDelete("{carId}")]
        public IActionResult Put([FromRoute]int carId)
        {
            _carService.DeleteCar(carId);

            return Ok();
        }
    }
}
