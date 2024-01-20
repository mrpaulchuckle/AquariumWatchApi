using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AquariumWatch.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammonia",
                table: "Aquariums");

            migrationBuilder.DropColumn(
                name: "Nitrate",
                table: "Aquariums");

            migrationBuilder.DropColumn(
                name: "Nitrite",
                table: "Aquariums");

            migrationBuilder.DropColumn(
                name: "Ph",
                table: "Aquariums");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Ammonia",
                table: "Aquariums",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Nitrate",
                table: "Aquariums",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Nitrite",
                table: "Aquariums",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Ph",
                table: "Aquariums",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
