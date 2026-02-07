using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkAPI.Data;
using ParkAPI.Helpers;
using ParkAPI.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkHausController : ControllerBase // Von ControllerBase erben
    {
        private readonly AppDbContext _context;

        public ParkHausController(AppDbContext context)
        {
            _context = context;
        }
        //public ParkHausController() { }

        [HttpGet] // HTTP-Methode definieren
        public async Task<ActionResult<IEnumerable<ParkHaus>>> GetAll(CancellationToken ct)
        {
            //var parkhaeuser = await DatabaseHelper.GetAll<ParkHaus>(ct);
            var parkhaeuser = await _context.ParkHaus
            .Include(p => p.PreisKlasse)  // Navigation Property laden
            .AsNoTracking()
            .ToListAsync(ct);

            return Ok(parkhaeuser);
        }
    }
}
