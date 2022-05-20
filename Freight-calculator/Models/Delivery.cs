namespace Freight_calculator.Models

{
    public class Delivery

    {

        private int id;
        private string? address = "None";        
        private string city = "Malmö";
        private string? zipCode = "None";
        private string country = "Sverige";
        private string auctionId = "None";

        private Point2D? destinationGPSPoint = new Point2D(0.0,0.0); // MÅSTE SKAPA En instans på något ställe
        private Point2D? auctionGPSPoint = new Point2D(55.5702828, 12.8758881); // MÅSTE SKAPA En instans på något ställe

        private double? distanceInKm = 0;
        private bool? dilivered = false;
        
        private double? tariff = 5.0;
        private double? fixedCosts= 100;
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

        public Delivery() { }
        public Delivery(int id, string? city = default, string? country = default, string? auctionId = default, string? address = default, string? zipCode = default, Point2D? destinationGPSPoint = default , Point2D? auctionGPSPoint = default, double? distanceInKm = default, bool dilivered = default, double tariff = 0.0, double fixedCosts = default, double deliveryCost = default, bool verboseMode = default)
        {
            this.id = id;
            this.address = address;
            this.city = city ?? throw new ArgumentNullException(nameof(city));
            this.zipCode = zipCode;
            this.country = country ?? throw new ArgumentNullException(nameof(country));
            this.auctionId = auctionId ?? throw new ArgumentNullException(nameof(auctionId));
            
            
            
            this.dilivered = dilivered;
            this.tariff = tariff;
            this.fixedCosts = fixedCosts;
            this.deliveryCost = deliveryCost = 0;
            this.verboseMode = verboseMode;

            this.auctionGPSPoint = null;
            this.destinationGPSPoint = destinationGPSPoint;
            this.distanceInKm = distanceInKm;
            
            AuctionGPSPoint = default; // Skapas med default Point2D(0,0) i instansvariabeln
            Console.WriteLine("Constructor: AuctionGPSPoint set to default Point2D(55.5702828, 12.8758881");
            


            if (destinationGPSPoint == default)
            {
                DestinationGPSPoint = this.address2GPSPoint(city, country);
                Console.WriteLine("Constructor: address2GPSPoint called " + city+", " + country);
            }
            else DestinationGPSPoint = destinationGPSPoint;

            
            if (distanceInKm == default)
            {
                DistanceInKm = calculateDistanceInKm(AuctionGPSPoint, DestinationGPSPoint);
                Console.WriteLine("Constructor: calculateDistanceInKm called " + AuctionGPSPoint.X, AuctionGPSPoint.Y + DestinationGPSPoint.X, DestinationGPSPoint.Y);

            }

            if (deliveryCost == default)
            {
                DeliveryCost = calculateDeliveryCost(DistanceInKm.Value, Tariff.Value, FixedCosts.Value);
                Console.WriteLine("Constructor: calculateDeliveryCost called" , DistanceInKm.Value, Tariff.Value, FixedCosts.Value);
            }
        }
            
            
            
            


            
            

        
    

        public double calculateDeliveryCost(double distanceInKm, double tariff = 5.0, double fixedCosts = 99)
        // Some formula for get the Delivery Cost
        {
            DeliveryCost = distanceInKm * tariff + fixedCosts;

            if (this.VerboseMode) { Console.WriteLine("Total Delivery Cost: " + DeliveryCost + " SEK"); }

            double ret = DeliveryCost.Value;
            return ret;
        }


        public double? calculateDistanceInKm(Point2D? auctionGPSPoint, Point2D? destinationGPSPoint)
        // A ruff estiamtion formula for calculating distance: Haversine formula with no radian compensation
        {
            double long1 = auctionGPSPoint.X;
            double lat1 = auctionGPSPoint.Y;
            double long2 = destinationGPSPoint.X;
            double lat2 = destinationGPSPoint.Y;
            
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
