using GoogleMaps.LocationServices;

namespace Freight_calculator.Models
{
    public class Destination
    {   
        public int Id { get; set; }
        
        public User? user { get; set; }
        
        public string? Address { get; set; }
        
        public string? City { get; set; } = null;
        
        public string? Country { get; set; } = null;
        
        public int ZipCode { get; set; }
        
        public Auction? auction { get; set; }

        // Om man vill använda sig av konstiga format
        public string Zip { get; set; } = "123 45"; // New

        public string AuctionObjectId { get; set; } = ""; // New

        public double Distance2Destination { get; set; } = 0.0;  // New

        public double DeliveryCost { get; set; } = 0.0; // New

    }
}
