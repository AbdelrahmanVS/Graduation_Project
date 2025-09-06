using System.ComponentModel.DataAnnotations;

namespace ITIGraduation.Models;

public class CartItemEntity
{
    [Key]
    public int Id { get; set; }

    public int ProductId { get; set; }

    public string ProductName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public string ProductType { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty; // عشان نعرف مين صاحب السلة
}
