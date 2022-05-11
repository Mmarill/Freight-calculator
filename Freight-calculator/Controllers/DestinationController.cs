using Freight_calculator.Interfaces;
using Freight_calculator.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Freight_calculator.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class DestinationController : ControllerBase
    {
        private IDestinations _destinationService;
        // get interface

        // inject interface in this structure
        public DestinationController(IDestinations destinationService)
        {
            _destinationService = destinationService;
        }

        // currently returnign a listof strings
        [DisableCors]
        [HttpGet]
        public async Task<IEnumerable<Destination>> Get()
        {
            var destinations = await _destinationService.GetAllDestinations();
            // get all vehicle methods
            // need to use Task
            return destinations;
        }

        // GET: api/VehiclesApiControllers/5
        // again string so need to change to a vehicle
        [HttpGet("{id}", Name = "Get")]
        public async Task<Destination> Get(int id)
        {
            return await _destinationService.GetDestinationById(id);
        }

        // POST: api/VehiclesApiControllers
        [HttpPost]
        public async Task Post([FromBody] Destination destination)
        {
            await _destinationService.AddDestination(destination);
        }

        // PUT: api/VehiclesApiControllers/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Destination destination)
        {

            await _destinationService.UpdateDestination(id, destination);
        }

        // DELETE: api/VehiclesApiControllers/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _destinationService.DeleteDestination(id);
        }
    }
}

