using System.ComponentModel.DataAnnotations;

namespace BikesKart.Models.Login
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
