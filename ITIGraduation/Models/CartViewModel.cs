namespace ITIGraduation.Models
{
    public class CartViewModel
    {
        public List<CartItem> Items { get; set; }
        public decimal Total => Items.Sum(i => i.Price * i.Quantity);

    }
}
