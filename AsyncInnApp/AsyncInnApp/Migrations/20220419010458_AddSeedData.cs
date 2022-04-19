using Microsoft.EntityFrameworkCore.Migrations;

namespace AsyncInnApp.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "amenity1" },
                    { 2, "amenity2" },
                    { 3, "amenity3" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "id", "city", "country", "name", "phone", "state", "streetAddress" },
                values: new object[,]
                {
                    { 1, "Amman", "Jordan", "AsyncInn1", 123, "#", "street a-1" },
                    { 2, "Irbid", "Jordan", "AsyncInn2", 789, "#", "street a-2" },
                    { 3, "Madaba", "Jordan", "AsyncInn3", 321, "#", "street a-3" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "id", "layout", "name" },
                values: new object[,]
                {
                    { 1, 1, "room1" },
                    { 2, 2, "room2" },
                    { 3, 3, "room3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}
