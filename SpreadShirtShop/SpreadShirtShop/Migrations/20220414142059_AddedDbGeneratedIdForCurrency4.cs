using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreadShirtShop.Migrations
{
    public partial class AddedDbGeneratedIdForCurrency4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpreadShirtOldId",
                table: "Currencies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SpreadShirtOldId",
                table: "Currencies");
        }
    }
}
