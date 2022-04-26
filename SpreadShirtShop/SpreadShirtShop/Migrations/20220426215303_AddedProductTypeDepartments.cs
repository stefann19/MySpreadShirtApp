using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreadShirtShop.Migrations
{
    public partial class AddedProductTypeDepartments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductType",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductTypeDepartment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LifeCycleState = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypeDepartment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameSingular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeDepartmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_ProductTypeDepartment_ProductTypeDepartmentId",
                        column: x => x.ProductTypeDepartmentId,
                        principalTable: "ProductTypeDepartment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_CategoryId",
                table: "ProductType",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductTypeDepartmentId",
                table: "Category",
                column: "ProductTypeDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Category_CategoryId",
                table: "ProductType",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Category_CategoryId",
                table: "ProductType");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "ProductTypeDepartment");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_CategoryId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductType");
        }
    }
}
