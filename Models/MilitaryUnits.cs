using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace MillitaryService.Models
{
    public class MilitaryUnits
    {
        [Key]
        public Int64 Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Int64 UnitTypeId { get; set; }
        public UnitTypes unitType { get; set; }

        [AllowNull]
        public int? ParentUnitId { get; set; }

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
