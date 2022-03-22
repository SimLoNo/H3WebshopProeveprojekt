using Microsoft.EntityFrameworkCore.Migrations;

namespace H3WebshopProeveprojekt.Api.Migrations
{
    public partial class addedproductImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Product",
                type: "nvarchar(30)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountRole",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Account_AccountRoleId",
                table: "Account",
                column: "AccountRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AccountRole_AccountRoleId",
                table: "Account",
                column: "AccountRoleId",
                principalTable: "AccountRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AccountRole_AccountRoleId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_AccountRoleId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AccountRole",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);
        }
    }
}
