using MillitaryService.Models;

namespace MillitaryService.DTOs
{
    public class GetPersonelsDto
    {
        public List<Personnel> Personnels { get; set; }
        public int totalPages { get; set; }
    }
}
