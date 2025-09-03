using System.ComponentModel.DataAnnotations;

namespace ITIGraduation.ViewModels;

    public class LoginVM
    {
        [Required(ErrorMessage ="Username is required")]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }

