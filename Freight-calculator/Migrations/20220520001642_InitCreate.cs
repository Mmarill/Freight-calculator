using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freight_calculator.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryCost = table.Column<double>(type: "float", nullable: true),
                    Dilivered = table.Column<bool>(type: "bit", nullable: true),
                    Tariff = table.Column<double>(type: "float", nullable: true),
                    FixedCosts = table.Column<double>(type: "float", nullable: true),
                    DistanceInKm = table.Column<double>(type: "float", nullable: true),
                    VerboseMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");
        }
    }
}
