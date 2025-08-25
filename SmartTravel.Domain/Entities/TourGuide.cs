using System.ComponentModel.DataAnnotations;

namespace SmartTravel.Domain.Entities
{
    public class TourGuide
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? Bio { get; set; }
        
        [StringLength(20)]
        public string? PhoneNumber { get; set; }
        
        [EmailAddress]
        [StringLength(150)]
        public string? Email { get; set; }
        
        [StringLength(100)]
        public string? Languages { get; set; } // Comma-separated list
        
        [StringLength(100)]
        public string? Specializations { get; set; } // Comma-separated list
        
        public decimal? HourlyRate { get; set; }
        
        [StringLength(10)]
        public string Currency { get; set; } = "VND";
        
        [Range(1, 5)]
        public decimal? Rating { get; set; }
        
        public int? TotalReviews { get; set; } = 0;
        
        [StringLength(500)]
        public string? ProfileImage { get; set; }
        
        public bool IsVerified { get; set; } = false;
        
        public bool IsActive { get; set; } = true;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Navigation properties
        public virtual ICollection<TourGuideReview> Reviews { get; set; } = new List<TourGuideReview>();
    }
}
