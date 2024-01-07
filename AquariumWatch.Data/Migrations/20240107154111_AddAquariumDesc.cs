using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquariumWatch.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAquariumDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Aquariums",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Aquariums");
        }
    }
}
