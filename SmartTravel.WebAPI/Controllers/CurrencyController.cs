using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartTravel.Application.DTOs;
using SmartTravel.Infrastructure.Data;

namespace SmartTravel.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly SmartTravelDbContext _dbContext;

        public CurrencyController(SmartTravelDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("rates")]
        public async Task<ActionResult<IEnumerable<CurrencyRateDto>>> GetRates()
        {
            var rates = await _dbContext.CurrencyRates
                .Where(r => r.IsActive)
                .Select(r => new CurrencyRateDto
                {
                    FromCurrency = r.FromCurrency,
                    ToCurrency = r.ToCurrency,
                    Rate = r.Rate,
                    LastUpdated = r.LastUpdated
                })
                .ToListAsync();

            return Ok(rates);
        }

        [HttpGet("convert")]
        public async Task<ActionResult<decimal>> Convert([FromQuery] string from, [FromQuery] string to, [FromQuery] decimal amount)
        {
            var rate = await _dbContext.CurrencyRates
                .Where(r => r.FromCurrency == from && r.ToCurrency == to && r.IsActive)
                .Select(r => r.Rate)
                .FirstOrDefaultAsync();

            if (rate == 0) return NotFound("Rate not found");

            return Ok(amount * rate);
        }
    }
}


