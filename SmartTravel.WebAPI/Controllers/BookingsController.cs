using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SmartTravel.Application.DTOs;
using SmartTravel.Domain.Entities;
using SmartTravel.Infrastructure.Data;

namespace SmartTravel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class BookingsController : ControllerBase
    {
        private readonly SmartTravelDbContext _dbContext;

        public BookingsController(SmartTravelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<object>> Create([FromBody] BookingCreateDto dto)
        {
            if (!await _dbContext.Users.AnyAsync(u => u.Id == dto.UserId))
            {
                return BadRequest("Invalid user");
            }
            if (!await _dbContext.Services.AnyAsync(s => s.Id == dto.ServiceId))
            {
                return BadRequest("Invalid service");
            }

            var booking = new Booking
            {
                BookingReference = $"BK-{Guid.NewGuid().ToString()[..8].ToUpper()}",
                BookingDate = DateTime.UtcNow,
                ServiceDate = dto.ServiceDate,
                Notes = dto.Notes,
                Amount = dto.Amount,
                Currency = dto.Currency,
                Status = "Pending",
                UserId = dto.UserId,
                ServiceId = dto.ServiceId
            };

            _dbContext.Bookings.Add(booking);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = booking.Id }, new { booking.Id, booking.BookingReference });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> GetById(int id)
        {
            var booking = await _dbContext.Bookings
                .Include(b => b.Service)
                .Include(b => b.User)
                .Where(b => b.Id == id)
                .Select(b => new
                {
                    b.Id,
                    b.BookingReference,
                    b.BookingDate,
                    b.ServiceDate,
                    b.Amount,
                    b.Currency,
                    b.Status,
                    ServiceName = b.Service.Name,
                    UserName = b.User.Name
                })
                .FirstOrDefaultAsync();

            if (booking == null) return NotFound();
            return Ok(booking);
        }
    }
}


