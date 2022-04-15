using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreadShirtShop.Migrations
{
    public partial class AddedHrefToCurrency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Href",
                table: "Currencies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Href",
                table: "Currencies");
        }
    }
}
