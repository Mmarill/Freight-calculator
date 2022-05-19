using Freight_calculator.Data;
using Freight_calculator.Interfaces;
using Freight_calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Freight_calculator.Services
{
    public class DeliveryService : IDeliverys  
    {
        private ApiDbContext dbContext;

        public DeliveryService()
        {
            dbContext = new ApiDbContext();
        }

        

        public async Task AddDelivery(Delivery aDelivery)
        // Adds a destination to SQL Database
        {
            
            Console.WriteLine("Recieved Address: " + aDelivery.Address + ", Zip: " + aDelivery.ZipCode + " City: " + aDelivery.City + " Country: " + aDelivery.Country);
               
            // Track Entity (Destination) 
            await dbContext.Deliveries.AddAsync(aDelivery);

            // Save address in database
            int records = await dbContext.SaveChangesAsync();
            Console.WriteLine("Address saved in database" + records + " affected.");

            // Trigger DeliveryService to return information about the delivery.
            // Delivery delivery = new Delivery(aDelivery.id,  aDelivery.City, aDelivery.Country, true);


           
        }

        
        public Task Delete(int Id)
         // Dont know this purpose should be archived or invissible
        {
            
            throw new NotImplementedException();
        }

        public async Task DeleteDelivery(int id)
        // a Task ->  Deletes the destination from database
        {
            var delivery = await dbContext.Deliveries.FindAsync(id);
            if (delivery != null){ 
            dbContext.Deliveries.Remove(delivery);
            await dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Delivery>> GetAllDeliveries()
        //  a Task ->  Gets all the delveries in database
        {
            var deliverys = await dbContext.Deliveries.ToListAsync();
            return deliverys;
        }
        public async Task<Delivery> GetDeliveryById(int id)
        //  a Task -> Gets a delivery by its id
        {
            var delivery = await dbContext.Deliveries.FindAsync(id);
            return delivery;
        }

        public async Task UpdateDelivery(int id, Delivery delivery)
        //  a Task -> Updates a delivery by its id
        {
            var destinationObj = await dbContext.Deliveries.FindAsync(id);
            destinationObj.Address = delivery.Address;
            destinationObj.City = delivery.City;
            destinationObj.ZipCode = delivery.ZipCode;
            destinationObj.Country = delivery.Country;

            destinationObj.AuctionId = delivery.AuctionId;

            destinationObj.DestinationGPSPoint = delivery.DestinationGPSPoint;
            destinationObj.AuctionGPSPoint = delivery.AuctionGPSPoint;

            destinationObj.DistanceInKm = delivery.DistanceInKm;
            destinationObj.Dilivered = delivery.Dilivered;

            destinationObj.Tariff = delivery.Tariff;
            destinationObj.FixedCosts = delivery.FixedCosts;

            destinationObj.DistanceInKm = delivery.DistanceInKm;


            destinationObj.AuctionGPSPoint = delivery.AuctionGPSPoint;
            destinationObj.DestinationGPSPoint = delivery.DestinationGPSPoint;
            
            destinationObj.VerboseMode = delivery.VerboseMode;


            
            int records = await dbContext.SaveChangesAsync();

            Console.WriteLine(" Updated" + " " + records + " affected.");
        }

        /*
        public async Task UpdateDestination(int id, double distance, double cost, Destination destination)
        //  a Task -> Updates a destination by its id. Overloaded
        {
            var destinationObj = await dbContext.Deliveries.FindAsync(id);
            destinationObj.Address = destination.Address;
            destinationObj.City = destination.City;
            destinationObj.ZipCode = destination.ZipCode;
            destinationObj.Country = destination.Country;
            destinationObj.AuctionId = destination.AuctionId;

            destinationObj.Distance2Destination = distance;
            destinationObj.DeliveryCost = cost;
            
            int records = await dbContext.SaveChangesAsync();
                
            Console.Write("number of records affected: " + records);
            Console.WriteLine(" records affected when added calculations: Travel Distance to delivery and Delivery cost.");
        }*/
    }

}

