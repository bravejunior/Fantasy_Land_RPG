using System.ComponentModel.DataAnnotations;

namespace Fantasy_Land_Web_Api.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage = "Username can't be empty.")]
        [StringLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can't be empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
