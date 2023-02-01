using FinancialTracker.Models;
using System.ComponentModel.DataAnnotations;

namespace FinacialTrackerApplication.Models
{
    public class User
    {
        public int Id { get; set; }
        public string User_Name { get; set; }
        public string Email { get; set; }
        public float MonthlyIncome { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }
        public ICollection<Tracker> Trackers { get; set; }
        public ICollection<Budget> Budgets { get; set; }
        public ICollection<Expenses> Expenses { get; set; }

    }
}
