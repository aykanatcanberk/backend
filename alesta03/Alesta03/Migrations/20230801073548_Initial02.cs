using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alesta03.Migrations
{
    /// <inheritdoc />
    public partial class Initial02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "companyID",
                table: "BackWorks",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BackWorks_companyID",
                table: "BackWorks",
                column: "companyID");

            migrationBuilder.AddForeignKey(
                name: "FK_BackWorks_Companies_companyID",
                table: "BackWorks",
                column: "companyID",
                principalTable: "Companies",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BackWorks_Companies_companyID",
                table: "BackWorks");

            migrationBuilder.DropIndex(
                name: "IX_BackWorks_companyID",
                table: "BackWorks");

            migrationBuilder.DropColumn(
                name: "companyID",
                table: "BackWorks");
        }
    }
}
