using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SmartTravel.Application.DTOs;
using SmartTravel.Infrastructure.Data;

namespace SmartTravel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        private readonly SmartTravelDbContext _dbContext;

        public CategoriesController(SmartTravelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var categories = await _dbContext.Categories
                .Where(c => c.IsActive)
                .OrderBy(c => c.DisplayOrder)
                .Select(c => new CategoryDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    Icon = c.Icon,
                    DisplayOrder = c.DisplayOrder
                })
                .ToListAsync();

            return Ok(categories);
        }

        [HttpGet("{categoryId}/services")]
        public async Task<ActionResult<IEnumerable<ServiceDto>>> GetServicesByCategory(int categoryId)
        {
            var exists = await _dbContext.Categories.AnyAsync(c => c.Id == categoryId && c.IsActive);
            if (!exists)
            {
                return NotFound();
            }

            var services = await _dbContext.Services
                .Where(s => s.CategoryId == categoryId && s.IsActive)
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
    }
}


