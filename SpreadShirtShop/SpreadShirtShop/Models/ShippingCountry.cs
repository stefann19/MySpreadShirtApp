using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class ShippingCountry
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? IsoCode { get; set; }
    public bool? ShippingSupported { get; set; }
    public bool? ExternamFullfillmentSupported { get; set; }
    public bool? Customs { get; set; }
    public List<ShippingState> ShippingStates { get; set; }
}