using Freight_calculator.Data;
using Freight_calculator.Interfaces;
using Freight_calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Freight_calculator.Services
{
    public class DestinationService : IDestinations
    {
        private ApiDbContext dbContext;

        public DestinationService()
        {
            dbContext = new ApiDbContext();
        }

        public double GetCost(double distanceInKm = 0, double tariff = 10.0)
        {
            // Advanced cost formula
            double cost = distanceInKm * tariff;
            Console.WriteLine("Shipment cost: " + cost.ToString( "0.00"));
            
            return cost;
        }
        public double GetDistance(double lat1, double long1, double lat2, double long2)
        // A ruff estiamtion formula for calculating distance: Haversine formula with no radian compensation
        {

            double _eQuatorialEarthRadius = 6378.1370D;
            double _d2r = (Math.PI / 180D);

            double dlong = (long2 - long1) * _d2r;
            double dlat = (lat2 - lat1) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            Console.WriteLine("Distance between " + lat1 + "," + long1 + " and " + lat2 + "," + long2 + " with UAV transport ltd: " +  d);
            
            return d;
        }

       

        public async Task AddDestination(Destination destination)
        // Adds a destination to SQL Database
        {
            // Some extra readabillity, remove before branching in to master
            
            // Adds adress to Database if possible
            await dbContext.Destinations.AddAsync(destination);
            
            // Returns an int: 3,  seems to be the number when success
            await dbContext.SaveChangesAsync();
                       
            // Build a string in the right format (City, Country)
            String addr = destination.City + "," + destination.Country;
            Console.WriteLine("Ship to: " + addr);                                      //DEBUG

            // New Location instance
            Location location = new Location();
            
            // Get gps coordinates
            (double, double) gpsCoordinate = location.GetLatLng(addr);
            Console.WriteLine("GPS Coordinates (Long,Lat: (" + gpsCoordinate+")");      //DEBUG


            // Central Warehouse in Malmö: Lon, Lat= 55.5702828,12.8758892
            (double, double) centralWareHouseMalmo = (55.5702828,12.8758892);

            // Get the distance between coordinates
            double distance = GetDistance(centralWareHouseMalmo.Item1, centralWareHouseMalmo.Item2, gpsCoordinate.Item1, gpsCoordinate.Item2);

            // Get the cost

            double cost = GetCost(distance, 100);

           
        }

        public Task Delete(int Id)

        {
            
            throw new NotImplementedException();
        }

        public async Task DeleteDestination(int id)
        // a Task ->  Deletes the destination from database
        {
            var destination = await dbContext.Destinations.FindAsync(id);
            if (destination != null){ 
            dbContext.Destinations.Remove(destination);
            await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Destination>> GetAllDestinations()
        //  a Task ->  Gets all the destinations in database
        {
            var destinations = await dbContext.Destinations.ToListAsync();
            return destinations;
        }
        public async Task<Destination> GetDestinationById(int id)
        //  a Task -> Gets a destination by its id
        {
            var destination = await dbContext.Destinations.FindAsync(id);
            return destination;
        }

        public async Task UpdateDestination(int id, Destination destination)
        //  a Task -> Updates a destination by its id
        {
            var destinationObj = await dbContext.Destinations.FindAsync(id);
            destinationObj.Address = destination.Address;
            destinationObj.Country = destination.Country;
            destinationObj.City = destination.City;
            destinationObj.ZipCode = destination.ZipCode;
            await dbContext.SaveChangesAsync();
        }
    }

}

