using Microsoft.AspNetCore.Mvc;
using ITIGraduation.Models;
using ITIGraduation.Services;
using Newtonsoft.Json;
using System.Text;

namespace ITIGraduation.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymobService _paymobService;

        public PaymentController(IPaymobService paymobService)
        {
            _paymobService = paymobService;
        }

        [HttpGet]
        public IActionResult Index(decimal? amount, string? name, int? quantity)
        {
            // Pre-fill the payment form if query params exist
            var model = new PaymentViewModel();
            if (amount.HasValue)
                model.Amount = amount.Value;
            if (!string.IsNullOrEmpty(name))
                model.Description = $"Product: {name} Quantity: {quantity}";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(PaymentViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var result = await _paymobService.CreatePaymentAsync(model);
            
            if (result.Success)
                return Redirect(result.PaymentUrl);

            ModelState.AddModelError("", result.ErrorMessage);
            return View("Index", model);
        }

        [HttpGet]
        public IActionResult Success() => View();

        [HttpGet]
        public IActionResult Cancel() => View();

        [HttpPost("api/paymob/callback")]
        public async Task<IActionResult> Callback()
        {
            try
            {
                using var reader = new StreamReader(Request.Body, Encoding.UTF8);
                var data = await reader.ReadToEndAsync();

                if (string.IsNullOrEmpty(data))
                    return BadRequest();

                var callback = JsonConvert.DeserializeObject<PaymobCallback>(data);
                if (callback?.Transaction == null)
                    return BadRequest();

                await _paymobService.ProcessCallbackAsync(callback);
                return Ok();
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}