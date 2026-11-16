using Microsoft.EntityFrameworkCore;
using MillitaryService.Data;
using MillitaryService.DTOs;
using MillitaryService.Models;

namespace MillitaryService.Repositories.Interfaces
{
    public interface IMilitaryUnitsRepository
    {
        Task<(List<MilitaryUnits> Items, int TotalCount)> SearchAsync(string? search, int page, int pageSize);
    }
}
