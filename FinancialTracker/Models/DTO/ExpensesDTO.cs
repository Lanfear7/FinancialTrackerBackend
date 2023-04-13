namespace FinancialTracker.Models.DTO
{
    public class ExpensesDTO
    {
        public string ExpenseName { get; set; }
        public float Value { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
    }
}
