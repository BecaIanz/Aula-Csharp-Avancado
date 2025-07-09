namespace Ponctual.Domain.Services.Auth;

public interface IAuthService
{
    Task<LoginResult> Login(string username, string password);
}