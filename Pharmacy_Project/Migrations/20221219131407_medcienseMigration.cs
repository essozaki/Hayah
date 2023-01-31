using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pharmacy_Project.Migrations
{
    public partial class medcienseMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Medicens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "GrandMotherName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "GrandFatherName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "FirstWife",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FourthWife",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SecendWife",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ThirdWife",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medicens_ClientId",
                table: "Medicens",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medicens_Client_ClientId",
                table: "Medicens",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medicens_Client_ClientId",
                table: "Medicens");

            migrationBuilder.DropIndex(
                name: "IX_Medicens_ClientId",
                table: "Medicens");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Medicens");

            migrationBuilder.DropColumn(
                name: "FirstWife",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "FourthWife",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "SecendWife",
                table: "Client");

            migrationBuilder.DropColumn(
                name: "ThirdWife",
                table: "Client");

            migrationBuilder.AlterColumn<string>(
                name: "GrandMotherName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "GrandFatherName",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
