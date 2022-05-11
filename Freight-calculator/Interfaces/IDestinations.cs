using Freight_calculator.Models;

namespace Freight_calculator.Interfaces
{
    public interface IDestinations
    {
		// get all destinations
		Task<List<Destination>> GetAllDestinations();

		// get destination by id
		Task<Destination> GetDestinationById(int Id);

		// add destination
		Task AddDestination(Destination destination);

		// uodate destination
		Task UpdateDestination(int Id, Destination destination);

		// delete destination
		Task DeleteDestination(int Id);
	}
}
