namespace FinancialTracker.Models.DTO
{
    public class TransactionDTO
    {
        public int TrackerId { get; set; }
        public float Amount { get; set; }
        public DateTime DateTime { get; set; }
    }
}
