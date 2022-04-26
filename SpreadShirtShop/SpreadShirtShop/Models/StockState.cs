
namespace SpreadShirtShop.Models;

public class StockState
{
    public int Id { get; set; }
    public Appearance? Appearance { get; set; }
    public Size? Size { get; set; }
    public bool Available { get; set; }
    public int Quantity { get; set; }
}