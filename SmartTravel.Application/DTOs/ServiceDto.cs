namespace SmartTravel.Application.DTOs
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ProviderName { get; set; } = string.Empty;
        public string? WebsiteUrl { get; set; }
        public string? AppIcon { get; set; }
        public bool IsPopular { get; set; }
        public int CategoryId { get; set; }
    }
}


