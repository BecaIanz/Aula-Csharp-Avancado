using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ponctual.Application;
using Ponctual.Domain.Services.Auth;
using Ponctual.Infrastructure;
using Ponctual.Infrastructure.Auth;

var strConnBuilder = new SqlConnectionStringBuilder {
    DataSource = "localhost",
    InitialCatalog = "ponctual",
    TrustServerCertificate = true,
    IntegratedSecurity = true
};
var strConn = strConnBuilder.ToString();

var services = new ServiceCollection();

services.AddTransient<LoginUseCase>();

services.AddTransient<IAuthService, EFAuthService>();
services.AddDbContext<PonctualDbContext>(
    opt => opt.UseSqlServer(strConn)
);

var provider = services.BuildServiceProvider();


var db = provider.GetService<PonctualDbContext>();
await db.Database.EnsureCreatedAsync();

var login = provider.GetService<LoginUseCase>();
var userId = await login.Login();
if (userId == -1)
    return;

