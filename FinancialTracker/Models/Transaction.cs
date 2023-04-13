namespace FinacialTrackerApplication.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public float Amount { get; set; }
        public int TrackerId { get; set; }
        public DateTime DateTime { get; set; }
        public Tracker Tracker { get; set; }
    }
}
