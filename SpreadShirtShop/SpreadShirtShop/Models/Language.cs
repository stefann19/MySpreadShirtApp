using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class Language
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Href { get; set; }
    public string IsoCode { get; set; }
    public string Name { get; set; }
}

public class LanguageList
{
    public int Offset { get; set; }
    public int Limit { get; set; }
    public int Count { get; set; }
    public List<Language> Languages { get; set; }
}