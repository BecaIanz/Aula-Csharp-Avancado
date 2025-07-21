using AppNamoro.Models;

namespace AppNamoro.Services;

public class EFUSerRepository(AppNamoroDbContext ctx) : IUserRepository
{
    public async Task Create(User user)
    {
        ctx.Users.Add(user);
        await ctx.SaveChangesAsync();
    }

    public Task<User> GetUser(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<Guid> IUserRepository.Create(User user)
    {
        throw new NotImplementedException();
    }
}