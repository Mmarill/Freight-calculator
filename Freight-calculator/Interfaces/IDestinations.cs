using Freight_calculator.Models;

namespace Freight_calculator.Interfaces
{
    public interface IDestinations
    {
		// get all destinations
		Task<List<Destination>> GetAllDestinations();

		// get destination by id
		Task<Destination> GetDestinationById(int Id);

		// Adds a destination
		Task AddDestination(Destination destination);

		// update destination
		Task UpdateDestination(int Id, Destination destination);

		// delete destination
		Task DeleteDestination(int Id);
		
		// Calculates the cost 
		double GetCost(double distanceInKm, double tariff);
		
		// Calculates the distance between two gps coordinates
		double GetDistance(double lat1, double lon1, double lat2, double lon2);

		


	}
}
