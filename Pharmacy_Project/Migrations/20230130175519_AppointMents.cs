using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_Project.Migrations
{
    public partial class AppointMents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_CitiesId",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Clincs_Areas_CityId",
                table: "Clincs");

            migrationBuilder.DropIndex(
                name: "IX_Clincs_CityId",
                table: "Clincs");

            migrationBuilder.DropIndex(
                name: "IX_Areas_CitiesId",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Clincs");

            migrationBuilder.DropColumn(
                name: "CitiesId",
                table: "Areas");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Areas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "AnalysisLapsAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lap_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisLapsAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisLapsAppointments_AnalysisLaps_Lap_Id",
                        column: x => x.Lap_Id,
                        principalTable: "AnalysisLaps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClincsAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clinc_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClincsAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClincsAppointments_Clincs_Clinc_Id",
                        column: x => x.Clinc_Id,
                        principalTable: "Clincs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HomeSlider",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SliderImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeSlider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HospitalsAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hosp_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HospitalsAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HospitalsAppointments_Hospitals_Hosp_Id",
                        column: x => x.Hosp_Id,
                        principalTable: "Hospitals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCentresAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    center_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCentresAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalCentresAppointments_MedicalCentres_center_Id",
                        column: x => x.center_Id,
                        principalTable: "MedicalCentres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PharmaciesAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Phar_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmaciesAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PharmaciesAppointments_Pharmacies_Phar_Id",
                        column: x => x.Phar_Id,
                        principalTable: "Pharmacies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "XRaysAppointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    xray_Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<bool>(type: "bit", nullable: false),
                    Code = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XRaysAppointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XRaysAppointments_Xrays_xray_Id",
                        column: x => x.xray_Id,
                        principalTable: "Xrays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CityId",
                table: "Areas",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisLapsAppointments_Lap_Id",
                table: "AnalysisLapsAppointments",
                column: "Lap_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ClincsAppointments_Clinc_Id",
                table: "ClincsAppointments",
                column: "Clinc_Id");

            migrationBuilder.CreateIndex(
                name: "IX_HospitalsAppointments_Hosp_Id",
                table: "HospitalsAppointments",
                column: "Hosp_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCentresAppointments_center_Id",
                table: "MedicalCentresAppointments",
                column: "center_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PharmaciesAppointments_Phar_Id",
                table: "PharmaciesAppointments",
                column: "Phar_Id");

            migrationBuilder.CreateIndex(
                name: "IX_XRaysAppointments_xray_Id",
                table: "XRaysAppointments",
                column: "xray_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_CityId",
                table: "Areas",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_Cities_CityId",
                table: "Areas");

            migrationBuilder.DropTable(
                name: "AnalysisLapsAppointments");

            migrationBuilder.DropTable(
                name: "ClincsAppointments");

            migrationBuilder.DropTable(
                name: "HomeSlider");

            migrationBuilder.DropTable(
                name: "HospitalsAppointments");

            migrationBuilder.DropTable(
                name: "MedicalCentresAppointments");

            migrationBuilder.DropTable(
                name: "PharmaciesAppointments");

            migrationBuilder.DropTable(
                name: "XRaysAppointments");

            migrationBuilder.DropIndex(
                name: "IX_Areas_CityId",
                table: "Areas");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Clincs",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "Areas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CitiesId",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Clincs_CityId",
                table: "Clincs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CitiesId",
                table: "Areas",
                column: "CitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_Cities_CitiesId",
                table: "Areas",
                column: "CitiesId",
                principalTable: "Cities",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clincs_Areas_CityId",
                table: "Clincs",
                column: "CityId",
                principalTable: "Areas",
                principalColumn: "Id");
        }
    }
}
