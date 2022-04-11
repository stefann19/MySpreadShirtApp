using System.ComponentModel.DataAnnotations.Schema;

namespace SpreadShirtShop.Models;

public class User
{
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(255)")]
    public string Email { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string Password { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string? AccountStatus { get; set; }
    [Column(TypeName = "nvarchar(255)")]
    public string? VerificationCode { get; set; }
}