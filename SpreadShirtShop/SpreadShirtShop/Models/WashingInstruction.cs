using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class WashingInstruction
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Logo { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Type { get; set; }
}