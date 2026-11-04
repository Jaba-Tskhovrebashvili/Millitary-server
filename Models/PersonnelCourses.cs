using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class PersonnelCourses
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 PersonnelId { get; set; }
        public Personnel Personnel { get; set; }

        public Int64 CourseId { get; set; }
        public Courses Course { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public string? Result { get; set; }

       
    }
}
