using GoogleMaps.LocationServices;

namespace Freight_calculator.Models
{
    public class Destination
    {   
        public int Id { get; set; }
        
        // string userId had been enough.
        public User? user { get; set; }
        
        // Nullable not needed in App
        public string? Address { get; set; }
        
        // Mandatory -> gps coord.. Make it not nullable next migration/update
        public string? City { get; set; } = null;

        // Mandatory -> gps coord.. Make it not nullable next migration/update
        public string? Country { get; set; } = null;
       
        public int ZipCode { get; set; }
        
        public Auction? auction { get; set; }

        public string Zip { get; set; } = "123 45";

        
        public string AuctionObjectId { get; set; } = "";

        // Update record when calculated
        public double Distance2Destination { get; set; } = 0.0;  // New

        // Update record when calculated
        public double DeliveryCost { get; set; } = 0.0; // New

    }
}
