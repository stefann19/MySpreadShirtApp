using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class Country    
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Href { get; set; }
    public string IsoCode { get; set; }
    public string Name { get; set; }
    public string ThousandsSeparator { get; set; }
    public string DecimalPoint { get; set; }

    public Currency Currency { get; set; }
    public string CurrencyPattern { get; set; }
    public Language DefaultLanguage { get; set; }
    public double DefaultVatRate { get; set; }
    public Length Length { get; set; }
}

public class CountriesList
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Count { get; set; }
    public List<Country> Countries { get; set; }
}