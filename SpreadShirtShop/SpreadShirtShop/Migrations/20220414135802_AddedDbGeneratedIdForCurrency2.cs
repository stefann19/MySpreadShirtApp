using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreadShirtShop.Migrations
{
    public partial class AddedDbGeneratedIdForCurrency2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyPrices_Currencies_CurrencyId1",
                table: "CurrencyPrices");

            migrationBuilder.RenameColumn(
                name: "CurrencyId1",
                table: "CurrencyPrices",
                newName: "CurrencyId");

            migrationBuilder.RenameIndex(
                name: "IX_CurrencyPrices_CurrencyId1",
                table: "CurrencyPrices",
                newName: "IX_CurrencyPrices_CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyPrices_Currencies_CurrencyId",
                table: "CurrencyPrices",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CurrencyPrices_Currencies_CurrencyId",
                table: "CurrencyPrices");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "CurrencyPrices",
                newName: "CurrencyId1");

            migrationBuilder.RenameIndex(
                name: "IX_CurrencyPrices_CurrencyId",
                table: "CurrencyPrices",
                newName: "IX_CurrencyPrices_CurrencyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CurrencyPrices_Currencies_CurrencyId1",
                table: "CurrencyPrices",
                column: "CurrencyId1",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
