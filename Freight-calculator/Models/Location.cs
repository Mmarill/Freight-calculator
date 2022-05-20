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
            Point2D gPSPoint = new Point2D();
            gPSPoint.X = (double)latitude;
            gPSPoint.Y = (double)longitude;
            Console.WriteLine("Location: " + gPSPoint.X + ", " + gPSPoint.Y);
            return  gPSPoint ;
        }
    }
    }

