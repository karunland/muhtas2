using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesss.Migrations
{
    /// <inheritdoc />
    public partial class updatename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.CreateTable(
                name: "Mcu",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Red = table.Column<long>(type: "bigint", nullable: false),
                    Green = table.Column<long>(type: "bigint", nullable: false),
                    Blue = table.Column<long>(type: "bigint", nullable: false),
                    Distance = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mcu", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mcu");

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Distance = table.Column<long>(type: "bigint", nullable: false),
                    blue = table.Column<long>(type: "bigint", nullable: false),
                    green = table.Column<long>(type: "bigint", nullable: false),
                    red = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.Id);
                });
        }
    }
}
