using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
    public class RefreshTokenResponseDto
    {
        [Required]
        public string RefreshToken { get; set; }
        [Required]
        public string AccessToken { get; set; }
        [Required]
        public DateTime Expires { get; set; }

    }
}
