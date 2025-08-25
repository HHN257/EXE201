using System.ComponentModel.DataAnnotations;

namespace SmartTravel.Domain.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string BookingReference { get; set; } = string.Empty;
        
        public DateTime BookingDate { get; set; } = DateTime.UtcNow;
        
        public DateTime? ServiceDate { get; set; }
        
        [StringLength(500)]
        public string? Notes { get; set; }
        
        public decimal? Amount { get; set; }
        
        [StringLength(10)]
        public string Currency { get; set; } = "VND";
        
        [StringLength(50)]
        public string Status { get; set; } = "Pending"; // Pending, Confirmed, Cancelled, Completed
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Foreign keys
        public int UserId { get; set; }
        public int ServiceId { get; set; }
        
        // Navigation properties
        public virtual User User { get; set; } = null!;
        public virtual Service Service { get; set; } = null!;
    }
}
