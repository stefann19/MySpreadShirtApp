using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpreadShirtShop.Migrations
{
    public partial class AddedNullableSizeInStockState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Value = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Value);
                });

            migrationBuilder.CreateTable(
                name: "Currency",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Plain = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecimalCount = table.Column<double>(type: "float", nullable: false),
                    Pattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currency", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImageModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Length",
                columns: table => new
                {
                    Unit = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UnitFactor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Length", x => x.Unit);
                });

            migrationBuilder.CreateTable(
                name: "MeasureValue",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasureValue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrintType",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrintType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    Href = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.Href);
                });

            migrationBuilder.CreateTable(
                name: "ShippingCountry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingSupported = table.Column<bool>(type: "bit", nullable: true),
                    ExternamFullfillmentSupported = table.Column<bool>(type: "bit", nullable: true),
                    Customs = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingCountry", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", nullable: false),
                    AccountStatus = table.Column<string>(type: "nvarchar(255)", nullable: true),
                    VerificationCode = table.Column<string>(type: "nvarchar(255)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyPrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyPrice_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTypePrice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VatExcluded = table.Column<double>(type: "float", nullable: false),
                    VatIncluded = table.Column<double>(type: "float", nullable: false),
                    Vat = table.Column<double>(type: "float", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypePrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTypePrice_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThousandsSeparator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DecimalPoint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CurrencyPattern = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DefaultLanguageId = table.Column<int>(type: "int", nullable: false),
                    DefaultVatRate = table.Column<double>(type: "float", nullable: false),
                    LengthUnit = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Country_Currency_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currency",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Country_Language_DefaultLanguageId",
                        column: x => x.DefaultLanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Country_Length_LengthUnit",
                        column: x => x.LengthUnit,
                        principalTable: "Length",
                        principalColumn: "Unit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Measure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ValueId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measure", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Measure_MeasureValue_ValueId",
                        column: x => x.ValueId,
                        principalTable: "MeasureValue",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsoCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingSupported = table.Column<bool>(type: "bit", nullable: false),
                    ExternalFullfillmentSupported = table.Column<bool>(type: "bit", nullable: false),
                    ShippingCountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingState_ShippingCountry_ShippingCountryId",
                        column: x => x.ShippingCountryId,
                        principalTable: "ShippingCountry",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Href = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingFactor = table.Column<double>(type: "float", nullable: false),
                    SizeFitHint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomsTariffCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturingCountryId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    GiftWrappingSupported = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductType_ProductTypePrice_PriceId",
                        column: x => x.PriceId,
                        principalTable: "ProductTypePrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductType_ShippingCountry_ManufacturingCountryId",
                        column: x => x.ManufacturingCountryId,
                        principalTable: "ShippingCountry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sellable",
                columns: table => new
                {
                    SellableId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdeaId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainDesignId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false),
                    PreviewImageId = table.Column<int>(type: "int", nullable: false),
                    DefaultAppearanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sellable", x => x.SellableId);
                    table.ForeignKey(
                        name: "FK_Sellable_CurrencyPrice_PriceId",
                        column: x => x.PriceId,
                        principalTable: "CurrencyPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellable_ImageModel_PreviewImageId",
                        column: x => x.PreviewImageId,
                        principalTable: "ImageModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sellable_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Size",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Size", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Size_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WashingInstruction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WashingInstruction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WashingInstruction_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Appearance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true),
                    SellableId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appearance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appearance_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Appearance_Sellable_SellableId",
                        column: x => x.SellableId,
                        principalTable: "Sellable",
                        principalColumn: "SellableId");
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SellableId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_Sellable_SellableId",
                        column: x => x.SellableId,
                        principalTable: "Sellable",
                        principalColumn: "SellableId");
                });

            migrationBuilder.CreateTable(
                name: "AppearanceColors (Dictionary<string, object>)",
                columns: table => new
                {
                    AppearancesId = table.Column<int>(type: "int", nullable: false),
                    ColorsValue = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppearanceColors (Dictionary<string, object>)", x => new { x.AppearancesId, x.ColorsValue });
                    table.ForeignKey(
                        name: "FK_AppearanceColors (Dictionary<string, object>)_Appearance_AppearancesId",
                        column: x => x.AppearancesId,
                        principalTable: "Appearance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppearanceColors (Dictionary<string, object>)_Colors_ColorsValue",
                        column: x => x.ColorsValue,
                        principalTable: "Colors",
                        principalColumn: "Value",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AppearancePrintType (Dictionary<string, object>)",
                columns: table => new
                {
                    AppearancesId = table.Column<int>(type: "int", nullable: false),
                    PrintTypesId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppearancePrintType (Dictionary<string, object>)", x => new { x.AppearancesId, x.PrintTypesId });
                    table.ForeignKey(
                        name: "FK_AppearancePrintType (Dictionary<string, object>)_Appearance_AppearancesId",
                        column: x => x.AppearancesId,
                        principalTable: "Appearance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AppearancePrintType (Dictionary<string, object>)_PrintType_PrintTypesId",
                        column: x => x.PrintTypesId,
                        principalTable: "PrintType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockState",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppearanceId = table.Column<int>(type: "int", nullable: true),
                    SizeId = table.Column<int>(type: "int", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ProductTypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockState", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockState_Appearance_AppearanceId",
                        column: x => x.AppearanceId,
                        principalTable: "Appearance",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockState_ProductType_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StockState_Size_SizeId",
                        column: x => x.SizeId,
                        principalTable: "Size",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appearance_ProductTypeId",
                table: "Appearance",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Appearance_SellableId",
                table: "Appearance",
                column: "SellableId");

            migrationBuilder.CreateIndex(
                name: "IX_AppearanceColors (Dictionary<string, object>)_ColorsValue",
                table: "AppearanceColors (Dictionary<string, object>)",
                column: "ColorsValue");

            migrationBuilder.CreateIndex(
                name: "IX_AppearancePrintType (Dictionary<string, object>)_PrintTypesId",
                table: "AppearancePrintType (Dictionary<string, object>)",
                column: "PrintTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_CurrencyId",
                table: "Country",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_DefaultLanguageId",
                table: "Country",
                column: "DefaultLanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_Country_LengthUnit",
                table: "Country",
                column: "LengthUnit");

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyPrice_CurrencyId",
                table: "CurrencyPrice",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Measure_ValueId",
                table: "Measure",
                column: "ValueId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ManufacturingCountryId",
                table: "ProductType",
                column: "ManufacturingCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_PriceId",
                table: "ProductType",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypePrice_CurrencyId",
                table: "ProductTypePrice",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellable_PreviewImageId",
                table: "Sellable",
                column: "PreviewImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellable_PriceId",
                table: "Sellable",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Sellable_ProductTypeId",
                table: "Sellable",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingState_ShippingCountryId",
                table: "ShippingState",
                column: "ShippingCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Size_ProductTypeId",
                table: "Size",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockState_AppearanceId",
                table: "StockState",
                column: "AppearanceId");

            migrationBuilder.CreateIndex(
                name: "IX_StockState_ProductTypeId",
                table: "StockState",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StockState_SizeId",
                table: "StockState",
                column: "SizeId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_SellableId",
                table: "Tag",
                column: "SellableId");

            migrationBuilder.CreateIndex(
                name: "IX_WashingInstruction_ProductTypeId",
                table: "WashingInstruction",
                column: "ProductTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppearanceColors (Dictionary<string, object>)");

            migrationBuilder.DropTable(
                name: "AppearancePrintType (Dictionary<string, object>)");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "Measure");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "ShippingState");

            migrationBuilder.DropTable(
                name: "StockState");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WashingInstruction");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "PrintType");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Length");

            migrationBuilder.DropTable(
                name: "MeasureValue");

            migrationBuilder.DropTable(
                name: "Appearance");

            migrationBuilder.DropTable(
                name: "Size");

            migrationBuilder.DropTable(
                name: "Sellable");

            migrationBuilder.DropTable(
                name: "CurrencyPrice");

            migrationBuilder.DropTable(
                name: "ImageModel");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "ProductTypePrice");

            migrationBuilder.DropTable(
                name: "ShippingCountry");

            migrationBuilder.DropTable(
                name: "Currency");
        }
    }
}
