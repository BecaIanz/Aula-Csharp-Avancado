using System.Linq;
using AppNamoro.Models;
using Microsoft.EntityFrameworkCore;

namespace AppNamoro.Services;

public class EFUSerRepository(AppNamoroDbContext ctx) : IUserRepository
{
    public async Task<Guid> Create(User user)
    {
        ctx.Users.Add(user);
        await ctx.SaveChangesAsync();
        return user.ID;
    }

    public async Task Delete(User user)
    {
        ctx.Users.Remove(user); 
        await ctx.SaveChangesAsync(); 
    }

    public async Task<ICollection<User>> GetFeed(Guid IDUser)
    {
        var UserVisited = await ctx.Matches
            .Where(v => v.MyMatchesID == IDUser)
            .Select(v => v.PeoplesMatchesID)
            .ToListAsync();

        var Feed = await  ctx.Users
            .Where(f => f.ID != IDUser && !UserVisited.Contains(f.ID))
            .Take(10)
            .ToListAsync();
        
        return Feed;

    }

    public async Task<User> GetUser(Guid id)
    {
        var query =
            from u in ctx.Users
                .Include(u => u.MyMatches)
                .Include(u => u.PeoplesMatches)
            where u.ID == id
            select u;

        var UserMatch = await query.FirstOrDefaultAsync();
        return UserMatch;
       
    }

    public async Task<User> Login(string name, string password)
    {
        var query =
            from l in ctx.Users
                .Include(l => l.Password)
                .Include(l => l.Name)
            where l.Name == name
            where l.Password == password
            select l;

        var UserLogin = await query.FirstOrDefaultAsync();
        return UserLogin;
       
    }
}