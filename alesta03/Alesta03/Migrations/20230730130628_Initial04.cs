using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alesta03.Migrations
{
    /// <inheritdoc />
    public partial class Initial04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "People",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AppLetter",
                table: "BackWorks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmployeeID",
                table: "BackWorks",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "People");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "AppLetter",
                table: "BackWorks");

            migrationBuilder.DropColumn(
                name: "EmployeeID",
                table: "BackWorks");
        }
    }
}
