namespace FinacialTrackerApplication.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public DateTime Date { get; set; }
        public User User { get; set; }

    }
}
