namespace Freight_calculator.Models
{
    public class Point2D
    {
        private double x = 0;
        private double y = 0;

        public Point2D() { }
        
        public Point2D(double x, double y)
        {
            this.x = x; this.y = y;

        }
        public double item1 { get; set; }
        public double item2 { get; set; }
    }
}
