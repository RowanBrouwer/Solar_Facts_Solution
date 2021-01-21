using Microsoft.EntityFrameworkCore.Migrations;

namespace Solar_Facts.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SolarSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolarSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoreTemp = table.Column<int>(type: "int", nullable: false),
                    SolarSystemId = table.Column<int>(type: "int", nullable: false),
                    Age = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiameterInKM = table.Column<int>(type: "int", nullable: false),
                    SurfaceTempMin = table.Column<int>(type: "int", nullable: false),
                    SurfaceTempMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stars_SolarSystems_SolarSystemId",
                        column: x => x.SolarSystemId,
                        principalTable: "SolarSystems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlntAndDPlnt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarId = table.Column<int>(type: "int", nullable: false),
                    KnownMoons = table.Column<int>(type: "int", nullable: false),
                    OrbitDistanceInKM = table.Column<long>(type: "bigint", nullable: false),
                    OrbitPeriodInDays = table.Column<double>(type: "float", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiameterInKM = table.Column<int>(type: "int", nullable: false),
                    SurfaceTempMin = table.Column<int>(type: "int", nullable: false),
                    SurfaceTempMax = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlntAndDPlnt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlntAndDPlnt_Stars_StarId",
                        column: x => x.StarId,
                        principalTable: "Stars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "SolarSystems",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "The Solar system" });

            migrationBuilder.InsertData(
                table: "Stars",
                columns: new[] { "Id", "Age", "CoreTemp", "DiameterInKM", "Name", "SolarSystemId", "SurfaceTempMax", "SurfaceTempMin" },
                values: new object[] { 1, 4600000000L, 15000000, 1392694, "The Sun", 1, 5500, 5500 });

            migrationBuilder.InsertData(
                table: "PlntAndDPlnt",
                columns: new[] { "Id", "DiameterInKM", "KnownMoons", "Name", "OrbitDistanceInKM", "OrbitPeriodInDays", "StarId", "SurfaceTempMax", "SurfaceTempMin", "Type" },
                values: new object[,]
                {
                    { 1, 4879, 0, "Mercury", 57900000L, 88.0, 1, -173, -427, 0 },
                    { 2, 12104, 0, "Venus", 108200000L, 224.69999999999999, 1, 462, 462, 0 },
                    { 3, 12756, 1, "Earth", 149600000L, 224.69999999999999, 1, 58, -88, 0 },
                    { 4, 6805, 2, "Mars", 227900000L, 693.96000000000004, 1, -63, -63, 0 },
                    { 5, 950, 0, "Ceres", 413700000L, 1680.1099999999999, 1, -105, -105, 1 },
                    { 6, 142984, 67, "Jupiter", 778300000L, 4346.3800000000001, 1, -108, -108, 0 },
                    { 7, 120536, 62, "Saturn", 1400000000L, 10774.65, 1, -139, -139, 0 },
                    { 8, 51118, 27, "Uranus", 2900000000L, 30680.369999999999, 1, -197, -197, 0 },
                    { 9, 49528, 14, "Neptune", 4500000000L, 60191.959999999999, 1, -201, -201, 0 },
                    { 10, 2306, 5, "Pluto", 5900000000L, 89849.649999999994, 1, -229, -229, 1 },
                    { 11, 1739, 2, "Haumea", 6400000000L, 103473.2, 1, -241, -241, 1 },
                    { 12, 1434, 0, "Makemake", 6900000000L, 113188.64999999999, 1, -241, -241, 1 },
                    { 13, 1434, 1, "Eris", 10100000000L, 204864.51999999999, 1, -241, -241, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlntAndDPlnt_StarId",
                table: "PlntAndDPlnt",
                column: "StarId");

            migrationBuilder.CreateIndex(
                name: "IX_Stars_SolarSystemId",
                table: "Stars",
                column: "SolarSystemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlntAndDPlnt");

            migrationBuilder.DropTable(
                name: "Stars");

            migrationBuilder.DropTable(
                name: "SolarSystems");
        }
    }
}
