using Freight_calculator.Models;

namespace Freight_calculator.Interfaces
{
    public interface IDeliverys
    {
		// get all destinations
		Task<List<Delivery>> GetAllDeliveries();

		// get destination by id
		Task<Delivery> GetDeliveryById(int Id);

		// add destination
		Task AddDelivery(Delivery delivery);

		// uodate destination
		Task UpdateDelivery(int Id, Delivery delivery
			);

		// delete destination
		Task DeleteDelivery(int Id);
	}
}
