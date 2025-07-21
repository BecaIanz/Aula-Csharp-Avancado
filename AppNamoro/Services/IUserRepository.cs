using AppNamoro.Models;

namespace AppNamoro.Services;

public interface IUserRepository
{
    Task<Guid> Create(User user);
    Task<User> GetUser(Guid id);
    Task Delete(User user);
    Task<User> Login(string user, string password);
    Task<ICollection<User>> GetFeed(Guid IDUser);

}