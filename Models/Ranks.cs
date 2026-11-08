using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class Ranks
    {
        [Key]
        public Int64 Id { get; set; }

        public string Name { get; set; }

    }
}
