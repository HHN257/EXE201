namespace SmartTravel.Application.DTOs
{
    public class TourGuideDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Bio { get; set; }
        public string? Languages { get; set; }
        public string? Specializations { get; set; }
        public decimal? HourlyRate { get; set; }
        public string Currency { get; set; } = "VND";
        public decimal? Rating { get; set; }
        public int? TotalReviews { get; set; }
        public string? ProfileImage { get; set; }
        public bool IsVerified { get; set; }
    }
}


