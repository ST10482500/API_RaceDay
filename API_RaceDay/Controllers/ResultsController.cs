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
    public class ResultsController : ControllerBase
    {
    private readonly ApplicationDBContext _context;
    public ResultsController(ApplicationDBContext context) => _context = context;

    [HttpPost]
    [Authorize(Roles = "Organiser")]
        public async Task<ActionResult<Result>> CaptureResult(Result result)
        {
            _context.Results.Add(result);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CaptureResult), new { id = result.ResultID }, result);
        }
        [HttpGet("participant/{participantId}")]
        [Authorize(Roles = "Participant")]
        public async Task<ActionResult<IEnumerable<Result>>> GetResultsForParticipant(int participantId)
        {
            return await _context.Results
                .Include(r => r.Event)
                .Include(r => r.Category)
                .Where(r => r.ParticipantID == participantId)
                .ToListAsync();
        }












    }
}
