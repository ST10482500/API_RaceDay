namespace API_RaceDay.Models
{
    public class Result
    {
        internal object Event;
        internal object Category;
        internal int ParticipantID;

        public int ResultID { get; set; }
    public int EnrolmentID { get; set; }
    public TimeSpan DurationTime { get; set; }
    public int Position { get; set; }
    public Enrolment Enrolment { get; set; }








    }
}
