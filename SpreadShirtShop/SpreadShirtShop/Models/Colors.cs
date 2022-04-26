using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class Colors
{
    public int Index { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public string Value { get; set; }

    public List<Appearance> Appearances { get; set; }
}