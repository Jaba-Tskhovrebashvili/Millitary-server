using MillitaryService.Models;
using System.ComponentModel.DataAnnotations;

namespace MillitaryService.DTOs
{
    public class PersonnelDto
    {

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Int64 RankId { get; set; }

        public Ranks Rank { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime EnlistmentDate { get; set; }

        public bool IsActive { get; set; }
    }
}
