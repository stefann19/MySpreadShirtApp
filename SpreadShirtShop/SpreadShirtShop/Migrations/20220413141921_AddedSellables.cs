using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreadShirtShop.Migrations
{
    public partial class AddedSellables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Plain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecimalCount = table.Column<double>(type: "float", nullable: false),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyPrices_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellables",
                columns: table => new
                {
                    SellableId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdeaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainDesignId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    PreviewImageId = table.Column<int>(type: "int", nullable: false),
                    DefaultAppearanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellables", x => x.SellableId);
                    table.ForeignKey(
                        name: "FK_Sellables_CurrencyPrices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "CurrencyPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellables_ImageModels_PreviewImageId",
                        column: x => x.PreviewImageId,
                        principalTable: "ImageModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appearances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellableId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appearances_Sellables_SellableId",
                        column: x => x.SellableId,
                        principalTable: "Sellables",
                        principalColumn: "SellableId");
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellableId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Sellables_SellableId",
                        column: x => x.SellableId,
                        principalTable: "Sellables",
                        principalColumn: "SellableId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appearances_SellableId",
                table: "Appearances",
                column: "SellableId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyPrices_CurrencyId",
                table: "CurrencyPrices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellables_PreviewImageId",
                table: "Sellables",
                column: "PreviewImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellables_PriceId",
                table: "Sellables",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_SellableId",
                table: "Tags",
                column: "SellableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appearances");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Sellables");

            migrationBuilder.DropTable(
                name: "CurrencyPrices");

            migrationBuilder.DropTable(
                name: "ImageModels");

            migrationBuilder.DropTable(
                name: "Currencies");
        }
    }
}
