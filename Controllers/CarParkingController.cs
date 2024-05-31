using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CarParkSystem.Models;
using CarParkSystem.Data; 
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CarParkSystem.Controllers
{
    [Route("api/ParkingCount/[controller]")]
    [ApiController]
    public class CarParkingController : ControllerBase
    {
        private readonly ParkingDbContext _context;

        public CarParkingController(IConfiguration configuration, ParkingDbContext context)
        {
            _context = context;
        }

        // POST: api/ParkingCount/CarParking/AddMinusCount/{id}
        [HttpPost("AddMinusCount/{id}")]
        public async Task<IActionResult> AddMinusCount(int id, [FromBody] bool aDD)
        {
            var parkingCount = await _context.Parkings.FindAsync(id);

            if (parkingCount == null)
            {
                return NotFound();
            }

            if (aDD)
            {
                parkingCount.TotalCount += 1;
            }
            else
            {
                parkingCount.TotalCount -= 1;
            }

            await _context.SaveChangesAsync();

            return Ok(parkingCount);
        }

        // PUT: api/ParkingCount/CarParking/EditCount/{id}
        [HttpPut("EditCount/{id}")]
        public async Task<IActionResult> EditCount(int id, [FromBody] int newCount)
        {
            var parkingCount = await _context.Parkings.FindAsync(id);

            if (parkingCount == null)
            {
                return NotFound();
            }

            parkingCount.TotalCount = newCount;
            await _context.SaveChangesAsync();

            return Ok(parkingCount);
        }

        // GET: api/ParkingCount/CarParking/TotalCount/{id}
        [HttpGet("TotalCount/{id}")]
        public async Task<IActionResult> GetTotalCount(int id)
        {
            var parkingCount = await _context.Parkings.FindAsync(id);

            if (parkingCount == null)
            {
                return NotFound();
            }

            return Ok(parkingCount.TotalCount);
        }
    }
}
