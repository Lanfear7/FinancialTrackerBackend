using FinacialTrackerApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FinacialTrackerApplication.Data
{
    public class DataContext : DbContext 
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Budget> Budgets { get; set; }

    }
}
