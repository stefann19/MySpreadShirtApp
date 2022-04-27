using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SpreadShirtShop.Models;

public class Colors
{
    public int Index { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public string Value { get; set; }
    [JsonIgnore]
    public List<Appearance> Appearances { get; set; }
}