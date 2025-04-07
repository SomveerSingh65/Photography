using Microsoft.EntityFrameworkCore;
using Photography.Models;
using System.Security.Cryptography.X509Certificates;

namespace Photography.Databases
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<MediaModel> Media { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookingModel>().HasKey(X=>X.BookingId);
            modelBuilder.Entity<MediaModel>().HasKey(x=>x.MediaId);
        }
    }
}
