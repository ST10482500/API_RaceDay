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
    public class EnrolmentsController : ControllerBase
    {
    private readonly ApplicationDBContext _context;
    public EnrolmentsController(ApplicationDBContext context) => _context = context;

     [HttpPost]
     [Authorize(Roles = "Participant")]
     public async Task<ActionResult<Enrolment>> Enrol(Enrolment enrolment)
        {
            _context.Enrolments.Add(enrolment);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Enrol), new { id = enrolment.EnrolmentID }, enrolment);
        }
        [HttpGet("event/{eventId}")]
        [Authorize(Roles = "Organiser")]
        public async Task<ActionResult<IEnumerable<Enrolment>>> GetEnrolments(int eventId)
        {
            return await _context.Enrolments
                .Include(e => e.Participant)
                .Where(e => e.EventID == eventId)
                .Include(e => e.Category)
                .ToListAsync();
            
        }

    }
}
