using marquee_backend.Regex;
using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace marquee_backend.ViewModel.Auth
{
    [Table("role")]
    public class Role
    {
        [Column("id")]
        public Guid Id { get; set; }

        [Column("name")]
        [RegularExpression(RegexPatterns.RoleNameRegex, ErrorMessage = "Role names may only consist out of upper-, lowercase letters, and spaces.")]
        public required string Name { get; set; }
    }
}
