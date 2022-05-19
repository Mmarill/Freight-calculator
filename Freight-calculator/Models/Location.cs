using Google.Type;
using GoogleMaps.LocationServices;

namespace Freight_calculator.Models
{
    public class Location
    {
        public Point2D GetLatLng(string address)
        {
            var locationService = new GoogleLocationService(apikey:"AIzaSyDI2Msk3RNGV02CWC2f2EpVtSA7tR0wguU");
            var point = locationService.GetLatLongFromAddress(address);

            var latitude = point.Latitude;
            var longitude = point.Longitude;
            Point2D GPSPoint = new Point2D(latitude, longitude);
            return GPSPoint;
        }
    }
    }

