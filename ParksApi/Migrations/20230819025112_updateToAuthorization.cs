using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ParksApi.Migrations
{
    public partial class updateToAuthorization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoundedIn = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "FoundedIn", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1932, "Grand Canyon", "National" },
                    { 2, 1919, "Zion", "National" },
                    { 3, 1938, "Bryce", "National" },
                    { 4, 1915, "Rocky Mountain", "National" },
                    { 5, 1938, "Olympic Penninsula", "National" },
                    { 6, 1933, "Silver Falls", "State" },
                    { 7, 1948, "Sunset Bay", "State" },
                    { 8, 2007, "LL Stub Stewart", "State" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
