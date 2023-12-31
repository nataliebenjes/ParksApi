using Microsoft.EntityFrameworkCore;

namespace ParksApi.Models
{
  public class ParksApiContext : DbContext
  {
    //new code here for auth
    protected readonly IConfiguration Configuration;
    public ParksApiContext(IConfiguration configuration)
    {
      Configuration = configuration;
    }
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
      options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
    }
    //end new auth code
    public DbSet<Park> Parks { get; set; }

    // public ParksApiContext(DbContextOptions<ParksApiContext> options) : base(options)
    // {
    // }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Park>()
        .HasData(
          new Park { ParkId = 1, Name = "Grand Canyon", Type = "National", FoundedIn = 1932 },
          new Park { ParkId = 2, Name = "Zion", Type = "National", FoundedIn = 1919 },
          new Park { ParkId = 3, Name = "Bryce", Type = "National", FoundedIn = 1938 },
          new Park { ParkId = 4, Name = "Rocky Mountain", Type = "National", FoundedIn = 1915 },
          new Park { ParkId = 5, Name = "Olympic Penninsula", Type = "National", FoundedIn = 1938 },
          new Park { ParkId = 6, Name = "Silver Falls", Type = "State", FoundedIn = 1933 },
          new Park { ParkId = 7, Name = "Sunset Bay", Type = "State", FoundedIn = 1948 },
          new Park { ParkId = 8, Name = "LL Stub Stewart", Type = "State", FoundedIn = 2007 }
        );
    }
  }
}