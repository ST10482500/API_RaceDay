namespace API_RaceDay.Models
{
    public class Participant
    {
    
    public int ParticipantID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }

    public ICollection<Enrolment> Enrolments { get; set; }




    }
}
