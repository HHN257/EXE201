using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTravel.Application.DTOs;
using SmartTravel.Infrastructure.Data;

namespace SmartTravel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly SmartTravelDbContext _dbContext;

        public ServicesController(SmartTravelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("popular")]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetPopularServices()
        {
            var services = await _dbContext.Services
                .Where(s => s.IsActive && s.IsPopular)
                .OrderBy(s => s.DisplayOrder)
                .Select(s => new ServiceDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ProviderName = s.ProviderName,
                    WebsiteUrl = s.WebsiteUrl,
                    AppIcon = s.AppIcon,
                    IsPopular = s.IsPopular,
                    CategoryId = s.CategoryId
                })
                .ToListAsync();

            return Ok(services);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDto>> GetById(int id)
        {
            var service = await _dbContext.Services
                .Where(s => s.Id == id && s.IsActive)
                .Select(s => new ServiceDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Description = s.Description,
                    ProviderName = s.ProviderName,
                    WebsiteUrl = s.WebsiteUrl,
                    AppIcon = s.AppIcon,
                    IsPopular = s.IsPopular,
                    CategoryId = s.CategoryId
                })
                .FirstOrDefaultAsync();

            if (service == null) return NotFound();
            return Ok(service);
        }
    }
}


