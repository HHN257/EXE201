using System.ComponentModel.DataAnnotations;

namespace SmartTravel.Domain.Entities
{
    public class Service
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        
        [StringLength(1000)]
        public string? Description { get; set; }
        
        [Required]
        [StringLength(100)]
        public string ProviderName { get; set; } = string.Empty; // Traveloka, Grab, etc.
        
        [StringLength(500)]
        public string? AppStoreUrl { get; set; }
        
        [StringLength(500)]
        public string? PlayStoreUrl { get; set; }
        
        [StringLength(500)]
        public string? WebsiteUrl { get; set; }
        
        [StringLength(50)]
        public string? AppIcon { get; set; }
        
        public decimal? MinPrice { get; set; }
        
        public decimal? MaxPrice { get; set; }
        
        [StringLength(10)]
        public string Currency { get; set; } = "VND";
        
        public bool IsPopular { get; set; } = false;
        
        public bool IsActive { get; set; } = true;
        
        public int DisplayOrder { get; set; } = 0;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        // Foreign key
        public int CategoryId { get; set; }
        
        // Navigation properties
        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<ServiceReview> Reviews { get; set; } = new List<ServiceReview>();
        public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
