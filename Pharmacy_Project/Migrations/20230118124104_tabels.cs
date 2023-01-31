using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_Project.Migrations
{
    public partial class tabels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cite_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Complains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deails = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Complains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facebook_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Youtube_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Insta_Link = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Whatsapp_Link = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Terms_Conditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms_Conditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Area_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CitiesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_Cities_CitiesId",
                        column: x => x.CitiesId,
                        principalTable: "Cities",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnalysisLaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lap_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lap_NameImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lap_Descriprion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lap_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lap_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lap_LInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lap_FacebookLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lap_YoutubeLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lap_InstaLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lap_WhatsappLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lap_LocationLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Area_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnalysisLaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnalysisLaps_Areas_Area_Id",
                        column: x => x.Area_Id,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnalysisLaps_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clincs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clin_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clin_NameImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clin_Descriprion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clin_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Clin_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clin_LInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clin_FacebookLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clin_YoutubeLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clin_InstaLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clin_WhatsappLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Clin_LocationLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Area_Id = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clincs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clincs_Areas_Area_Id",
                        column: x => x.Area_Id,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clincs_Areas_CityId",
                        column: x => x.CityId,
                        principalTable: "Areas",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Clincs_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hospitals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Hospt_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospt_NameImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospt_Descriprion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospt_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hospt_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospt_LInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospt_FacebookLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospt_YoutubeLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospt_InstaLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospt_WhatsappLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hospt_LocationLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Area_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospitals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hospitals_Areas_Area_Id",
                        column: x => x.Area_Id,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Hospitals_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicalCentres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Centers_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Centers_NameImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Centers_Descriprion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Centers_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Centers_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Centers_LInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Centers_FacebookLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Centers_YoutubeLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Centers_InstaLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Centers_WhatsappLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Centers_LocationLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Area_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalCentres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicalCentres_Areas_Area_Id",
                        column: x => x.Area_Id,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MedicalCentres_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pharmacies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pharm_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharm_NameImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharm_Descriprion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharm_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pharm_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pharm_LInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pharm_FacebookLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pharm_YoutubeLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pharm_InstaLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pharm_WhatsappLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pharm_LocationLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Area_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pharmacies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pharmacies_Areas_Area_Id",
                        column: x => x.Area_Id,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pharmacies_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Xrays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Xray_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xray_NameImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xray_Descriprion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xray_Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Xray_rate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xray_LInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xray_FacebookLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xray_YoutubeLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xray_InstaLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xray_WhatsappLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Xray_LocationLInk = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City_Id = table.Column<int>(type: "int", nullable: false),
                    Area_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xrays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xrays_Areas_Area_Id",
                        column: x => x.Area_Id,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Xrays_Cities_City_Id",
                        column: x => x.City_Id,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisLaps_Area_Id",
                table: "AnalysisLaps",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_AnalysisLaps_City_Id",
                table: "AnalysisLaps",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_CitiesId",
                table: "Areas",
                column: "CitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Clincs_Area_Id",
                table: "Clincs",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clincs_City_Id",
                table: "Clincs",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Clincs_CityId",
                table: "Clincs",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_Area_Id",
                table: "Hospitals",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_City_Id",
                table: "Hospitals",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCentres_Area_Id",
                table: "MedicalCentres",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalCentres_City_Id",
                table: "MedicalCentres",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_Area_Id",
                table: "Pharmacies",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Pharmacies_City_Id",
                table: "Pharmacies",
                column: "City_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Xrays_Area_Id",
                table: "Xrays",
                column: "Area_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Xrays_City_Id",
                table: "Xrays",
                column: "City_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnalysisLaps");

            migrationBuilder.DropTable(
                name: "Clincs");

            migrationBuilder.DropTable(
                name: "Complains");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Hospitals");

            migrationBuilder.DropTable(
                name: "MedicalCentres");

            migrationBuilder.DropTable(
                name: "Pharmacies");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Terms_Conditions");

            migrationBuilder.DropTable(
                name: "Xrays");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
