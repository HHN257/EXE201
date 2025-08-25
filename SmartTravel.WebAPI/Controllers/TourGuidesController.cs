using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTravel.Application.DTOs;
using SmartTravel.Infrastructure.Data;

namespace SmartTravel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TourGuidesController : ControllerBase
    {
        private readonly SmartTravelDbContext _dbContext;

        public TourGuidesController(SmartTravelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TourGuideDto>>> GetAll()
        {
            var guides = await _dbContext.TourGuides
                .Where(g => g.IsActive)
                .OrderByDescending(g => g.Rating)
                .Select(g => new TourGuideDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Bio = g.Bio,
                    Languages = g.Languages,
                    Specializations = g.Specializations,
                    HourlyRate = g.HourlyRate,
                    Currency = g.Currency,
                    Rating = g.Rating,
                    TotalReviews = g.TotalReviews,
                    ProfileImage = g.ProfileImage,
                    IsVerified = g.IsVerified
                })
                .ToListAsync();

            return Ok(guides);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TourGuideDto>> GetById(int id)
        {
            var guide = await _dbContext.TourGuides
                .Where(g => g.Id == id && g.IsActive)
                .Select(g => new TourGuideDto
                {
                    Id = g.Id,
                    Name = g.Name,
                    Bio = g.Bio,
                    Languages = g.Languages,
                    Specializations = g.Specializations,
                    HourlyRate = g.HourlyRate,
                    Currency = g.Currency,
                    Rating = g.Rating,
                    TotalReviews = g.TotalReviews,
                    ProfileImage = g.ProfileImage,
                    IsVerified = g.IsVerified
                })
                .FirstOrDefaultAsync();

            if (guide == null) return NotFound();
            return Ok(guide);
        }
    }
}


