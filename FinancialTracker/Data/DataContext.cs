using FinacialTrackerApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace FinacialTrackerApplication.Data
{
    public class DataContext : DbContext 
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Transaction>()
                .HasOne(transaction => transaction.Tracker)
                .WithMany(trackers => trackers.Transactions)
                .HasForeignKey(transaction => transaction.TrackerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Transaction>()
                .HasOne(transaction => transaction.User)
                .WithMany(user => user.Transactions)
                .HasForeignKey(transaction => transaction.UserId);
        }*/

        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Tracker> Trackers { get; set; }
        public DbSet<Budget> Budgets { get; set; }

    }
}
