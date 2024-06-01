using System.ComponentModel.DataAnnotations;

namespace Tattoo.DTOs
{
    public class RegisterRequest
    {
        [Required] public string Username { get; set; } = null!;
        [Required] public string Password { get; set; } = null!;
        [Required] public string Email { get; set; } = null!;
    }
}
