using Microsoft.EntityFrameworkCore.Migrations;

namespace Solar_Facts.DAL.Migrations
{
    public partial class EarthRotationDaysSeedCorrection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlntAndDPlnt",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrbitPeriodInDays",
                value: 365.19999999999999);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PlntAndDPlnt",
                keyColumn: "Id",
                keyValue: 3,
                column: "OrbitPeriodInDays",
                value: 224.69999999999999);
        }
    }
}
