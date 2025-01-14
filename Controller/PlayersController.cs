using Microsoft.AspNetCore.Mvc;
using Proiect_Medii.Data;
using Proiect_Medii.Models;

namespace Proiect_Medii.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PlayersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet]
        public IActionResult GetPlayers()
        {
            var players = _context.Players.ToList();
            return Ok(players);
        }

        // GET: api/Players/{id}
        [HttpGet("{id}")]
        public IActionResult GetPlayer(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.ID == id);
            if (player == null)
            {
                return NotFound();
            }

            return Ok(player);
        }

        // POST: api/Players
        [HttpPost]
        public IActionResult CreatePlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Players.Add(player);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetPlayer), new { id = player.ID }, player);
        }

        // PUT: api/Players/{id}
        [HttpPut("{id}")]
        public IActionResult UpdatePlayer(int id, [FromBody] Player player)
        {
            if (id != player.ID)
            {
                return BadRequest();
            }

            var existingPlayer = _context.Players.FirstOrDefault(p => p.ID == id);
            if (existingPlayer == null)
            {
                return NotFound();
            }

            existingPlayer.Name = player.Name;
            existingPlayer.Age = player.Age;
            existingPlayer.Position = player.Position;
            existingPlayer.Goals = player.Goals;

            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Players/{id}
        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.ID == id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
