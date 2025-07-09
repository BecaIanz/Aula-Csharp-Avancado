using Ponctual.Domain.Services.Auth;

namespace Ponctual.Application;

public class LoginUseCase(IAuthService auth)
{
    public async Task<int> Login()
    {
        Console.Write("Usuário: ");
        var user = Console.ReadLine();

        Console.Write("Senha: ");
        var password = Console.ReadLine();

        var result = await auth.Login(user, password);
        if (!result.IsSuccess)
        {
            Console.WriteLine(result.Reason);
            return -1;
        }

        Console.WriteLine($"Bem-vindo ao sistema {result.Username}");

        return result.Id;
    }
}