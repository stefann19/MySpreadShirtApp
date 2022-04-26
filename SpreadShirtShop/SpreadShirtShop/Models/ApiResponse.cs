namespace SpreadShirtShop.Models;

public class ApiResponse<T>
{
    public string Status { get; set; }
    public string Message { get; set; }
    public T? Value { get; set; }
}