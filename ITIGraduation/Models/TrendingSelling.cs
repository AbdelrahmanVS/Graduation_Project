using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITIGraduation.Models
{
    public class TrendingSelling
    {
        [Key]
        public int ProudId { get; set; }

        public string? ProudName { get; set; }
        public int? Size { get; set; }
        public decimal? Price { get; set; }
        public string? ImagUrl { get; set; }
        public string? Imag2 { get; set; }
        public string? Imag3 { get; set; }
        public string? Imag4 { get; set; }

        // روابط للمنتجات
        [NotMapped]
        public string? CategoryType { get; set; } = "";   // Boot / Oxford / Sport
        [NotMapped]

        public int? CategoryProductId { get; set; }
    }
}
