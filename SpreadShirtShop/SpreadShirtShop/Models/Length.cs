using System.ComponentModel.DataAnnotations;

namespace SpreadShirtShop.Models;

public class Length
{
    [Key]
    public string Unit { get; set; }
    public double UnitFactor { get; set; }
}