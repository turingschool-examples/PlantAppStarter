using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlantApp.Migrations
{
    /// <inheritdoc />
    public partial class RemoveHasSunlightFromRoom : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "has_sunlight",
                table: "rooms");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "has_sunlight",
                table: "rooms",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
