using System.ComponentModel.DataAnnotations;

namespace BeRme.DTO
{
    public class RegisterDto
    {
        [Required]
        [MaxLength(50)]
        //public string Username { get; set; } = "";
        public string Username { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        [MinLength(8, ErrorMessage = "Username must be at least 5 characters.")]
        //public string Password { get; set; } = "";
        public string Password { get; set; } = string.Empty;

        [Required]
        public string FullName { get; set; } = string.Empty;

        /*[Required]
        [MaxLength(100)]
        public string FullName { get; set; } = "";*/

        [Required]
        [RegularExpression("^(Admin|User)$",
            ErrorMessage = "Role must be Admin or User.")]
        public string Role { get; set; } = string.Empty;

        //public string Role { get; set; } = "User";
    }

    
}