﻿namespace FinacialTrackerApplication.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public string ExpenseName { get; set; }
        public float Value { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
