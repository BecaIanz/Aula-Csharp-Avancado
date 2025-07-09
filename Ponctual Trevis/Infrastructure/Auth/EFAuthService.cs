using Microsoft.EntityFrameworkCore;
using Ponctual.Domain.Services.Auth;

namespace Ponctual.Infrastructure.Auth;

public class EFAuthService(PonctualDbContext ctx) : IAuthService
{
    public async Task<LoginResult> Login(string username, string password)
    {
        var query = 
            from f in ctx.Funcionarios
            where f.Nome == username
            select f;
        
        var users = await query.ToListAsync();
        if (users.Count == 0)
            return LoginResult.Fail("Nome desconhecido");

        var user = users.FirstOrDefault();
        if (user.Senha != password)
            return LoginResult.Fail("Senha incorreta");

        return LoginResult.Success(user.ID, user.Nome);
    }
}