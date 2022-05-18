namespace Freight_calculator.Services

{
    
    using Freight_calculator.Models;
    
    public class DeliveryService
    
    {
        private (double, double) malmo = (55.5702828, 12.8758892);
        private string city;
        private string country;
        private string auctionId;

        private (double, double) destinationGPSPoint;

        private double distanceInKm;
        private double deliveryCost;
        
        private bool verboseMode;

        public DeliveryService(int destinationId, string city, string country, bool verbose = true)
        {
            this.verboseMode = verbose;

            this.city = city;
            this.country = country;

            // Populate the rest of the fields
            this.getGPSPoint(city, country);
            this.GetDistanceInKm(malmo.Item1, malmo.Item2, destinationGPSPoint.Item1, destinationGPSPoint.Item2);
            this.setDeliveryCost(this.distanceInKm);

            // uppdate destination 
            // 

            // Write message done

            // SelfDestruct
        }
        
        public double setDeliveryCost(double distanceInKm, double tariff = 5.0, double fixedCosts = 99)
            // Some formula for get the Delivery Cost
        {
            this.deliveryCost = distanceInKm * tariff + fixedCosts;

            if (verboseMode) { Console.WriteLine("Total Delivery Cost: " + this.deliveryCost + " SEK"); }
            
            return this.deliveryCost;
        }
        
        public double GetDistanceInKm(double lat1, double long1, double lat2, double long2)
        // A ruff estiamtion formula for calculating distance: Haversine formula with no radian compensation
        {

            double _eQuatorialEarthRadius = 6378.1370D;
            double _d2r = (Math.PI / 180D);

            double dlong = (long2 - long1) * _d2r;
            double dlat = (lat2 - lat1) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            if (verboseMode) { Console.WriteLine("Calculated distance between Warehouse Malmö to Destination with UAV transport ltd: " + d); }

            return d;
        }
        
        public (double, double) getGPSPoint(string city, string country)
            // Calculate gps coordinates of a given address
        { 
            String addr = this.city + "," + this.country;
            
            // Create a new Location instance if (verboseMode) { }
            Location location = new Location();

            // Set destionationGPSPoint
            this.destinationGPSPoint = location.GetLatLng(addr);

            if (verboseMode) { Console.WriteLine("The address has GPS Point: (" + this.destinationGPSPoint + " )"); }
            return this.destinationGPSPoint;
        }

    }
}
