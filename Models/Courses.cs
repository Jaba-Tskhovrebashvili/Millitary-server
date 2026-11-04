using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class Courses
    {
        [Key]
        public Int64 Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int DurationInDays { get; set; }

        public bool IsActive { get; set; }
    }
}
