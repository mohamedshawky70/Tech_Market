using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Web.Migrations
{
    /// <inheritdoc />
    public partial class IntToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_AspNetUsers_MoreToUserId1",
                table: "orderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_orderHeaders_MoreToUserId1",
                table: "orderHeaders");

            migrationBuilder.DropColumn(
                name: "MoreToUserId1",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<string>(
                name: "MoreToUserId",
                table: "orderHeaders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_MoreToUserId",
                table: "orderHeaders",
                column: "MoreToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_AspNetUsers_MoreToUserId",
                table: "orderHeaders",
                column: "MoreToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_AspNetUsers_MoreToUserId",
                table: "orderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_orderHeaders_MoreToUserId",
                table: "orderHeaders");

            migrationBuilder.AlterColumn<int>(
                name: "MoreToUserId",
                table: "orderHeaders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "MoreToUserId1",
                table: "orderHeaders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_MoreToUserId1",
                table: "orderHeaders",
                column: "MoreToUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_AspNetUsers_MoreToUserId1",
                table: "orderHeaders",
                column: "MoreToUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
