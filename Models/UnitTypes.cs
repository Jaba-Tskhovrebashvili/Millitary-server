using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class UnitTypes
    {
        [Key]
        public Int64 Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Level { get; set; }

        public string Description { get; set; } = string.Empty;
    }
}
