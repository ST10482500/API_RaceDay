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
    public class CategoriesController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public CategoriesController(ApplicationDBContext context) =>  _context = context;

        [HttpGet("{eventId}")]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories(int eventId)
        {
     
        return await _context.Categories.Where(c => c.EventID == eventId).ToListAsync();  

        }
        [HttpPost]
        [Authorize(Roles = "Organiser")]
        public async Task<ActionResult<Category>> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCategories), new { eventId = category.EventID }, category);
        }


    }
}
