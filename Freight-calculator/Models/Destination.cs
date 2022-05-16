using GoogleMaps.LocationServices;

namespace Freight_calculator.Models
{
    public class Destination
    {   
        public int Id { get; set; }
        public User user { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int ZipCode { get; set; }
        public Auction auction { get; set; }
        
    }
}
