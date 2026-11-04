using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class PersonnelAssignments
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 PersonnelId { get; set; }
        public Personnel Personnel { get; set; }

        public Int64 MilitaryUnitId { get; set; }
        public MilitaryUnits militaryUnit { get; set; }

        public Int64 PositionId { get; set; }
        public Positions position { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool IsCurrent { get; set; }
    }
}
