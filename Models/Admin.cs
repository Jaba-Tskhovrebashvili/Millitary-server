using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class Admin
    {
        [Key]
        public Int64 Id { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Surname { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string? Password { get; set; }
        public DateTime? Created_At { get; set; }
    }
}
