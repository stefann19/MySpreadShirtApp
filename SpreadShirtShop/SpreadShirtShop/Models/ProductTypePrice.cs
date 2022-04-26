namespace SpreadShirtShop.Models;

public class ProductTypePrice
{
    public int Id { get; set; }
    public double VatExcluded { get; set; }
    public double VatIncluded { get; set; }
    public double Vat { get; set; }
    public Currency Currency { get; set; }
}