using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transportathon_Project_EnesCakir.Migrations.AppDb
{
    /// <inheritdoc />
    public partial class inittablenamerevised : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyVehicle_Companies_CompaniesId",
                table: "CompanyVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyVehicle_Vehicles_VehiclesId",
                table: "CompanyVehicle");

            migrationBuilder.RenameColumn(
                name: "VehiclesId",
                table: "CompanyVehicle",
                newName: "VehicleId");

            migrationBuilder.RenameColumn(
                name: "CompaniesId",
                table: "CompanyVehicle",
                newName: "CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyVehicle_VehiclesId",
                table: "CompanyVehicle",
                newName: "IX_CompanyVehicle_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyVehicle_Companies_CompanyId",
                table: "CompanyVehicle",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyVehicle_Vehicles_VehicleId",
                table: "CompanyVehicle",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyVehicle_Companies_CompanyId",
                table: "CompanyVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyVehicle_Vehicles_VehicleId",
                table: "CompanyVehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "CompanyVehicle",
                newName: "VehiclesId");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "CompanyVehicle",
                newName: "CompaniesId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyVehicle_VehicleId",
                table: "CompanyVehicle",
                newName: "IX_CompanyVehicle_VehiclesId");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyVehicle_Companies_CompaniesId",
                table: "CompanyVehicle",
                column: "CompaniesId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyVehicle_Vehicles_VehiclesId",
                table: "CompanyVehicle",
                column: "VehiclesId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
