using System.ComponentModel.DataAnnotations.Schema;
namespace Freight_calculator.Models
{
    public class Point2D
        
    {
        public int Id { get; set; }
        public double X { get; set; } = 0;

        public double Y { get; set; } = 0;

        public Point2D(double x = 0, double y = 0)
        {
            X = x;
            Y = y;
        }
    }
}
