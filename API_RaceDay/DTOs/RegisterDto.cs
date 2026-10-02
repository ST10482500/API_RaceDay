namespace API_RaceDay.DTOs
{
    public class RegisterDto
    {
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; } // plain text password, will be hashed before storing in the database
        public string Role { get; set; } //Organisers or Participant
        public int?  Age { get; set; } // only for participant
        public string Gender { get; set; }
    public string ContactNumber { get; set; } //only for organiser



    }
}
