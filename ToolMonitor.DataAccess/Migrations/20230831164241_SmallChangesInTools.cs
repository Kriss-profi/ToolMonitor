using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolMonitor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SmallChangesInTools : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Web",
                table: "Dealers",
                newName: "DealerWeb");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Dealers",
                newName: "DealerName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DealerWeb",
                table: "Dealers",
                newName: "Web");

            migrationBuilder.RenameColumn(
                name: "DealerName",
                table: "Dealers",
                newName: "Name");
        }
    }
}
