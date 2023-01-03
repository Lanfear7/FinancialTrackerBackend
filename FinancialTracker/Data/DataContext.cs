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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasIndex(u => new { u.Email }).IsUnique();
        }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Budget> Budgets { get; set; }

    }
}
