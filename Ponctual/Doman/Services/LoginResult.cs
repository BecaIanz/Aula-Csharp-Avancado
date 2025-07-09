using System.Dynamic;

namespace PONCTUAL.Doman.Services.Auth;

// public class LoginResult
// {
//     public int? ID { get; private set; }
//     public string Username { get; private set; }
//     public bool ISSucess { get; private set; }
//     public string Reason { get; private set; }
// }

//OU
public record LoginResult(
    int ID,
    string UserName,
    bool ISSucess,
    string Reason
);