namespace FinacialTrackerApplication.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public User User { get; set; }
    }
}
