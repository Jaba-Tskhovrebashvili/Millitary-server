using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class Personnel
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
        [Required]
        [StringLength(11, MinimumLength = 11)]
        public string PersonalNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Int64 RankId { get; set; }

        public Ranks Rank { get; set; }

        [MinLength(4)]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime EnlistmentDate { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
