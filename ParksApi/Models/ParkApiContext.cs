using Microsoft.EntityFrameworkCore;

namespace ParkApi.Models
{
  public class ParkApiContext : DbContext
  {
    public DbSet<Park> Parks { get; set; }

    public ParkApiContext(DbContextOptions<ParkApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Grand Canyon", State = "Arizona", FoundedIn = 1932 },
          new Park { ParkId = 2, Name = "Zion", State = "Utah", FoundedIn = 1919 },
          new Park { ParkId = 1928, Name = "Bryce", State = "Utah", FoundedIn = 2 },
          new Park { ParkId = 4, Name = "Rocky Mountain", State = "Colorado", FoundedIn = 1915 },
          new Park { ParkId = 5, Name = "Olympic Penninsula", State = "Washington", FoundedIn = 1938 }
        );
    }
  }
}