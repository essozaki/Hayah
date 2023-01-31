using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_Project.Migrations
{
    public partial class Lastedite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnalysisLaps_Cities_City_Id",
                table: "AnalysisLaps");

            migrationBuilder.DropForeignKey(
                name: "FK_Clincs_Cities_City_Id",
                table: "Clincs");

            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Cities_City_Id",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalCentres_Cities_City_Id",
                table: "MedicalCentres");

            migrationBuilder.DropForeignKey(
                name: "FK_Pharmacies_Cities_City_Id",
                table: "Pharmacies");

            migrationBuilder.DropForeignKey(
                name: "FK_Xrays_Cities_City_Id",
                table: "Xrays");

            migrationBuilder.DropIndex(
                name: "IX_Xrays_City_Id",
                table: "Xrays");

            migrationBuilder.DropIndex(
                name: "IX_Pharmacies_City_Id",
                table: "Pharmacies");

            migrationBuilder.DropIndex(
                name: "IX_MedicalCentres_City_Id",
                table: "MedicalCentres");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_City_Id",
                table: "Hospitals");

            migrationBuilder.DropIndex(
                name: "IX_Clincs_City_Id",
                table: "Clincs");

            migrationBuilder.DropIndex(
                name: "IX_AnalysisLaps_City_Id",
                table: "AnalysisLaps");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "Xrays");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "MedicalCentres");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "Clincs");

            migrationBuilder.DropColumn(
                name: "City_Id",
                table: "AnalysisLaps");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "ContactUs",
                newName: "Address");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "ContactUs",
                newName: "Location");

            migrationBuilder.AddColumn<int>(
                name: "City_Id",
                table: "Xrays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "City_Id",
                table: "Pharmacies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "City_Id",
                table: "MedicalCentres",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "City_Id",
                table: "Hospitals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "City_Id",
                table: "Clincs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "City_Id",
                table: "AnalysisLaps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Xrays_City_Id",
                table: "Xrays",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_City_Id",
                table: "Pharmacies",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCentres_City_Id",
                table: "MedicalCentres",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_City_Id",
                table: "Hospitals",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clincs_City_Id",
                table: "Clincs",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisLaps_City_Id",
                table: "AnalysisLaps",
                column: "City_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnalysisLaps_Cities_City_Id",
                table: "AnalysisLaps",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clincs_Cities_City_Id",
                table: "Clincs",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Cities_City_Id",
                table: "Hospitals",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalCentres_Cities_City_Id",
                table: "MedicalCentres",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Pharmacies_Cities_City_Id",
                table: "Pharmacies",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Xrays_Cities_City_Id",
                table: "Xrays",
                column: "City_Id",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
