using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccesss.Migrations
{
    /// <inheritdoc />
    public partial class addDetailsUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Details",
                table: "MonitorShow",
                newName: "DetailsSection");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DetailsSection",
                table: "MonitorShow",
                newName: "Details");
        }
    }
}
