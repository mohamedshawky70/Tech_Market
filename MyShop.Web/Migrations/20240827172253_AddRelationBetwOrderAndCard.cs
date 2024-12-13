using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddRelationBetwOrderAndCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ShopingCardId",
                table: "orderHeaders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_orderHeaders_ShopingCardId",
                table: "orderHeaders",
                column: "ShopingCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_orderHeaders_shopingCards_ShopingCardId",
                table: "orderHeaders",
                column: "ShopingCardId",
                principalTable: "shopingCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderHeaders_shopingCards_ShopingCardId",
                table: "orderHeaders");

            migrationBuilder.DropIndex(
                name: "IX_orderHeaders_ShopingCardId",
                table: "orderHeaders");

            migrationBuilder.DropColumn(
                name: "ShopingCardId",
                table: "orderHeaders");
        }
    }
}
