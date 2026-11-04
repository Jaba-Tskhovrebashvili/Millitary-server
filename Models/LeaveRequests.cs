using System.ComponentModel.DataAnnotations;

namespace MillitaryService.Models
{
    public class LeaveRequests
    {
        [Key]
        public Int64 Id { get; set; }
        public Int64 PersonnelId { get; set; }
        public Personnel Personnel { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Reason { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public DateTime RequestDate { get; set; }

    }
}
