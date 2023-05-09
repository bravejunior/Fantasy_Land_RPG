using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Models.DTOs
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Make sure you've entered your first name.")]
        [StringLength(20, ErrorMessage = "First names may only contain a maximum of 20 characters.")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names may only contain the characters a-z.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Make sure you've entered your last name.")]
        [StringLength(20, ErrorMessage = "Last names may only contain a maximum of 20 characters")]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Names may only contain the characters a-z.")]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; }

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
