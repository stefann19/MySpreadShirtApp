using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class ProductTypeDepartment
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Href { get; set; }
    public string Name { get; set; }
    public string LifeCycleState { get; set; }
    public double Weight { get; set; }
    public List<Category> Categories { get; set; }
}
public class ProductTypeDepartmentList
{
    public int Count { get; set; }
    public int Limit { get; set; }
    public int Offset { get; set; }
    public List<ProductTypeDepartment> ProductTypeDepartments { get; set; }
}