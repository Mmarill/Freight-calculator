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
        
        public string Zip { get; set; } // New

        public string AuctionObjectId { get; set; }  // New

        public double Distance2Destination { get; set; }  // New

        public double DeliveryCost { get; set; }  // New

    }
}
