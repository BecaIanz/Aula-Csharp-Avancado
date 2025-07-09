using Microsoft.EntityFrameworkCore;
using Ponctual.Domain.Models;

namespace Ponctual.Infrastructure;

public class PonctualDbContext(DbContextOptions opts) : DbContext(opts)
{
    public DbSet<Funcionario> Funcionarios => Set<Funcionario>();
    public DbSet<Registro> Registros => Set<Registro>();

    protected override void OnModelCreating(ModelBuilder model)
    {
        model.Entity<Funcionario>();

        model.Entity<Registro>()
            .HasOne(r => r.Funcionario)
            .WithMany(f => f.Registros)
            .HasForeignKey(r => r.FuncionarioID)
            .OnDelete(DeleteBehavior.Cascade);
    }
}