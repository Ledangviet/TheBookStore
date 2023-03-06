using System.ComponentModel.DataAnnotations;

namespace TheBookStore.Models.Authentication
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is required!"), EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        public string Password { get; set; }
        [Required(ErrorMessage = "ConfirmPassword is required!")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }

    }

}
