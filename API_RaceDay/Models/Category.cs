namespace API_RaceDay.Models
{
    public class Category
    {
    public int CategoryID { get; set; }
    public int EventID { get; set; }
    public string Name { get; set; }
    public string Distance { get; set; }

    public Event Event { get; set; }
    public ICollection<Enrolment> Enrolments { get; set; }

    }
}
