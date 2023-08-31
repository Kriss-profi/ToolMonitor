using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToolMonitor.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedCompanyId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FirstnameName",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.AddColumn<int>(
                name: "UserStatus",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserStatus",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "FirstnameName");
        }
    }
}
