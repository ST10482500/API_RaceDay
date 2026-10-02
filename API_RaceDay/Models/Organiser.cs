namespace API_RaceDay.Models
{
    public class Organiser
    {
    public int OrganiserID { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ContactNumber { get; set; }


    public ICollection<Event> Events { get; set; }











    }
}
