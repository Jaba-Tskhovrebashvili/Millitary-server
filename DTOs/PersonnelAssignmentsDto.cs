using MillitaryService.Models;

namespace MillitaryService.DTOs
{
    public class PersonnelAssignmentsDto
    {
        public Int64 PersonnelId { get; set; }

        public Int64 MilitaryUnitId { get; set; }

        public Int64 PositionId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
