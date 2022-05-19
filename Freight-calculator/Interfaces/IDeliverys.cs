using Freight_calculator.Models;

namespace Freight_calculator.Interfaces
{
   
		public interface IDeliverys
		{
			// get all deliverys
			Task<List<Delivery>> GetAllDeliveries();

			// get a Delivery by it's id
			Task<Delivery> GetDeliveryById(int Id);

			// Adds a new Delivery 
			Task AddDelivery(Delivery delivery);

			// Updates the delivery
			Task UpdateDelivery(int Id, Delivery delivery);

			// Deletes a Delivery by it's id
			Task DeleteDelivery(int Id);

		}
	}
