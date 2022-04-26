using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace SpreadShirtShop.Models;

public class Appearance
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public List<Colors> Colors { get; set; }
    public List<PrintType> PrintTypes { get; set; }

    //public List<Resource> Resources { get; set; }
}