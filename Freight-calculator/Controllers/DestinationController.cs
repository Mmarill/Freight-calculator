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
        [HttpGet]
        public async Task<IEnumerable<Destination>> Get()
        {
            var destinations = await _destinationService.GetAllDestinations();
            // get all destinations in db
            // need to use Task
            return destinations;
        }

        // GET: api/Destination/<id>       
        [HttpGet("{id}", Name = "Get")]
        public async Task<Destination> Get(int id)
        {
            return await _destinationService.GetDestinationById(id);
        }

        // POST: api/Destination/
        [HttpPost]
        public async Task Post([FromBody] Destination destination )
        {
            await _destinationService.AddDestination(destination);
 

        }

    // PUT: api/Destination/<id>
    [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Destination destination)
        {

            await _destinationService.UpdateDestination(id, destination);
        }

        // DELETE: api/Destination/<id>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _destinationService.DeleteDestination(id);
        }
    }
}

