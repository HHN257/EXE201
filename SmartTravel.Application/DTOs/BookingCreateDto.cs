using System.ComponentModel.DataAnnotations;

namespace SmartTravel.Application.DTOs
{
    public class BookingCreateDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int ServiceId { get; set; }
        public DateTime? ServiceDate { get; set; }
        public string? Notes { get; set; }
        public decimal? Amount { get; set; }
        public string Currency { get; set; } = "VND";
    }
}


