using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class Positions
    {
        [Key]
        public Int64 Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public bool IsActive { get; set; }
    }
}
