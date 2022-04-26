using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class ShippingState
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string IsoCode { get; set; }
    public bool ShippingSupported { get; set; }
    public bool ExternalFullfillmentSupported { get; set; }
}