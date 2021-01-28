using Microsoft.EntityFrameworkCore.Migrations;

namespace Solar_Facts.DAL.Migrations
{
    public partial class movedPlanetsToSolarSystemAndAdjustedTheServicesAndTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlntAndDPlnt_Stars_StarId",
                table: "PlntAndDPlnt");

            migrationBuilder.RenameColumn(
                name: "StarId",
                table: "PlntAndDPlnt",
                newName: "SolarSystemId");

            migrationBuilder.RenameIndex(
                name: "IX_PlntAndDPlnt_StarId",
                table: "PlntAndDPlnt",
                newName: "IX_PlntAndDPlnt_SolarSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlntAndDPlnt_SolarSystems_SolarSystemId",
                table: "PlntAndDPlnt",
                column: "SolarSystemId",
                principalTable: "SolarSystems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlntAndDPlnt_SolarSystems_SolarSystemId",
                table: "PlntAndDPlnt");

            migrationBuilder.RenameColumn(
                name: "SolarSystemId",
                table: "PlntAndDPlnt",
                newName: "StarId");

            migrationBuilder.RenameIndex(
                name: "IX_PlntAndDPlnt_SolarSystemId",
                table: "PlntAndDPlnt",
                newName: "IX_PlntAndDPlnt_StarId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlntAndDPlnt_Stars_StarId",
                table: "PlntAndDPlnt",
                column: "StarId",
                principalTable: "Stars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
