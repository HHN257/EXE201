using System.ComponentModel.DataAnnotations;

namespace SmartTravel.Domain.Entities
{
    public class UserPreference
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string PreferenceKey { get; set; } = string.Empty;
        
        [StringLength(500)]
        public string? PreferenceValue { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? UpdatedAt { get; set; }
        
        // Foreign key
        public int UserId { get; set; }
        
        // Navigation property
        public virtual User User { get; set; } = null!;
    }
}
