namespace API_RaceDay.Models
{
    public class Enrolment
    {
    public int EnrolmentID { get; set; }
    public int ParticipantID { get; set; }
    public int EventID { get; set; }
    public int CategoryID { get; set; }
    public DateTime RegistrationDate { get; set; }

    public Event Event { get; set; }
    public Participant Participant { get; set; }
    public Category Category { get; set; }
    public ICollection<Result> Results { get; set; }







    }
}
