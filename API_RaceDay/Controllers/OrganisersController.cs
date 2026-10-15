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
    public class OrganisersController : ControllerBase
    {
   
    private readonly ApplicationDBContext _context;
    public OrganisersController(ApplicationDBContext context) => _context = context;

        [HttpGet("{id}")]
        [Authorize(Roles = "Organiser")]
        public async Task<ActionResult<Organiser>> GetOrganiser(int id)
        {
            var organiser = await _context.Organisers.FindAsync(id);
            if (organiser == null) return NotFound();
            return organiser;
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Organiser")]
        public async Task<IActionResult> UpdateOrganiser(int id, Organiser organiser)
        {
            if (id != organiser.OrganiserID) return BadRequest();
            _context.Entry(organiser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }



    }
}
