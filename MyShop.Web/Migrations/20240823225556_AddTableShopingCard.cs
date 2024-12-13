using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShop.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddTableShopingCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "shopingCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Counter = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    MoreToUserId = table.Column<int>(type: "int", nullable: false),
                    MoreToUserId1 = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shopingCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shopingCards_AspNetUsers_MoreToUserId1",
                        column: x => x.MoreToUserId1,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_shopingCards_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_shopingCards_MoreToUserId1",
                table: "shopingCards",
                column: "MoreToUserId1");

            migrationBuilder.CreateIndex(
                name: "IX_shopingCards_ProductId",
                table: "shopingCards",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "shopingCards");
        }
    }
}
