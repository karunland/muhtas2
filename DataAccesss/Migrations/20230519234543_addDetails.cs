using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesss.Migrations
{
    /// <inheritdoc />
    public partial class addDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Details",
                table: "MonitorShow",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Details",
                table: "MonitorShow");
        }
    }
}
