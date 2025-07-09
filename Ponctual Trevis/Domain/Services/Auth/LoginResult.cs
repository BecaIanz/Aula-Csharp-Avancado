namespace Ponctual.Domain.Services.Auth;

public record LoginResult(
    int Id,
    string Username,
    bool IsSuccess,
    string Reason
)
{
    public static LoginResult Success(int id, string username)
    {
        return new LoginResult(id, username, true, "login realizado com sucesso");
    }

    public static LoginResult Fail(string reason)
    {
        return new LoginResult(0, null, false, reason);
    }
}