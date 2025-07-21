using Microsoft.EntityFrameworkCore;

namespace AppNamoro.Models;

public class AppNamoroDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Match> Matches => Set<Match>();

}