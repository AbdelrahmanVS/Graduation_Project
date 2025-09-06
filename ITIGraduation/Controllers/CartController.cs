using ITIGraduation.Data;
using ITIGraduation.Helper;
using ITIGraduation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITIGraduation.Controllers
{
    public class CartController : Controller
    {
        private const string SessionCartKey = "Cart";
        private readonly SparkContext _dbContext;

        public CartController(SparkContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<CartItem> GetCart()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(SessionCartKey);
            if (cart == null)
            {
                cart = new List<CartItem>();
                HttpContext.Session.SetObjectAsJson(SessionCartKey, cart);
            }
            return cart;
        }
        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetObjectAsJson("Cart", cart);
        }
        public IActionResult Index()
        {
            var cartItems = GetCart();
            var model = new CartViewModel
            {
                Items = cartItems
            };
            return View(model);
        }



        [HttpPost]
        [Authorize]
        public IActionResult AddToCart([FromBody] CartItem CartItem)
        {
            if (CartItem == null || CartItem.ProductId <= 0)
                return BadRequest("Invalid data");

            if (string.IsNullOrEmpty(CartItem.ProductType))
                return BadRequest("Product type required");

            object entity = null;
            string productName = "";
            decimal price = 0;

            // ✅ اختار DbSet على حسب الـ ProductType
            switch (CartItem.ProductType.ToLower())
            {
                case "boot":
                    entity = _dbContext.Boots.FirstOrDefault(p => p.BootId == CartItem.ProductId);
                    break;

                case "product":
                    entity = _dbContext.Prouducts.FirstOrDefault(p => p.ProuductId == CartItem.ProductId);
                    break;

                case "oxford":
                    entity = _dbContext.Oxfords.FirstOrDefault(p => p.OxfordId == CartItem.ProductId);
                    break;

                case "sport":
                    entity = _dbContext.Sports.FirstOrDefault(p => p.SportId == CartItem.ProductId);
                    break;

                // ضيف أي types تانية هنا
                default:
                    return BadRequest("unknown Product Type");
            }

            if (entity == null) return NotFound();

            // ✅ نجيب البيانات (Name + Price) بشكل صريح
            if (entity is Boot boot)
            {
                productName = boot.BootName;
                price = boot.Price ?? 0;
            }
            else if (entity is Prouduct product)
            {
                productName = product.ProuductName;
                price = product.Price ?? 0;
            }
            else if (entity is Sport sport)
            {
                productName = sport.SportName;
                price = sport.Price ?? 0;
            }
            else if (entity is Oxford oxford)
            {
                productName = oxford.BootName;
                price = oxford.Price ?? 0;
            }

            // ✅ أضف للكارت
            var cart = GetCart();
            var cartItem = cart.FirstOrDefault(c =>
                c.ProductId == CartItem.ProductId &&
                c.ProductType.Equals(CartItem.ProductType, StringComparison.OrdinalIgnoreCase));

            if (cartItem != null)
            {
                cartItem.Quantity += CartItem.Quantity; // ياخد الكمية المطلوبة
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = CartItem.ProductId,
                    ProductName = productName,
                    Price = price,
                    Quantity = CartItem.Quantity,
                    ProductType = CartItem.ProductType
                });
            }

            SaveCart(cart);

            // هنا ترجع JSON للـ frontend مش Redirect (عشان الـ fetch بيتوقع JSON)
            return Json(new
            {
                success = true,
                cartCount = cart.Sum(c => c.Quantity)
            });
        }

    }
}
