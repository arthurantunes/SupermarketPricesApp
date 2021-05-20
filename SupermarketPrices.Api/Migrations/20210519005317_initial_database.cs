using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace SupermarketPrices.Api.Migrations
{
    public partial class initial_database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Description = table.Column<string>(type: "text", maxLength: 120, nullable: true),
                    EAN = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    SKU = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true),
                    Brand = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supermarket",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supermarket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupermarketProduct",
                columns: table => new
                {
                    SupermarketId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", maxLength: 120, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupermarketProduct", x => new { x.SupermarketId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_SupermarketProduct_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupermarketProduct_Supermarket_SupermarketId",
                        column: x => x.SupermarketId,
                        principalTable: "Supermarket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SupermarketProduct_ProductId",
                table: "SupermarketProduct",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SupermarketProduct");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Supermarket");
        }
    }
}
