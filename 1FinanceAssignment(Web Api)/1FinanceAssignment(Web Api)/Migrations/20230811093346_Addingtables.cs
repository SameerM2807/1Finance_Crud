using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _1FinanceAssignment_Web_Api_.Migrations
{
    public partial class Addingtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    quantity = table.Column<int>(type: "int", nullable: false),
                    price = table.Column<double>(type: "float", nullable: false),
                    CatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_products_categories_CatId",
                        column: x => x.CatId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Category_name", "description" },
                values: new object[] { 1, "Electronics", "Product 1 Description" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Category_name", "description" },
                values: new object[] { 2, "Clothes", "Product 2 Description" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Category_name", "description" },
                values: new object[] { 3, "HomeDeCore", "Product 3 Description" });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CatId", "ProductName", "price", "quantity" },
                values: new object[] { 1, 1, "IPhone14", 0.0, 10 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CatId", "ProductName", "price", "quantity" },
                values: new object[] { 2, 1, "IPhone13", 0.0, 20 });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "ProductId", "CatId", "ProductName", "price", "quantity" },
                values: new object[] { 3, 1, "IPhone12", 0.0, 30 });

            migrationBuilder.CreateIndex(
                name: "IX_products_CatId",
                table: "products",
                column: "CatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
