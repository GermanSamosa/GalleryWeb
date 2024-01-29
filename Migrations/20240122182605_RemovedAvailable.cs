using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebGallery.Migrations
{
    /// <inheritdoc />
    public partial class RemovedAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Available",
                table: "Piece");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Available",
                table: "Piece",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
