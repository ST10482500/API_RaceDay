using API_RaceDay.Data;
using API_RaceDay.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_RaceDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
    private readonly ApplicationDBContext _context;
    public ParticipantsController(ApplicationDBContext context) => _context = context;

    [HttpGet("{id}")]
     [Authorize(Roles = "Participant")]
        public async Task<ActionResult<Participant>> GetProfile(int id)
        {
            var participant = await _context.Participants.FindAsync(id);
            if (participant == null) return NotFound();
            return participant;
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Participant")]
        public async Task<IActionResult> UpdateProfile(int id, Participant participant)
        {
            if (id != participant.ParticipantID) return BadRequest();
            _context.Entry(participant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }





    }
}
