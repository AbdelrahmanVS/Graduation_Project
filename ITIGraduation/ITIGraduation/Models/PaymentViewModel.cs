using System.ComponentModel.DataAnnotations;

namespace ITIGraduation.Models
{
    public class PaymentViewModel {
        [Required]
        [Range(1, 10000)]
        public decimal Amount { get; set; }

        [Required]
        [RegularExpression(@"^\s*\S+\s+\S+.*$", ErrorMessage = "Please enter both first and last name.")]
        public string CustomerName { get; set; }

        [Required]
        [EmailAddress]
        public string CustomerEmail { get; set; }

        [Required]
        public string CustomerPhone { get; set; }
        public string? Description { get; set; }
    }
}