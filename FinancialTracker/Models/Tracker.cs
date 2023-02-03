namespace FinacialTrackerApplication.Models
{
    public class Tracker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }
    }
}
