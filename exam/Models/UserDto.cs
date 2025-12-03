using System.ComponentModel.DataAnnotations;

namespace UserManagementAPI.Models
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address format.")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Department { get; set; } = string.Empty;
    }

    public class UpdateUserDto : CreateUserDto
    {
        // Inherits validation from CreateUserDto
    }
}