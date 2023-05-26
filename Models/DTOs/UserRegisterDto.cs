using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models.DTOs
{
    public class UserRegisterDto
    {
        [Required(ErrorMessage = "You're required to enter a username.")]
        [StringLength(20)]
        public string Username { get; set; }

        public bool IsPrivate { get; set; } = false;

        public bool RememberMe { get; set; } = true;

        [Required(ErrorMessage = "Enter a password.")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "Password must be between 8 and 25 characters.")]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*[0-9])[A-Za-z[0-9]{8,}$", ErrorMessage = "Password needs to be at least eight characters and contain at least one digit.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "You have to confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
