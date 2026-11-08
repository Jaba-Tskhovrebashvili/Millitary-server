using MillitaryService.Models;

namespace MillitaryService.DTOs
{
    public class AdminSignInResponseDto
    {
        public Admin Admin { get; set; }
        public string Token { get; set; }
    }
}
