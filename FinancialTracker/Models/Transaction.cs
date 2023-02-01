namespace FinacialTrackerApplication.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime DateTime { get; set; }
        public Tracker Tracker { get; set; }
    }
}
