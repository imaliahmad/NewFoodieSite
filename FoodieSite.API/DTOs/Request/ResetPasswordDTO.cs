using System.ComponentModel.DataAnnotations;

namespace FoodieSite.API.DTOs.Request
{
    public class ResetPasswordDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string NewPassword { get; set; }

        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string PasswordResetToken { get; set; }
    }
}
