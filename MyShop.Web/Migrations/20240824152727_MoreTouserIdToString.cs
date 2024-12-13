using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Web.Migrations
{
    /// <inheritdoc />
    public partial class MoreTouserIdToString : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopingCards_AspNetUsers_MoreToUserId1",
                table: "shopingCards");

            migrationBuilder.DropIndex(
                name: "IX_shopingCards_MoreToUserId1",
                table: "shopingCards");

            migrationBuilder.DropColumn(
                name: "MoreToUserId1",
                table: "shopingCards");

            migrationBuilder.AlterColumn<string>(
                name: "MoreToUserId",
                table: "shopingCards",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_shopingCards_MoreToUserId",
                table: "shopingCards",
                column: "MoreToUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_shopingCards_AspNetUsers_MoreToUserId",
                table: "shopingCards",
                column: "MoreToUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shopingCards_AspNetUsers_MoreToUserId",
                table: "shopingCards");

            migrationBuilder.DropIndex(
                name: "IX_shopingCards_MoreToUserId",
                table: "shopingCards");

            migrationBuilder.AlterColumn<int>(
                name: "MoreToUserId",
                table: "shopingCards",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "MoreToUserId1",
                table: "shopingCards",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_shopingCards_MoreToUserId1",
                table: "shopingCards",
                column: "MoreToUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_shopingCards_AspNetUsers_MoreToUserId1",
                table: "shopingCards",
                column: "MoreToUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
