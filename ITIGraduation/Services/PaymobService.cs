using Newtonsoft.Json;
using ITIGraduation.Models;
using System.Text;

namespace ITIGraduation.Services
{
    public interface IPaymobService
    {
        Task<PaymentResultViewModel> CreatePaymentAsync(PaymentViewModel request);
        Task ProcessCallbackAsync(PaymobCallback callback);
    }

    public class PaymobService : IPaymobService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public PaymobService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;
        }

        public async Task<PaymentResultViewModel> CreatePaymentAsync(PaymentViewModel request)
        {
            try
            {
                // Get token
                var token = await GetTokenAsync();
                if (token == "") return new() { Success = false, ErrorMessage = "Auth failed" };

                // Create order
                var orderId = await CreateOrderAsync(token, request.Amount);
                if (orderId == 0) return new() { Success = false, ErrorMessage = "Order failed" };

                // Get payment key
                var paymentKey = await GetPaymentKeyAsync(token, orderId, request);
                if (paymentKey == "") return new() { Success = false, ErrorMessage = "Key failed" };

                // Build URL
                var iframeId = _config["Paymob:IframeId"];
                var url = $"https://accept.paymob.com/api/acceptance/iframes/{iframeId}?payment_token={paymentKey}";

                return new() { Success = true, PaymentUrl = url };
            }
            catch
            {
                return new() { Success = false, ErrorMessage = "Error" };
            }
        }

        public Task ProcessCallbackAsync(PaymobCallback callback)
        {
            return Task.CompletedTask;
        }

        private async Task<string> GetTokenAsync()
        {
            try
            {
                var request = new { api_key = _config["Paymob:ApiKey"] };
                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _http.PostAsync("https://accept.paymob.com/api/auth/tokens", content);
                var result = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {
                    var auth = JsonConvert.DeserializeObject<PaymobAuthResponse>(result);
                    return auth?.Token ?? "";
                }
                return "";
            }
            catch { return ""; }
        }

        private async Task<int> CreateOrderAsync(string token, decimal amount)
        {
            try
            {
                var request = new
                {
                    auth_token = token,
                    amount_cents = (int)(amount * 100),
                    currency = "EGP",
                    items = new[] { new { name = "Payment", amount_cents = (int)(amount * 100), quantity = 1 } }
                };

                var json = JsonConvert.SerializeObject(request);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _http.PostAsync("https://accept.paymob.com/api/ecommerce/orders", content);
                var result = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {
                    var order = JsonConvert.DeserializeObject<PaymobOrderResponse>(result);
                    return order?.Id ?? 0;
                }
                return 0;
            }
            catch { return 0; }
        }

        private async Task<string> GetPaymentKeyAsync(string token, int orderId, PaymentViewModel request)
        {
            try
            {
                var names = request.CustomerName.Split(' ');
                var billing = new
                {
                    email = request.CustomerEmail,
                    first_name = names[0],
                    last_name = names.Length > 1 ? names[1] : "",
                    phone_number = request.CustomerPhone,
                    apartment = "NA", floor = "NA", street = "NA", building = "NA",
                    city = "NA", country = "EG", state = "NA"
                };

                var paymentRequest = new
                {
                    auth_token = token,
                    amount_cents = (int)(request.Amount * 100),
                    order_id = orderId,
                    integration_id = int.Parse(_config["Paymob:IntegrationId"] ?? "0"),
                    billing_data = billing,
                    currency = "EGP"
                };

                var json = JsonConvert.SerializeObject(paymentRequest);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                
                var response = await _http.PostAsync("https://accept.paymob.com/api/acceptance/payment_keys", content);
                var result = await response.Content.ReadAsStringAsync();
                
                if (response.IsSuccessStatusCode)
                {
                    var key = JsonConvert.DeserializeObject<PaymobPaymentKeyResponse>(result);
                    return key?.Token ?? "";
                }
                // Log the error response for debugging
                System.Diagnostics.Debug.WriteLine($"Paymob payment key error: {result}");
                return "";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Exception in GetPaymentKeyAsync: {ex.Message}");
                return "";
            }
        }
    }
}