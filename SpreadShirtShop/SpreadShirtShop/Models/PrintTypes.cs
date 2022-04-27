using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpreadShirtShop.Models;

public class PrintType
{
    public string Href { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public string Id { get; set; }
    [JsonIgnore]
    public List<Appearance> Appearances { get; set; }
}