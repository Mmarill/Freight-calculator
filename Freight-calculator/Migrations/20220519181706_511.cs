using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Freight_calculator.Migrations
{
    public partial class _511 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GPSPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    X = table.Column<double>(type: "float", nullable: false),
                    Y = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSPoints", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuctionId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeliveryCost = table.Column<double>(type: "float", nullable: true),
                    Dilivered = table.Column<bool>(type: "bit", nullable: true),
                    Tariff = table.Column<double>(type: "float", nullable: true),
                    FixedCosts = table.Column<double>(type: "float", nullable: true),
                    DistanceInKm = table.Column<double>(type: "float", nullable: true),
                    DestinationGPSPointId = table.Column<int>(type: "int", nullable: true),
                    AuctionGPSPointId = table.Column<int>(type: "int", nullable: true),
                    VerboseMode = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deliveries_GPSPoints_AuctionGPSPointId",
                        column: x => x.AuctionGPSPointId,
                        principalTable: "GPSPoints",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Deliveries_GPSPoints_DestinationGPSPointId",
                        column: x => x.DestinationGPSPointId,
                        principalTable: "GPSPoints",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_AuctionGPSPointId",
                table: "Deliveries",
                column: "AuctionGPSPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_DestinationGPSPointId",
                table: "Deliveries",
                column: "DestinationGPSPointId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "GPSPoints");
        }
    }
}
