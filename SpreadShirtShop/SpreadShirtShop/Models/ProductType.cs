using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpreadShirtShop.Models;

public class ProductType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Href { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ShortDescription { get; set; }
    public string CategoryName { get; set; }
    public double Weight { get; set; }
    public string Brand { get; set; }
    public double ShippingFactor { get; set; }
    public string SizeFitHint { get; set; }
    public string CustomsTariffCode { get; set; }
    public ShippingCountry ManufacturingCountry { get; set; }
    public ProductTypePrice Price { get; set; }
    public List<Appearance> Appearances { get; set; }
    public List<Size> Sizes { get; set; }
    public List<WashingInstruction> WashingInstructions { get; set; }
    public List<StockState> StockStates { get; set; }
    public bool GiftWrappingSupported { get; set; }
    [JsonIgnore]
    public List<Sellable> Sellables { get; set; }
}

public class ProductTypesList
{
    public int Count { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public List<ProductType> ProductTypes { get; set; }
}

