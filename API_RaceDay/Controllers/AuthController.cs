using API_RaceDay.Data;
using API_RaceDay.DTOs;
using API_RaceDay.Models;
using API_RaceDay.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_RaceDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
     private readonly ApplicationDBContext _context;
        private readonly IJwtService _jwtService;
     
    public AuthController(ApplicationDBContext context, IJwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            if (dto.Role == "Organiser")
            {
                var organiser = new Organiser { Name = dto.Name, Email = dto.Email, ContactNumber = dto.ContactNumber };
                _context.Organisers.Add(organiser);
            }
            else
            {
                var participant = new Participant { Name = dto.Name, Email = dto.Email, Age = (int)dto.Age, Gender = dto.Gender };
                _context.Participants.Add(participant); // Fixed the incorrect DbSet reference
            }
            await _context.SaveChangesAsync();
            return Ok("User registered successfully");
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var participant = await _context.Participants.FirstOrDefaultAsync(p => p.Email == dto.Email);
            var organiser = await _context.Organisers.FirstOrDefaultAsync(o => o.Email == dto.Email);

            var user = (object)participant ?? organiser;
            if (user == null) return Unauthorized();

            var valid = BCrypt.Net.BCrypt.Verify(dto.Password, participant?.Email == dto.Email? participant.Email: organiser.Email);

           if(!valid) return Unauthorized();
            var token = _jwtService.GenerateToken(dto.Email, dto.Role);
            return Ok(new { Token = token });

        }
    
    
    }
}
