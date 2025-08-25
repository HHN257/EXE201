using SmartTravel.Domain.Entities;

namespace SmartTravel.Application.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
        bool ValidateToken(string token);
        int? GetUserIdFromToken(string token);
    }
}
