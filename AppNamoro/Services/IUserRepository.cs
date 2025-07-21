using AppNamoro.Models;

namespace AppNamoro.Services;

public interface IUserRepository
{
    Task<Guid> Create(User user);
    Task<User> GetUser(Guid id);

}