using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class Currency
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Plain { get; set; }
    public string IsoCode { get; set; }
    public string Symbol { get; set; }
    public double DecimalCount { get; set; }
    public string Pattern { get; set; }
    public string Href { get; set; }
}


public class CurrencyList
{
    public List<Currency> Currencies { get; set; }
}