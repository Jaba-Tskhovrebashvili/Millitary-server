using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace MillitaryService.Models
{
    public class MilitaryUnits
    {
        [Key]
        public Int64 Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public Int64 UnitTypeId { get; set; }
        public UnitTypes UnitType { get; set; }

        [AllowNull]
        public Int64? ParentUnitId { get; set; }
        [JsonIgnore]
        public MilitaryUnits? ParentUnit { get; set; }
        public string Description { get; set; } = string.Empty;

        public ICollection<MilitaryUnits> SubUnits { get; set; }
      = new List<MilitaryUnits>();

        public bool IsActive { get; set; }
    }
}
