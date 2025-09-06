using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace ITIGraduation.Models
{
    // Auth
    public class PaymobAuthRequest
    {
        [JsonProperty("api_key")]
        public string ApiKey { get; set; } = "";
    }

    public class PaymobAuthResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; } = "";
    }

    // Order
    public class PaymobOrderRequest
    {
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; } = "";
        [JsonProperty("amount_cents")]
        public int AmountCents { get; set; }
        [JsonProperty("currency")]
        public string Currency { get; set; } = "EGP";
        [JsonProperty("items")]
        public List<object> Items { get; set; } = new();
    }

    public class PaymobOrderResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }

    // Payment Key
    public class PaymobPaymentKeyRequest
    {
        [JsonProperty("auth_token")]
        public string AuthToken { get; set; } = "";
        [JsonProperty("amount_cents")]
        public int AmountCents { get; set; }
        [JsonProperty("order_id")]
        public int OrderId { get; set; }
        [JsonProperty("integration_id")]
        public int IntegrationId { get; set; }
        [JsonProperty("billing_data")]
        public object BillingData { get; set; } = new {};
        [JsonProperty("currency")]
        public string Currency { get; set; } = "EGP";
    }

    public class PaymobPaymentKeyResponse
    {
        [JsonProperty("token")]
        public string Token { get; set; } = "";
    }

    // Callback (minimal)
    public class PaymobCallback
    {
        [JsonProperty("obj")]
        public PaymobTransaction Transaction { get; set; } = new();
    }

    public class PaymobTransaction
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("amount_cents")]
        public int AmountCents { get; set; }
    }

    // View Models
    public class PaymentViewModel
    {
        [Required]
        [Range(1, 10000)]
        public decimal Amount { get; set; }

        [Required]
        public string CustomerName { get; set; } = "";

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; } = "";

        [Required]
        public string CustomerPhone { get; set; } = "";

        public string? Description { get; set; }
    }

    public class PaymentResultViewModel
    {
        public bool Success { get; set; }
        public string PaymentUrl { get; set; } = "";
        public string ErrorMessage { get; set; } = "";
    }
}