using Google.Type;
using GoogleMaps.LocationServices;

namespace Freight_calculator.Models
{
    public class Location
    {
        public (double, double) GetLatLng(string address)
        {
            var locationService = new GoogleLocationService(apikey:"AIzaSyDI2Msk3RNGV02CWC2f2EpVtSA7tR0wguU");
            var point = locationService.GetLatLongFromAddress(address);

            var latitude = point.Latitude;
            var longitude = point.Longitude;

            return (latitude, longitude);
        }
    }
    }

