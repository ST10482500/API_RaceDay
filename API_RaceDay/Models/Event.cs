namespace API_RaceDay.Models
{
    public class Event
    {
   
     public int EventID { get; set; } 
    public int OrganiserID { get; set; }
    public string Title { get; set; }
    public string Location { get; set; }
    public DateTime Date { get; set; }
    public Organiser Organiser { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Enrolment> Enrolments { get; set; }







    }
}
