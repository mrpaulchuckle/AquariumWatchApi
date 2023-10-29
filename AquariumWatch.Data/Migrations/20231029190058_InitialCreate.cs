using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AquariumWatch.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aquariums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    HighTemp = table.Column<double>(type: "double precision", nullable: false),
                    LowTemp = table.Column<double>(type: "double precision", nullable: false),
                    Ph = table.Column<double>(type: "double precision", nullable: false),
                    Ammonia = table.Column<double>(type: "double precision", nullable: false),
                    Nitrite = table.Column<double>(type: "double precision", nullable: false),
                    Nitrate = table.Column<double>(type: "double precision", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aquariums", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aquariums");
        }
    }
}
