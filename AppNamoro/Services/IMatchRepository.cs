using AppNamoro.Models;

namespace AppNamoro.Services;

public interface IMatchRepository
{
    Task<User> LikeUser1(Guid id);
    Task<User> LikeUser2(Guid id);
}