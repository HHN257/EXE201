using System.ComponentModel.DataAnnotations;

namespace SmartTravel.Domain.Entities
{
    public class ServiceReview
    {
        public int Id { get; set; }
        
        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }
        
        [StringLength(1000)]
        public string? Comment { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public bool IsVerified { get; set; } = false;
        
        // Foreign keys
        public int ServiceId { get; set; }
        public int UserId { get; set; }
        
        // Navigation properties
        public virtual Service Service { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
