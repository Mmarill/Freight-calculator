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

        public async Task AddDestination(Destination destination)
        {
            await dbContext.Destinations.AddAsync(destination);
            await dbContext.SaveChangesAsync();
        }

        public Task Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteDestination(int id)
        {
            var destination = await dbContext.Destinations.FindAsync(id);
            dbContext.Destinations.Remove(destination);
            await dbContext.SaveChangesAsync();
        }

        public async Task<List<Destination>> GetAllDestinations()
        {
            var destinations = await dbContext.Destinations.ToListAsync();
            return destinations;
        }
        public async Task<Destination> GetDestinationById(int id)
        {
            var destination = await dbContext.Destinations.FindAsync(id);
            return destination;
        }

        public async Task UpdateDestination(int id, Destination destination)
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

