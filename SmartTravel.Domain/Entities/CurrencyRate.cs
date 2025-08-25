using System.ComponentModel.DataAnnotations;

namespace SmartTravel.Domain.Entities
{
    public class CurrencyRate
    {
        public int Id { get; set; }
        
        [Required]
        [StringLength(10)]
        public string FromCurrency { get; set; } = string.Empty;
        
        [Required]
        [StringLength(10)]
        public string ToCurrency { get; set; } = string.Empty;
        
        [Required]
        public decimal Rate { get; set; }
        
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
        
        public bool IsActive { get; set; } = true;
    }
}
