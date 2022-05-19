using Freight_calculator.Models;
using Microsoft.EntityFrameworkCore;

namespace Freight_calculator.Data
{
        // config för databas
        public class ApiDbContext : DbContext

        {
        public DbSet<Point2D>? GPSPoints { get; set; }   
        public DbSet<Delivery> Deliveries { get; set; }
            

            // connections to string to this db contex class
            // override OnConfi...
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                base.OnConfiguring(optionsBuilder);
                //remove

                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Database=ApiDbMSv2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
                // 
                // server object explorer windows
            }
        }
 }

