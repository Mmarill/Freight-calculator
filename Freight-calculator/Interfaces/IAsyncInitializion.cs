using Freight_calculator.Models;

namespace Freight_calculator.Interfaces
{
    public interface IAsyncInitializion
    {
        public int Id { get; set; }
       
        public string? Address { get; set; }
        public string City { get; set; }
        public string? ZipCode { get; set; }
        public string Country { get; set; }

        public string AuctionId { get; set; }


        

        public double? DeliveryCost { get; set; }
        public bool? Dilivered { get; set; }


        public double? Tariff { get; set; }
        public double? FixedCosts { get; set; }

        public double? DistanceInKm { get; set; }
        public Point2D? DestinationGPSPoint { get; set; }
        public Point2D? AuctionGPSPoint { get; set; }
        public bool VerboseMode { get; set; }
        Task Initializaion { get; }

         


        private async Task<Object> InitializeAsync()
        {
            // asyncData = await GetDataAsync();
            
            return this;
        }
    }
}
