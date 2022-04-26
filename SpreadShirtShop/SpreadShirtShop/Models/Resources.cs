using System.ComponentModel.DataAnnotations;

namespace SpreadShirtShop.Models;

public class Resource
{
    [Key]
    public string Href { get; set; }
    public string MediaType { get; set; }
    public string Type { get; set; }
}