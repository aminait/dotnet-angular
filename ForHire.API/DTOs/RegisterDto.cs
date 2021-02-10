using System.ComponentModel.DataAnnotations;

namespace ForHire.API.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "Password must be between 4 to 8 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}