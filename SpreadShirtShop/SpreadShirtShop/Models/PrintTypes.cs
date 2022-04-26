using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class PrintType
{
    public string Href { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public string Id { get; set; }

    public List<Appearance> Appearances { get; set; }
}