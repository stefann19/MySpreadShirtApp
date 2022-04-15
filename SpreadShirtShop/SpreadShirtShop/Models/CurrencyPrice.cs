using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SpreadShirtShop.Models;

public class CurrencyPrice
{
    public int Id { get; set; }
    public Currency Currency { get; set; }
    public double Amount { get; set; }

    [JsonProperty("CurrencyId")]
    [NotMapped]
    public int CurrencyIdRaw { get; set; }
}
