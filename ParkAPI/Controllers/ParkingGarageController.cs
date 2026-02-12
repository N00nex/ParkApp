using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkAPI.Data;
using ParkAPI.Models;


namespace ParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkingGarageController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public ParkingGarageController(AppDbContext context)
        {
            _context = context;
        }
         

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<ParkingGarage>>> GetAll(CancellationToken ct)
        {
            var parkingGarages = await _context.ParkingGarage
                .Include(p => p.Price)  // Navigation Property laden
                .Include(b => b.OpeningHours)
                .Include(a => a.Address)
                .AsNoTracking()
                .ToListAsync(ct);

            return Ok(parkingGarages);
        }
    }
}
