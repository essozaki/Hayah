using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_Project.Migrations
{
    public partial class med : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicens");

            migrationBuilder.DropTable(
                name: "Wifes");

            migrationBuilder.AddColumn<string>(
                name: "Medicense",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Medicense",
                table: "Client");

            migrationBuilder.CreateTable(
                name: "Medicens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    MedName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicens_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wifes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WifeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wifes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Medicens_ClientId",
                table: "Medicens",
                column: "ClientId");
        }
    }
}
