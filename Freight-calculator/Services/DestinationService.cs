using Freight_calculator.Data;
using Freight_calculator.Interfaces;
using Freight_calculator.Models;
using Freight_calculator.Services;
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

        

        public async Task AddDestination(Destination destination)
        // Adds a destination to SQL Database
        {
            
            Console.WriteLine("Recieved Address: " + destination.Address + ", Zip: " + destination.Zip + " City: " + destination.City +
                " Country: " + destination.Country);
               
            // Track Entity (Destination) 
            await dbContext.Destinations.AddAsync(destination);

            // Save address in database
            int records = await dbContext.SaveChangesAsync();
            Console.WriteLine("Address saved in database" + records + " affected.");

            // Trigger DeliveryService to return information about the delivery.
            DeliveryService delivery = new DeliveryService(destination.Id,  destination.City, destination.Country, true);


           
        }

        
        public Task Delete(int Id)
         // Dont know this purpose
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
            destinationObj.City = destination.City;
            destinationObj.Country = destination.Country;
            destinationObj.ZipCode = destination.ZipCode;
            destinationObj.Zip = destination.Zip;
            destinationObj.AuctionObjectId = destination.AuctionObjectId;
            destinationObj.Distance2Destination = destination.Distance2Destination;
            destinationObj.DeliveryCost = destination.DeliveryCost;
            int records = await dbContext.SaveChangesAsync();
            Console.Write(records);
            Console.WriteLine(" Updated, records affected.");
        }

        public async Task UpdateDestination(int id, double distance, double cost, Destination destination)
        //  a Task -> Updates a destination by its id. Overloaded
        {
            var destinationObj = await dbContext.Destinations.FindAsync(id);
            destinationObj.Address = destination.Address;
            destinationObj.City = destination.City;
            destinationObj.Country = destination.Country;
            destinationObj.ZipCode = destination.ZipCode;
            destinationObj.Zip = destination.Zip;
            destinationObj.AuctionObjectId = destination.AuctionObjectId;
            destinationObj.Distance2Destination = distance;
            destinationObj.DeliveryCost = cost;
            
            int records = await dbContext.SaveChangesAsync();
                
            Console.Write("number of records affected: " + records);
            Console.WriteLine(" records affected when added calculations: Travel Distance to destination and Delivery cost.");
        }
    }

}

