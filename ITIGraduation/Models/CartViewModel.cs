namespace ITIGraduation.Models
{
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; }
        public decimal Total => (decimal)Items.Sum(i => i.ProductId * i.Quantity);
    }
}
