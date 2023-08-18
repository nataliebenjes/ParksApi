using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkApi.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Park",
                table: "Park");

            migrationBuilder.RenameTable(
                name: "Park",
                newName: "Parks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Parks",
                table: "Parks",
                column: "ParkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Parks",
                table: "Parks");

            migrationBuilder.RenameTable(
                name: "Parks",
                newName: "Park");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Park",
                table: "Park",
                column: "ParkId");
        }
    }
}
