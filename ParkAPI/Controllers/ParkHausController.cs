using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkAPI.Data;
using ParkAPI.Models;


namespace ParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkHausController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public ParkHausController(AppDbContext context)
        {
            _context = context;
        }
         

        [HttpGet]   
        public async Task<ActionResult<IEnumerable<ParkHaus>>> GetAll(CancellationToken ct)
        {
            var parkhaeuser = await _context.ParkHaus
                .Include(p => p.PreisKlasse)  // Navigation Property laden
                .Include(b => b.BetriebsZeit)
                .Include(a => a.Address)
                .AsNoTracking()
                .ToListAsync(ct);

            return Ok(parkhaeuser);
        }
    }
}
