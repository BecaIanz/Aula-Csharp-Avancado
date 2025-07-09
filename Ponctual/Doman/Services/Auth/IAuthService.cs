namespace PONCTUAL.Doman.Services.Auth;

public interface IAuthService
{
    LoginResult Login(string username, string password);
}