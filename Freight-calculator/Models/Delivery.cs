namespace Freight_calculator.Models

{
    public class Delivery

    {

        private int id;
        private string? address = "None";        
        private string city = "None";
        private string? zipCode = "None";
        private string country = "None";
        private string auctionId = "None";

        private Point2D? destinationGPSPoint = new Point2D(52.3789004443169, 4.892281168298614); // ;)
        private Point2D? auctionGPSPoint = new Point2D(55.5702828, 12.8758892); // Malmö

        private double? distanceInKm = 0;
        private bool? dilivered = false;

        private double? tariff;
        private double? fixedCosts;
        private double? deliveryCost = 0;
        
        private bool verboseMode = true;


        public int Id { get => id; set => id = value; }
        public string? Address { get => address; set => address = value; }
        public string City { get => city; set => city = value; }
        public string? ZipCode { get => zipCode; set => zipCode = value; }
        public string Country { get => country; set => country = value; }
        
        public string AuctionId { get => auctionId; set => auctionId = value; }

        
        
        
        public double? DeliveryCost { get => deliveryCost; set => deliveryCost = value; }
        public bool? Dilivered { get => dilivered; set => dilivered = value; }
        
        
        public double? Tariff { get => tariff; set => tariff = value; }
        public double? FixedCosts { get => fixedCosts; set => fixedCosts = value; }

        public double? DistanceInKm { get => distanceInKm; set => distanceInKm = value; }
        public Point2D? DestinationGPSPoint { get => destinationGPSPoint; set => destinationGPSPoint = value; }
        public Point2D? AuctionGPSPoint { get => auctionGPSPoint; set => auctionGPSPoint = value; }
        public bool VerboseMode { get => verboseMode; set => verboseMode = value; }

        public Delivery()
        {


            // Populate the rest of the fields
            

            this.DestinationGPSPoint = address2GPSPoint(city, country);
            this.DistanceInKm = calculateDistanceInKm(this.AuctionGPSPoint, this.DestinationGPSPoint);
            this.DeliveryCost = calculateDeliveryCost(this.DistanceInKm.Value, this.Tariff.Value, this.FixedCosts.Value);
            
        }

        
        public double calculateDeliveryCost(double distanceInKm, double tariff = 5.0, double fixedCosts = 99)
        // Some formula for get the Delivery Cost
        {
            DeliveryCost = distanceInKm * tariff + fixedCosts;

            if (this.VerboseMode) { Console.WriteLine("Total Delivery Cost: " + DeliveryCost + " SEK"); }

            double ret = DeliveryCost.Value;
            return ret;
        }


        public double calculateDistanceInKm(Point2D GPSPoint1, Point2D GPSPoint2)
        // A ruff estiamtion formula for calculating distance: Haversine formula with no radian compensation
        {
            double long1 = GPSPoint1.X;
            double lat1 = GPSPoint2.Y;
            double long2 = GPSPoint2.X;
            double lat2 = GPSPoint2.Y;
            
            double _eQuatorialEarthRadius = 6378.1370D;
            double _d2r = Math.PI / 180D;

            double dlong = (long2 - long1) * _d2r;
            double dlat = (lat2 - lat1) * _d2r;
            double a = Math.Pow(Math.Sin(dlat / 2D), 2D) + Math.Cos(lat1 * _d2r) * Math.Cos(lat2 * _d2r) * Math.Pow(Math.Sin(dlong / 2D), 2D);
            double c = 2D * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1D - a));
            double d = _eQuatorialEarthRadius * c;

            if ((bool)VerboseMode) { Console.WriteLine("Calculated distance between Warehouse Malmö to Destination with UAV transport ltd: " + d); }

            this.DistanceInKm = d;
            
            return d;
        }

        public Point2D address2GPSPoint(string city, string country)
        // Calculate gps coordinates of a given address
        {
            string addr = this.City + "," + this.Country;

            // Create a new Location instance if (verboseMode) { }
            Location location = new Location();

            // Set destionationGPSPoint
            DestinationGPSPoint = location.GetLatLng(addr);

            if (VerboseMode) { Console.WriteLine("The address has GPS Point: (" + DestinationGPSPoint + " )"); }
            return DestinationGPSPoint;
        }

    }
}
