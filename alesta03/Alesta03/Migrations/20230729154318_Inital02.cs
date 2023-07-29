using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Alesta03.Migrations
{
    /// <inheritdoc />
    public partial class Inital02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_BackWorks_BackWorkId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_BackEdus_Companies_CompanyId",
                table: "BackEdus");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UsersId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_EduStatuses_BackEdus_BackEduId",
                table: "EduStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_EduStatuses_People_PersonId",
                table: "EduStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpReviews_Companies_CompanyId",
                table: "ExpReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpReviews_People_PersonId",
                table: "ExpReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Users_UsersId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkStatuses_BackWorks_BackWorkId",
                table: "WorkStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkStatuses_People_PersonId",
                table: "WorkStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Users_RolesId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RolesId",
                table: "Users");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "WorkStatuses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BackWorkId",
                table: "WorkStatuses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "People",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "ExpReviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "ExpReviews",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "EduStatuses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BackEduId",
                table: "EduStatuses",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Companies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "BackEdus",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BackWorkId",
                table: "Approvals",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_BackWorks_BackWorkId",
                table: "Approvals",
                column: "BackWorkId",
                principalTable: "BackWorks",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_BackEdus_Companies_CompanyId",
                table: "BackEdus",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UsersId",
                table: "Companies",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EduStatuses_BackEdus_BackEduId",
                table: "EduStatuses",
                column: "BackEduId",
                principalTable: "BackEdus",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_EduStatuses_People_PersonId",
                table: "EduStatuses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpReviews_Companies_CompanyId",
                table: "ExpReviews",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExpReviews_People_PersonId",
                table: "ExpReviews",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_People_Users_UsersId",
                table: "People",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkStatuses_BackWorks_BackWorkId",
                table: "WorkStatuses",
                column: "BackWorkId",
                principalTable: "BackWorks",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkStatuses_People_PersonId",
                table: "WorkStatuses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Approvals_BackWorks_BackWorkId",
                table: "Approvals");

            migrationBuilder.DropForeignKey(
                name: "FK_BackEdus_Companies_CompanyId",
                table: "BackEdus");

            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Users_UsersId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_EduStatuses_BackEdus_BackEduId",
                table: "EduStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_EduStatuses_People_PersonId",
                table: "EduStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpReviews_Companies_CompanyId",
                table: "ExpReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_ExpReviews_People_PersonId",
                table: "ExpReviews");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Users_UsersId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkStatuses_BackWorks_BackWorkId",
                table: "WorkStatuses");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkStatuses_People_PersonId",
                table: "WorkStatuses");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "WorkStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BackWorkId",
                table: "WorkStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RolesId",
                table: "Users",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "People",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "ExpReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "ExpReviews",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "EduStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BackEduId",
                table: "EduStatuses",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsersId",
                table: "Companies",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "BackEdus",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BackWorkId",
                table: "Approvals",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RolesId",
                table: "Users",
                column: "RolesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Approvals_BackWorks_BackWorkId",
                table: "Approvals",
                column: "BackWorkId",
                principalTable: "BackWorks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BackEdus_Companies_CompanyId",
                table: "BackEdus",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Users_UsersId",
                table: "Companies",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EduStatuses_BackEdus_BackEduId",
                table: "EduStatuses",
                column: "BackEduId",
                principalTable: "BackEdus",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EduStatuses_People_PersonId",
                table: "EduStatuses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpReviews_Companies_CompanyId",
                table: "ExpReviews",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExpReviews_People_PersonId",
                table: "ExpReviews",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_People_Users_UsersId",
                table: "People",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RolesId",
                table: "Users",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkStatuses_BackWorks_BackWorkId",
                table: "WorkStatuses",
                column: "BackWorkId",
                principalTable: "BackWorks",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkStatuses_People_PersonId",
                table: "WorkStatuses",
                column: "PersonId",
                principalTable: "People",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
