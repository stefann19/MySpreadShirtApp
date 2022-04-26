using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class Category
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }
    public string NameSingular { get; set; }
    public List<ProductType> ProductTypes { get; set; }
}