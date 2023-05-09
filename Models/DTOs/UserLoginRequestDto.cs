using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Models.DTOs
{
    public class UserLoginRequestDto
    {
        [Required(ErrorMessage = "Username can't be empty.")]
        [StringLength(20)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password can't be empty.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [BindNever]
        public string RemoteIpAddress { get; set; }
    }
}
