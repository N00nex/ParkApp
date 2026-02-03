using Microsoft.AspNetCore.Mvc;
using ParkAPI.Models;
using ParkAPI.Helpers;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParkHausController : ControllerBase // Von ControllerBase erben
    {
        public ParkHausController() { }

        [HttpGet] // HTTP-Methode definieren
        public async Task<ActionResult<IEnumerable<ParkHaus>>> GetAll(CancellationToken ct)
        {
            var parkhaeuser = await DatabaseHelper.GetAll<ParkHaus>(ct);
            return Ok(parkhaeuser);
        }
    }
}
