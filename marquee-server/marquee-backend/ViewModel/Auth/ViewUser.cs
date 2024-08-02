using marquee_backend.Regex;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marquee_backend.ViewModel.Auth
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("id")]
        [SwaggerSchema(ReadOnly = true)]
        public Guid id { get; set; }

        [Column("username")]
        [RegularExpression(RegexPatterns.UsernameRegex, ErrorMessage = "Username may only contain lowercase letters a-z and numbers 1-9.")]
        public required string Username { get; set; }

        [Column("password_hash")]
        [Required(ErrorMessage = "Password is required")]
        public required string PasswordHash { get; set; }

        [Column("name")]
        [RegularExpression(RegexPatterns.UsernameRegex, ErrorMessage = "Username may only contain first and last names.")]
        public required string Name { get; set; }

        [Column("email")]
        [RegularExpression(RegexPatterns.EmailRegex, ErrorMessage = "Email is in the wrong format.")]
        public required string Email { get; set; }
    }
}
