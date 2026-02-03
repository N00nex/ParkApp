using Microsoft.AspNetCore.Mvc;
using ParkAPI.Models;
using ParkAPI.Helpers;

namespace ParkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreisKlasseController : ControllerBase
    {
        [HttpGet] // HTTP-Methode definieren
        public async Task<ActionResult<IEnumerable<PreisKlasse>>> GetAll(CancellationToken ct)
        {
            var parkhaeuser = await DatabaseHelper.GetAll<ParkHaus>(ct);
            return Ok(parkhaeuser);
        }
    }
}
