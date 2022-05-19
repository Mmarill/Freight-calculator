using System.ComponentModel.DataAnnotations.Schema;
namespace Freight_calculator.Models
{
    public class Point2D
        
    {
        public int Id { get; set; }
        public double X { get; set; }

        public double Y { get; set; }

        public Point2D(double x, double y)
        {
            
            X = x;
            Y = y;
        }
    }
}
