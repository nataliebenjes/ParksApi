using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParkApi.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 1928);

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "FoundedIn", "Name", "Type" },
                values: new object[] { 3, 1938, "Bryce", "National" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Parks",
                keyColumn: "ParkId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "FoundedIn", "Name", "Type" },
                values: new object[] { 1928, 2, "Bryce", "National" });
        }
    }
}
