using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GrowFurthers.Migrations
{
    /// <inheritdoc />
    public partial class minorchange1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amenities",
                table: "Hotels");

            migrationBuilder.AddColumn<int>(
                name: "hotelId",
                table: "Amenities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "hotelId",
                table: "Amenities");

            migrationBuilder.AddColumn<string>(
                name: "Amenities",
                table: "Hotels",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
