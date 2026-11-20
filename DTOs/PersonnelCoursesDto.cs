using MillitaryService.Models;
using System.ComponentModel.DataAnnotations;

namespace MillitaryService.DTOs
{
    public class PersonnelCoursesDto
    {
        public Int64 PersonnelId { get; set; }
        public Int64 CourseId { get; set; }
        public DateTime EnrollmentDate { get; set; }

        public DateTime? CompletionDate { get; set; }

        public CourseResult? Result { get; set; } = CourseResult.NotCompleted;
    }
}
