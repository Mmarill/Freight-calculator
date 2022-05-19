using Freight_calculator.Interfaces;
using Freight_calculator.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Freight_calculator.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private IDeliverys _deliveryService;
        // get interface

        // inject interface in this structure
        public DeliveryController(IDeliverys deliveryService)
        {
            _deliveryService = deliveryService;
        }

        // currently returnign a listof strings
        [HttpGet]
        public async Task<IEnumerable<Delivery>> Get()
        {
            var deliveries = await _deliveryService.GetAllDeliveries();
            // get all destinations in db
            // need to use Task
            return deliveries;
        }

        // GET: api/Destination/<id>       
        [HttpGet("{id}", Name = "Get")]
        public async Task<Delivery> Get(int id)
        {
            return await _deliveryService.GetDeliveryById(id);
        }

        // POST: api/Destination/
        [HttpPost]
        public async Task Post([FromBody] Delivery delivery )
        {
            await _deliveryService.AddDelivery(delivery);
 

        }

    // PUT: api/Destination/<id>
    [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Delivery delivery)
        {

            await _deliveryService.UpdateDelivery(id, delivery);
        }

        // DELETE: api/Destination/<id>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _deliveryService.DeleteDelivery(id);
        }
    }
}

