using MillitaryService.Models;
namespace MillitaryService.DTOs
{
    public class GetMilitaryUnitsDto
    {
        public List<MilitaryUnits> militaryUnits {  get; set; }
        public int totalPages { get; set; }
    }
}
