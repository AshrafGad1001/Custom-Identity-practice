using System.ComponentModel.DataAnnotations;

namespace Custom_Identity_practice.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="UserName Is Required.")]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password Is Required.")]
        public string? Password { get; set; }
        [Display(Name ="Remember Me")]
        public bool RememberMe { get; set; }
    }
}
