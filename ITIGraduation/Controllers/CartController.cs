using ITIGraduation.Data;
using ITIGraduation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ITIGraduation.Controllers
{
    [Authorize] // كل الأكشنز تتطلب تسجيل الدخول
    public class CartController : Controller
    {
        private readonly SparkContext _dbContext;

        public CartController(SparkContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: /Cart
        public async Task<IActionResult> Index()
        {
            var userId = User.Identity.Name;
            var cartItems = await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .ToListAsync();

            var model = new CartViewModel
            {
                Items = cartItems.Select(c => new CartItem
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    ProductType = c.ProductType,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            return View(model);
        }

        public async Task<IActionResult> Checkout()
        {
            var userId = User.Identity.Name;
            var cartItems = await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .ToListAsync();

            var model = new CartViewModel
            {
                Items = cartItems.Select(c => new CartItem
                {
                    ProductId = c.ProductId,
                    ProductName = c.ProductName,
                    ProductType = c.ProductType,
                    Quantity = c.Quantity,
                    Price = c.Price
                }).ToList()
            };

            return View(model);
        }


        // POST: /Cart/AddToCart
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartItem cartItem)
        {
            if (cartItem == null || cartItem.ProductId <= 0)
                return BadRequest("Invalid data");

            if (string.IsNullOrEmpty(cartItem.ProductType))
                return BadRequest("Product type required");

            string productName = "";
            decimal price = 0;

            // جلب المنتج حسب النوع
            switch (cartItem.ProductType.ToLower())
            {
                case "boot":
                    var boot = await _dbContext.Boots.FindAsync(cartItem.ProductId);
                    if (boot == null) return NotFound();
                    productName = boot.BootName;
                    price = boot.Price ?? 0;
                    break;

                case "product":
                    var product = await _dbContext.Prouducts.FindAsync(cartItem.ProductId);
                    if (product == null) return NotFound();
                    productName = product.ProuductName;
                    price = product.Price ?? 0;
                    break;

                case "oxford":
                    var oxford = await _dbContext.Oxfords.FindAsync(cartItem.ProductId);
                    if (oxford == null) return NotFound();
                    productName = oxford.BootName;
                    price = oxford.Price ?? 0;
                    break;


                case "trending":
                    var trending = await _dbContext.TrendingSellings.FindAsync(cartItem.ProductId);
                    if (trending == null) return NotFound();
                    productName = trending.ProudName;
                    price = trending.Price ?? 0;
                    break;

                case "sport":
                    var sport = await _dbContext.Sports.FindAsync(cartItem.ProductId);
                    if (sport == null) return NotFound();
                    productName = sport.SportName;
                    price = sport.Price ?? 0;
                    break;

                default:
                    return BadRequest("Unknown Product Type");
            }

            var userId = User.Identity.Name;

            // تحقق إذا المنتج موجود في السلة مسبقًا
            var existingItem = await _dbContext.CartItems
                .FirstOrDefaultAsync(c =>
                    c.ProductId == cartItem.ProductId &&
                    c.ProductType.ToLower() == cartItem.ProductType.ToLower() &&
                    c.UserId == userId);

            if (existingItem != null)
            {
                existingItem.Quantity += cartItem.Quantity;
                _dbContext.CartItems.Update(existingItem);
            }
            else
            {
                var newItem = new CartItemEntity
                {
                    ProductId = cartItem.ProductId,
                    ProductName = productName,
                    Price = price,
                    Quantity = cartItem.Quantity,
                    ProductType = cartItem.ProductType,
                    UserId = userId
                };
                await _dbContext.CartItems.AddAsync(newItem);
            }

            await _dbContext.SaveChangesAsync();

            var cartCount = await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .SumAsync(c => c.Quantity);

            var totalItems = await _dbContext.CartItems
    .Where(c => c.UserId == userId)
    .SumAsync(c => c.Quantity);


            return Json(new { success = true, cartCount,totalItems });
        }

        // POST: /Cart/UpdateQuantity
        [HttpPost]
        public async Task<IActionResult> UpdateQuantity([FromBody] CartItem cartItem)
        {
            if (cartItem == null || cartItem.ProductId <= 0) return BadRequest();

            var userId = User.Identity.Name;
            var item = await _dbContext.CartItems.FirstOrDefaultAsync(c =>
                c.ProductId == cartItem.ProductId &&
                c.ProductType.ToLower() == cartItem.ProductType.ToLower() &&
                c.UserId == userId);

            if (item == null) return NotFound();

            item.Quantity = cartItem.Quantity > 0 ? cartItem.Quantity : 1;

            _dbContext.CartItems.Update(item);
            await _dbContext.SaveChangesAsync();

            // ارجع السعر الفردي والعدد الإجمالي
            var cartTotal = await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .SumAsync(c => c.Price * c.Quantity);

            var totalItems = await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .SumAsync(c => c.Quantity);

            return Json(new
            {
                success = true,
                itemPrice = item.Price,
                quantity = item.Quantity,
                cartTotal,
                totalItems
            });
        }

        // POST: /Cart/Remove
        [HttpPost]
        [HttpPost]
        public async Task<IActionResult> Remove([FromBody] CartItem cartItem)
        {
            if (cartItem == null || cartItem.ProductId <= 0) return BadRequest();

            var userId = User.Identity.Name;
            var item = await _dbContext.CartItems.FirstOrDefaultAsync(c =>
                c.ProductId == cartItem.ProductId &&
                c.ProductType.ToLower() == cartItem.ProductType.ToLower() &&
                c.UserId == userId);

            if (item == null) return NotFound();

            _dbContext.CartItems.Remove(item);
            await _dbContext.SaveChangesAsync();

            var cartTotal = await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .SumAsync(c => c.Price * c.Quantity);

            var totalItems = await _dbContext.CartItems
                .Where(c => c.UserId == userId)
                .SumAsync(c => c.Quantity);

            return Json(new { success = true, cartTotal, totalItems });
        }

    }
}
