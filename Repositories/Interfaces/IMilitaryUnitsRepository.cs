using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IMilitaryUnitsRepository
    {
        Task<GetMilitaryUnitsDto> MilitaryUnitsSearch(string search, int page);
    }
}
