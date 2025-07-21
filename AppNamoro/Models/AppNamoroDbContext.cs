using Microsoft.EntityFrameworkCore;

namespace AppNamoro.Models;

public class AppNamoroDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Match> Matches => Set<Match>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Match>()
            .HasOne(m => m.PeoplesMatches)
            .WithMany(u => u.PeoplesMatches)
            .HasForeignKey(m => m.PeoplesMatchesID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<Match>()
            .HasOne(m => m.MyMatches)
            .WithMany(u => u.MyMatches)
            .HasForeignKey(m => m.MyMatchesID)
            .OnDelete(DeleteBehavior.NoAction);

        model.Entity<User>();
    }
}