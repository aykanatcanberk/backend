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
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_BackWorks_BackWorkId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_Companies_CompanyId",
                table: "Approvals");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals");

            migrationBuilder.DropIndex(
                name: "IX_Approvals_BackWorkId",
                table: "Approvals");

            migrationBuilder.RenameTable(
                name: "Approvals",
                newName: "ApprovalStatuses");

            migrationBuilder.RenameIndex(
                name: "IX_Approvals_CompanyId",
                table: "ApprovalStatuses",
                newName: "IX_ApprovalStatuses_CompanyId");

            migrationBuilder.AddColumn<string>(
                name: "CompanyMail",
                table: "BackWorks",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ApprovalStatuses",
                table: "ApprovalStatuses",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_ApprovalStatuses_BackWorkId",
                table: "ApprovalStatuses",
                column: "BackWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalStatuses_BackWorks_BackWorkId",
                table: "ApprovalStatuses",
                column: "BackWorkId",
                principalTable: "BackWorks",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApprovalStatuses_Companies_CompanyId",
                table: "ApprovalStatuses",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalStatuses_BackWorks_BackWorkId",
                table: "ApprovalStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ApprovalStatuses_Companies_CompanyId",
                table: "ApprovalStatuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ApprovalStatuses",
                table: "ApprovalStatuses");

            migrationBuilder.DropIndex(
                name: "IX_ApprovalStatuses_BackWorkId",
                table: "ApprovalStatuses");

            migrationBuilder.DropColumn(
                name: "CompanyMail",
                table: "BackWorks");

            migrationBuilder.RenameTable(
                name: "ApprovalStatuses",
                newName: "Approvals");

            migrationBuilder.RenameIndex(
                name: "IX_ApprovalStatuses_CompanyId",
                table: "Approvals",
                newName: "IX_Approvals_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Approvals",
                table: "Approvals",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Approvals_BackWorkId",
                table: "Approvals",
                column: "BackWorkId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_BackWorks_BackWorkId",
                table: "Approvals",
                column: "BackWorkId",
                principalTable: "BackWorks",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_Companies_CompanyId",
                table: "Approvals",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID");
        }
    }
}
